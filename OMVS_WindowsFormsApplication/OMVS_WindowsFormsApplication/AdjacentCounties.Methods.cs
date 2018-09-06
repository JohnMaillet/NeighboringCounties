using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMVS_WindowsFormsApplication
{
    public partial class AdjacentCounties
    {
        //Default constructor
        public AdjacentCounties()
        { }
        //An overloaded constructor for the AdjacentCounties class
        public AdjacentCounties(string name, string adjacentCountyName)
        {
            this.CountyName = name;
            this.AdjacentCountyName = adjacentCountyName;
        }

        //Compare 2 county numbers and returns a count of items
        //resulting from a stored procedure query. Store the return
        //of the query in an integer for debugging purposes
        public static bool adjacency(int val1, int val2)
        {
            using (var db = new CountiesEntities())
            {
                int result = db.isAdjacent(val1, val2).Count();
                return result!=0 ?  true : false;                    
            }
        }
    }
}
