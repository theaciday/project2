using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class User
    {   [Key]
        public int Id { get; set; }
        
        public DateTime DateRegistration { get; set; }
        
        public DateTime DateLastVisit { get; set; }
       
    } 
}
