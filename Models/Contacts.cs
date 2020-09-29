using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Models
{
 
    public class Contacts // Model class that represent a database table for saving contacts
    {
        // creating a unique key
        [Key]
        public int CID { get; set; } // contact id
        [Required]
        [DisplayName("First Name")]
        public string FName { get; set; } // Person's First name
        [Required]
        [DisplayName("Last Name")]
        public string LName { get; set; } // person's last name
        [Required]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)] // person's email address
        public string Email { get; set; }
        [Required]
        [DisplayName("Mobile No")]
        public string Cell { get; set; } // person's mobile no
        [DisplayName("Facebook Id Link")]
        public string Facebook { get; set; } // person's facebook id option
        [Required]
        [DisplayName("Residence Address")]
        public string PermanentAddress { get; set; } // permanent address of the person


    }
}
