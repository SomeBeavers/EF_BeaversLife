using System;
using System.Collections.Generic;

#nullable disable

namespace MySQL_Core_Lib
{
    public partial class Department
    {
        public Department()
        {
            DeptEmps = new HashSet<DeptEmp>();
            DeptManagers = new HashSet<DeptManager>();
        }

        public string DeptNo { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<DeptEmp> DeptEmps { get; set; }
        public virtual ICollection<DeptManager> DeptManagers { get; set; }

        public override string ToString()
        {
            return $"Department: DeptNo = {DeptNo} DeptName = {DeptName}";
        }
    }
}
