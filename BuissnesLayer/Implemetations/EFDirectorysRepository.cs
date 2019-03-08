using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetations
{
    public class EFDirectorysRepository : IDirectorysRepository
    {
        private EFDBContext context;

        public EFDirectorysRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Directory> GetAllDirectorys(bool includeMaterilas = false)
        {
            if (includeMaterilas)
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().ToList();
            else
                return context.Directory.ToList();
        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterilas = false)
        {
            if (includeMaterilas)
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            else
                return context.Directory.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(Directory directory)
        {
            if (directory.Id == 0)
                context.Directory.Add(directory);
            else
                context.Entry(directory).State = EntityState.Modified;
        }

        public void DeleteDirectory(Directory directory)
        {
            context.Directory.Remove(directory);
            context.SaveChanges();
        }
    }
}
