﻿using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class DirectoryViewModel: PageViewModel
    {
        public Directory Directory { get; set; }
        public List<MateriaViewlModel> Materias { get; set; }

    }

    public class DirectoryEditModel: PageEditModel
    {
    }
}