using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Models
{
    // model class to store social accounts of the persons
    public class Social
    {
        [Key]
        public int SId { get; set; }
        // name of the person having all these accounts
        [DisplayName("Person Name")]
        public string Name { get; set; }
        [DisplayName("Instagram ID")]
       
        // insta account
        public string InstagramId { get; set; }
        // facebook account
        [DisplayName("Facebook ID")]
        public string FacebookId { get; set; }
        // whatsapp number of the person
        [DisplayName("Whatsapp Number")]
        public string WhatsappNumber { get; set; }
    }
}
