using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.DataModel.Models.ManPower
{
    public class Manpowerentity
    {
        public int manpower_id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string date_of_birth { get; set; }
        public int age { get; set; }
        public string mobile { get; set; }
        public string alternate_number { get; set; }
        public string marital_status { get; set; }
        public string current_address { get; set; }
        public string permenant_address { get; set; }
        public int city { get; set; }
        public int state { get; set; }
        public string job_type { get; set; }
        public string date_of_join { get; set; }
        public int designation { get; set; }
        public string reference_by { get; set; }
        public string previous_company { get; set; }
        public string reference_contact1 { get; set; }
        public string reference_contact2 { get; set; }
        public string total_experiance { get; set; }
        public int active { get; set; }
        public string photo { get; set; }
        public int verfication_status { get; set; }
        public string assign_type { get; set; }
        public int company { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public int payment_mode { get; set; }
        public string blood_group { get; set; }
        public int created_by { get; set; }
        
    }

    public class ManPowerDetailsEnitityId
    {
        public int manpower_id { get; set; }
        public int entered_by { get; set; }
        public bool cancel_flag { get; set; }
    }
    public class GetManPowerDetails
    {
        public int manpower_id { get; set; }
        public bool active { get; set; }
    }
}



