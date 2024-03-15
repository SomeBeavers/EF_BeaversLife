using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TestFixes
{
    internal class Test
    {
        public void Method()
        {
            var context = new MyDbContext();
            foreach (var contextType in context.Types)
            {
                foreach (var animal in contextType.Animals)
                {
                    
                }
            }
        }
    }
}
