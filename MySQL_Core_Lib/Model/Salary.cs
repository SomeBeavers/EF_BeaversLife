using System;
using System.Collections.Generic;

#nullable disable

namespace MySQL_Core_Lib
{
    public partial class Salary
    {
        public int EmpNo { get; set; }
        public int Salary1 { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual Employee EmpNoNavigation { get; set; }

        public override string ToString()
        {
            return $"Salary: EmpNo = {EmpNo} Salary1 = {Salary1} FromDate = {FromDate} ToDate = {ToDate}";
        }
    }
}
