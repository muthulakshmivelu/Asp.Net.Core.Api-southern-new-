using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataModel.Models.orders
{
    public class orders
    {
        
        public int orderid {get; set;}


        
        public int customerid { get; set;}

        
        public DateTime  orderdate {  get; set;} = DateTime.UtcNow;
    }


    public class orderitemdetails
    {
     
        public int orderid { get; set; }
   
        public int bookid { get; set; }

        
        public int quantity { get; set; }

        
        public decimal unitprice { get; set; }

        
        public decimal total { get; set; }
    }
}
