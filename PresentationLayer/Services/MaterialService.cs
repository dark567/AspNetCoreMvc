using BuissnesLayer;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Services
{
    public class MaterialService
    {
        private DataManager dataManager;

        public MaterialService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public MateriaViewlModel MaterialDBModelToView(int materialId)
        {
            var _model = new MateriaViewlModel()
            {
                Material = dataManager.Materials.GetMaterialById(materialId, true),
            };

            var _dir = dataManager.Directorys.GetDirectoryById(_model.Material.DirectoryID);

            if (_dir.Materials.IndexOf(_model.Material) != _dir.Materials.Count())
            {
                _model.NextMaterial = _dir.Materials.ElementAt(_dir.Materials.IndexOf(_model.Material) + 1);
            }

            return _model;
        }



    }
}
