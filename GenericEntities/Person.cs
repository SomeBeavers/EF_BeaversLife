using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_TestFixes.Model;

namespace EF_TestFixes
{
    public class Person<T>
    {
        public string Name { get; set; }
        public Order Order { get; set; }
        public Invoice Invoice { get; set; }
    }
}
