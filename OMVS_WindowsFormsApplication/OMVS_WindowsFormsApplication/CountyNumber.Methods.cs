using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMVS_WindowsFormsApplication
{
    public partial class CountyNumber
    {
        //Default constructor
        public CountyNumber()
        { }

        public CountyNumber(string name, int[] numbers, string status)
        {
            this.CountyName = name;
            this.mapNumber = numbers[0];
            this.alphaOrder = numbers[1];
            this.Status = status;
        }
    }
}
