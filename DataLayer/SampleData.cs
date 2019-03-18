using DataLayer.Entityes;
using System.Linq;

namespace DataLayer
{
    public static class SampleData
    {
        /// <summary>
        /// заполнение БД
        /// </summary>
        /// <param name="context"></param>
        public static void InitData(EFDBContext context)
        {
            if (!context.Directory.Any())
            {
                context.Directory.Add(new Directory() { Title = "First Directory", Html = "<b>Directory content</b>" });
                context.Directory.Add(new Directory() { Title = "Second Directory", Html = "<b>Directory content</b>" });
                context.Directory.Add(new Directory() { Title = "Third Directory", Html = "<b>Directory content</b>" });

                context.SaveChanges(); //save all changes

                context.Material.Add(new Material() { Title = "First Material", Html = "<i>Material content</i>", DirectoryID = context.Directory.First().Id });
                context.Material.Add(new Material() { Title = "Second Material", Html = "<i>Material content</i>", DirectoryID = context.Directory.First().Id + 1 });
                context.Material.Add(new Material() { Title = "Third Material", Html = "<i>Material content</i>", DirectoryID = context.Directory.Last().Id });

                context.SaveChanges(); //save all changes
            }
        }
    }
}
