using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class DirectoryService
    {
        private DataManager _dataManager;
        private MaterialService _materialService;

        public DirectoryService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public List<DirectoryViewModel> GetDirectoryList()
        {
            var _dirs = dataManager.Directorys.GetAllDirectorys();
            List<DirectoryViewModel> _modelList = new List<DirectoryViewModel>();
            foreach (var item in _dirs)
            {
                _modelList.Add(DirectoryDBViewModelById(item.Id));
            }
            return _modelList;
        }

        public DirectoryViewModel DirectoryDBViewModelById(int directoryId)
        {
            var _directory = dataManager.Directorys.GetDirectoryById(directoryId, true);

            List<MateriaViewlModel> _materialsViewModel = new List<MateriaViewlModel>();
            foreach (var item in _directory.Materials)
            {
                _materialsViewModel.Add(_materialService.MaterialDBModelToView(item.Id));
            }

            return new DirectoryViewModel() { Directory = _directory, Materias = _materialsViewModel };
        }

        public DirectoryEditModel GetDirectoryEditModel(int directoryId = 0)
        {
            if (directoryId != 0)
            {
                var _dirDb = _dataManager.Directorys.GetDirectoryById(directoryId);
                var _dirEditModel = new DirectoryEditModel(){
                    Id = _dirDb.Id,
                    Title = _dirDb.Title,
                    Html = _dirDb.Html
                };

                return _dirEditModel;
            }
            else
                return new DirectoryEditModel() { }; 
        }

        public DirectoryViewModel SaveDirectoryEditModelToDb(DirectoryEditModel directoryEditModel)
        {
            Directory _directoryDbModel;
            if (directoryEditModel.Id != 0)
            {
                _directoryDbModel = dataManager.Directorys.GetDirectoryById(directoryEditModel.Id);
            }
            else
            {
                _directoryDbModel = new Directory();
            }

            _directoryDbModel.Title = directoryEditModel.Title;
            _directoryDbModel.Html = directoryEditModel.Html;

            return DirectoryDBViewModelById(_directoryDbModel.Id);

        }
    }
}
