using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace OMVS_WindowsFormsApplication
{
    class Counties
    {   
        //reads the county numbers from a text file and creates a
        //dictionary of county name and county numbers (map number and alpha order number). 
        public static Dictionary<string,int[]> assignNumbers()
        {
            Dictionary<string, int[]> dict = new Dictionary<string, int[]>();

            string path = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"..\..\county_numbers.txt");

            string[] files = File.ReadAllLines(path);

            foreach (var line in files)
            {
                string[] words = line.Split('\t');

                if (words.Count() > 3)
                {
                    int[] nums = { int.Parse(words[7]), int.Parse(words[3]) };
                    dict.Add(words[0].Trim(' '), nums);
                }
                Console.WriteLine(line);
            }

                return dict;
        } 

        //reads the county names and adjacent counties from a text file,
        //associates the county name and list of adjacent counties in a 
        //dictionary, and returns the result
        public static Dictionary<string, List<string>> idAdjacencies()
        {
            Dictionary<string, List<string>> dict = 
                new Dictionary<string, List<string>>();
            string path = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"..\..\county_adjacency.txt");

            string[] files = File.ReadAllLines(path);
            string[] countyState;
            List<string> adjacencies = new List<string>();
            string county = "";
            string state = "";
            string zip = "";

            foreach (var line in files)
            {
                string[] words = line.Split('\t');

                if (line[0] != '\t')
                {
                    if (state == "IA" && adjacencies.Count()>0)
                    {
                        dict.Add(county, adjacencies);
                        adjacencies = new List<string>();
                        Console.Write("{" + adjacencies + "}\n");
                    }
                
                    countyState = words[0].Split(',');
                    zip = words[1];
                    county = countyState[0].Trim(new Char[] { '"' });
                    state = countyState[1].Trim(new Char[] { ' ', '"' });

                    if (state == "IA")
                    {   
                        
                        Console.WriteLine(county + " : " + state + " : " + zip);
                    }

                    countyState = words[2].Split(',');
                    string adjacentCounty = countyState[0].Trim(new Char[] { '"' });
                    string adjacentState = countyState[1].Trim(new Char[] { ' ', '"' });
                    string adjacentZip = words[3];

                    if (state == "IA" && adjacentState == "IA" && adjacentCounty != county)
                        adjacencies.Add(adjacentCounty);
                }
                else
                {
                    try
                    {
                        countyState = words[2].Split(',');
                        string adjacentCounty = countyState[0].Trim(new Char[] { '"' });
                        string adjacentState = countyState[1].Trim(new Char[] { ' ', '"' });
                        string adjacentZip = words[3];

                        if (state == "IA" && adjacentState == "IA" && adjacentCounty != county)
                            adjacencies.Add(adjacentCounty);
                    }
                    catch
                    {
                        //the first line of the file is a header containing a reference to 
                        //the source of the file
                        //if (line != files[0])
                        //    throw;
                    }
                }
            }
            return dict;
        }
        public static void seed()
        {
            try {
                using (var db = new CountiesEntities())
                {
                    //only seed the database with values if the database exists, but is empty
                    if (db.CountyNumbers.Count() == 0)
                    {
                        Dictionary<string, int[]> dict = Counties.assignNumbers();
                        Dictionary<string, List<string>> dict2 = Counties.idAdjacencies();

                        //seed each of the counties with their associated numbers 
                        //and adjacent counties
                        foreach (var k in dict.Keys)
                        {
                            CountyNumber c = new CountyNumber(k, dict[k], "Active");
                            db.CountyNumbers.Add(c);

                            foreach (var v in dict2[k])
                            {
                                AdjacentCounties a = new AdjacentCounties(k, v);
                                db.AdjacentCounties1.Add(a);
                            }
                        }
                        db.SaveChanges();
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show("Error occurred: \n" + 
                    "Either a missing source file ('county_adjacency.txt' or 'county_numbers.txt') " +
                    "is missing from the project directory or the database does not exist.\n" + 
                    "If the project files are missing, please replace them before continuing. \n" +
                    "If the database does not exist, please run the Create_Database.sql script before continuing. \n" + e);
            }            
        }
    }
}
