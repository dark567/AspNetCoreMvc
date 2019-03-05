using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entityes
{
    public class Material : Page
    {
        public int DirectoryID { get; set; } // foreign key
        public Directory Directory { get; set; } //navigation property
    }
}
