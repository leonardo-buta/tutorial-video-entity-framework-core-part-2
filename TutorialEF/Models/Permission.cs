using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialEF.Models
{
    [Table("Permissions")]
    public class Permission
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string Name { get; set; }

        public List<User> User { get; set; }
    }
}
