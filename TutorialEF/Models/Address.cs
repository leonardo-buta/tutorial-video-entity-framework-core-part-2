using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialEF.Models
{
    [Table("Adresses")]
    public class Address
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string StreetAddress { get; set; }

        [Required]
        [Column(TypeName = "CHAR(8)")]
        public string ZipCode { get; set; }
    }
}
