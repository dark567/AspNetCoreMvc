using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IDirectorysRepository
    {
        IEnumerable<Directory> GetAllDirectorys(bool includeMaterilas = false);

        Directory GetDirectoryById(int directoryId, bool includeMaterilas = false);

        void SaveDirectory(Directory directory);

        void DeleteDirectory(Directory directory);
    }
}
