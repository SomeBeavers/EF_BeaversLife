using System;
using System.Collections.Generic;

#nullable disable

namespace MySQL_Core_Lib
{
    public partial class Title
    {
        public int EmpNo { get; set; }
        public string Title1 { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual Employee EmpNoNavigation { get; set; }

        public override string ToString()
        {
            return $"Title: EmpNo = {EmpNo} Title1 = {Title1} FromDate = {FromDate} ToDate = {ToDate}";
        }
    }
}
