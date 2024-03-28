using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.DataModel.Models.Department
{
    public class DepartmentEntity
    {
        public int id { get; set; }
        public string department_name { get; set; }
        public string department_code { get; set; }
    }
    public class DepartmentIdEntity
    {
        public int id { get; set; }
    }
}
