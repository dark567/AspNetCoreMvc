﻿using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuissnesLayer.Implemetations
{
    public class EFMaterialsRepository : IMaterialsRepository
    {
        private EFDBContext context;
        public EFMaterialsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Material> GetAllMaterials(bool IncludeDirectory = false)
        {
            if (IncludeDirectory)
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().ToList();
            else
                return context.Material.ToList();
        }

        public Material GetMaterialById(int materialId, bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().FirstOrDefault(x => x.Id == materialId);
            else
                return context.Material.FirstOrDefault(x => x.Id == materialId);
        }

        public void SaveDirectory(Material material)
        {
            if (material.Id == 0)
                context.Material.Add(material);
            else
                context.Entry(material).State = EntityState.Modified;
        }

        public void DeleteDirectory(Material material)
        {
            context.Material.Remove(material);
            context.SaveChanges();
        }
    }
}
