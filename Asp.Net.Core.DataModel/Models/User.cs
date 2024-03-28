using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.DataModel.Models
{
    public class Table
    {
        public string Records { get; set; }
        public int RETURN_VALUE { get; set; }
    }
    public class Table2
    {
        public string Records1 { get; set; }
        public string Records2 { get; set; }
        public int RETURN_VALUE { get; set; }
    }
    public class Table4
    {

        public string Records1 { get; set; }
        public string Records2 { get; set; }
        public string Records3 { get; set; }
        public string Records4 { get; set; }
        public int RETURN_VALUE { get; set; }
    }
    public class Table5
    {

        public string Data { get; set; }
    }

    public class Users
    {
        public int User_ID { get; set; }

        public string User_Name { get; set; }

        public bool Authorized { get; set; }
    }

    public class UsersDTO
    {
        public string user_name { get; set; }

        public string password { get; set; }
    }

    public class Table6
    {

        public string Records1 { get; set; }
        public string Records2 { get; set; }
        public string Records3 { get; set; }
        public string Records4 { get; set; }
        public string Records5 { get; set; }
        public int RETURN_VALUE { get; set; }
    }
}
