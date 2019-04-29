using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Tools;

namespace DInTaskSchedulerApi.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public async Task<IList<ApplicationViewModel>> Get()
        {
            IList<ApplicationViewModel> result;
            try
            {
                result = await Task.FromResult(applicationRepository.Get().Select(e => ModelFormatter.FormatApplicationModel(e)).ToList());
            }
            catch
            {
                result = new List<ApplicationViewModel>();
            }
            return result;
        }

        public async Task<IList<ApplicationViewModel>> GetActive()
        {
            IList<ApplicationViewModel> result;
            try
            {
                result = await Task.FromResult(applicationRepository.GetActive().Select(e => ModelFormatter.FormatApplicationModel(e)).ToList());
            }
            catch
            {
                result = new List<ApplicationViewModel>();
            }
            return result;
        }

        public async Task<ApplicationViewModel> GetById(int id)
        {
            ApplicationViewModel result;
            try
            {
                var item = await Task.FromResult(applicationRepository.GetById(id));
                if (item != null)
                    result = ModelFormatter.FormatApplicationModel(item);
                else
                    result = new ApplicationViewModel();
            }
            catch
            {
                result = new ApplicationViewModel();
            }
            return result;
        }

        public async Task<ServerResponse> Save(SaveApplicationViewModel model)
        {
            ServerResponse result;
            try
            {
                model.Id = 0;
                var entity = ModelFormatter.FormatApplicationModel(model);
                entity = await applicationRepository.Save(entity);
                result = Utils.SuccessResponse(entity.Id);
            }
            catch (Exception ex)
            {
                result = Utils.ErrorResponse(ex.ToString());
            }
            return result;
        }

        public async Task<ServerResponse> Update(SaveApplicationViewModel model)
        {
            ServerResponse result;
            try
            {
                var entity = applicationRepository.GetById(model.Id);

                if (entity == null)
                    result = Utils.ErrorResponse(Constants.NOT_FOUND, model.Id);
                else
                {
                    entity = ModelFormatter.FormatApplicationModel(model, entity);
                    entity = await applicationRepository.Update(entity);
                    result = Utils.SuccessResponse(entity.Id);
                }
            }
            catch (Exception ex)
            {
                result = Utils.ErrorResponse(ex.ToString());
            }
            return result;
        }
    }
}
