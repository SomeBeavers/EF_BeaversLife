using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSSQL_CodeFirst_School.Models;

namespace MSSQL_CodeFirst_School
{
    public class CustomMaxLengthAttribute : MaxLengthAttribute
    {
        public CustomMaxLengthAttribute(int length) : base(length)
        {
            ErrorMessage = "Custom error message";
        }
    }

    public class UserStringLengthAttribute : StringLengthAttribute
    {
        public UserStringLengthAttribute(int maximumLength) : base(maximumLength)
        {
        }
    }

    public class MyDbFunctionAttribute : DbFunctionAttribute
    {
        public MyDbFunctionAttribute(string namespaceName, string functionName) : base(namespaceName, functionName)
        {
        }
    }

    public static class PetExtensions
    {
        //[MyDbFunction("MyNameSpace", "CustomFilter")]
        //[DbFunction("MyNameSpace", "CustomFilter")]
        public static bool CustomFilter(this Pet entityPet)
        {
            throw new NotImplementedException();
        }
    }

    public class ExtensionUsage
    {
        public void Test()
        {
            var context = new Model1();
            var res = context.Pets.Where(x => x.CustomFilter()).ToList();
        }
    }
}
