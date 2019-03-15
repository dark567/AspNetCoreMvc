using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System.Linq;

namespace PresentationLayer.Services
{
    public class MaterialService
    {
        private DataManager dataManager;

        public MaterialService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public MaterialViewlModel MaterialDBModelToView(int materialId)
        {
            var _model = new MaterialViewlModel()
            {
                Material = dataManager.Materials.GetMaterialById(materialId),
            };

            var _dir = dataManager.Directorys.GetDirectoryById(_model.Material.DirectoryID, true);

            if (_dir.Materials.IndexOf(_dir.Materials.FirstOrDefault(x => x.Id == _model.Material.Id)) != _dir.Materials.Count() - 1)
            {
                _model.NextMaterial = _dir.Materials.ElementAt(_dir.Materials.IndexOf(_dir.Materials.FirstOrDefault(x => x.Id == _model.Material.Id)) + 1);
            }
            return _model;
        }

        public MaterialEditlModel GetMaterialEditModel(int materialId)
        {
            var _dbModel = dataManager.Materials.GetMaterialById(materialId);
            var _editModel = new MaterialEditlModel()
            {
                Id=_dbModel.Id,
                DirectoryId = _dbModel.DirectoryID,
                Title = _dbModel.Title,
                Html = _dbModel.Html

            };
            return _editModel;
        }

        public MaterialViewlModel SaveMaterialEditModelToDb(MaterialEditlModel editModel)
        {
            Material material;
            if (editModel.Id != 0)
            {
                material = dataManager.Materials.GetMaterialById(editModel.Id);
            }
            else
            {
                material = new Material();
            }
            material.Title = editModel.Title;
            material.Html = editModel.Html;
            material.DirectoryID = editModel.DirectoryId;
            dataManager.Materials.SaveMaterial(material);
            return MaterialDBModelToView(material.Id);
            
        }



    }
}
