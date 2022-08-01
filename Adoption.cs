using Microsoft.AspNetCore.Identity;
using PermissionManagement.MVC.Controllers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionManagement.MVC.Models
{
    public class Adoption
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Status? Status { get; set; }
        public string Name { get; set; }
        public virtual Pet Pet{ get; set; }
        public string AdoptingUser { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
