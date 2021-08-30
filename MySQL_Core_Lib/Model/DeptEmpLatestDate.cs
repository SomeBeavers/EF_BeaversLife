using System;
using System.Collections.Generic;

#nullable disable

namespace MySQL_Core_Lib
{
    public partial class DeptEmpLatestDate
    {
        public int EmpNo { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public override string ToString()
        {
            return $"DeptEmpLatestDate: EmpNo = {EmpNo} FromDate = {FromDate} ToDate = {ToDate}";
        }
    }
}
