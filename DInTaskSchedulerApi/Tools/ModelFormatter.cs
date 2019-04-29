using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Infrastructure.DataContext;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Class used to cast database models to viewmodels and viewmodels to models too
    /// </summary>
    public static class ModelFormatter
    {
        /// <summary>
        /// Format Status model to CatalogViewModel
        /// </summary>
        public static CatalogViewModel FormatStatusCatalogModel(Status model)
        {
            return new CatalogViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                KeyCode = string.Empty
            };
        }

        /// <summary>
        /// Format Environment model to CatalogViewModel
        /// </summary>
        public static CatalogViewModel FormatEnvironmentCatalogModel(Environment model)
        {
            return new CatalogViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                KeyCode = string.Empty
            };
        }

        /// <summary>
        /// Format Application model to ApplicationViewModel
        /// </summary>
        public static ApplicationViewModel FormatApplicationModel(Infrastructure.DataContext.Application model)
        {
            return new ApplicationViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                CreatedDate = model.CreatedDate,
                LastUpdatedDate = model.LastUpdatedDate,
                Status = model.IdStatusNavigation != null ? FormatStatusCatalogModel(model.IdStatusNavigation) : null
            };
        }

        /// <summary>
        /// Format ApplicationViewModel to Application model
        /// </summary>
        public static Infrastructure.DataContext.Application FormatApplicationModel(SaveApplicationViewModel model, Infrastructure.DataContext.Application modelDB = null)
        {
            if (modelDB == null)
            {
                modelDB = new Infrastructure.DataContext.Application()
                {
                    Id = model.Id,
                    Name = model.Name,
                    CreatedDate = Utils.GetCurrentDateTime(),
                    LastUpdatedDate = Utils.GetCurrentDateTime(),
                    IdStatus = model.IdStatus
                };
            }
            else
            {
                modelDB.Name = model.Name;
                modelDB.LastUpdatedDate = Utils.GetCurrentDateTime();
                modelDB.IdStatus = model.IdStatus;
            }

            return modelDB;
        }

        /// <summary>
        /// Format Frequency model to CatalogViewModel
        /// </summary>
        public static CatalogViewModel FormatFrequencyCatalogModel(Frequency model)
        {
            return new CatalogViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                KeyCode = string.Empty
            };
        }

        /// <summary>
        /// Format ParameterType model to CatalogViewModel
        /// </summary>
        public static CatalogViewModel FormatParameterTypeCatalogModel(ParameterType model)
        {
            return new CatalogViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                KeyCode = string.Empty
            };
        }
    }
}
