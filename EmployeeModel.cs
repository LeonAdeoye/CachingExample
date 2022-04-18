using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingExample
{
    internal class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public override String ToString() => FirstName + " " + LastName;
       

    }
}
