﻿using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IMaterialsRepository
    {
        IEnumerable<Material> GetAllMaterials(bool IncludeDirectory = false);

        Material GetMaterialById(int materialId, bool includeDirectory = false);

        void SaveDirectory(Material material);

        void DeleteDirectory(Material material);
    }
}
