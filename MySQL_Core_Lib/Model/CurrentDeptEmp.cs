using System;
using System.Collections.Generic;

#nullable disable

namespace MySQL_Core_Lib
{
    public partial class CurrentDeptEmp
    {
        public int       EmpNo    { get; set; }
        public string    DeptNo   { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate   { get; set; }

        public override string ToString()
        {
            return $"CurrentDeptEmp: EmpNo = {EmpNo} DeptNo = {DeptNo}";
        }
    }
}
