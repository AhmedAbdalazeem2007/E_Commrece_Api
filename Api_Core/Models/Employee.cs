﻿

namespace Api_Core.Models
{
    public class Employee:BaseEntity
    {
        public string Name {  get; set; }
        public decimal Salary {  get; set; }
        public int? Age { get; set; }
        public int DepartmentId {  get; set; }
        public Department Department { get; set; }
    }
}
