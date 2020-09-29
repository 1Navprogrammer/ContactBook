using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ContactBook.Models
{
    public class PersonBio
    {
        // Some bio of the contact person
        [Key] // making PBID a unique key
        public int PBID { get; set; }
        // full name of the person
        public string FullName { get; set; }
        // comma separated hobbies of the person
        public string Hobbies { get; set; }
        // bloodgroup of the pserson
        public string Bloodgroup { get; set; }
    }
}
