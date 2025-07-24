using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;

namespace Mini_Data_Analyzer.Models
{
    public class User
    {
        public Name.Gender Gender { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
