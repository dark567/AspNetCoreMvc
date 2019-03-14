using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class MaterialViewlModel : PageViewModel
    {
        public Material Material { get; set; }
        public Material NextMaterial { get; set; }
    }
    public class MaterialEditlModel : PageEditModel
    {
        [Required]
        public int DirectoryId { get; set; }
    }
}
