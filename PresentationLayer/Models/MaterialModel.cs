using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class MateriaViewlModel : PageViewModel
    {
        public Material Material { get; set; }
        public Material NextMaterial { get; set; }
    }
    public class MateriaEditlModel : PageEditModel
    {
        [Required]
        public int DirectoryId { get; set; }
    }
}
