using PermissionManagement.MVC.Controllers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionManagement.MVC.Models
{
    public class AdoptionCenter
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
