using PermissionManagement.MVC.Controllers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionManagement.MVC.Models
{
    public class Pet
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Status? Status { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public Size? Size { get; set; }
        public virtual AdoptionCenter AdoptionCenter { get; set; }
        [NotMapped]
        public List<AdoptionCenter> Centers { get; set; }
    }
    public enum Status
    {
        Pendiente,
        Revision,
        Adoptado
    }
    public enum Size
    {
        Pequeno,Mediano,Grande
    }
}
