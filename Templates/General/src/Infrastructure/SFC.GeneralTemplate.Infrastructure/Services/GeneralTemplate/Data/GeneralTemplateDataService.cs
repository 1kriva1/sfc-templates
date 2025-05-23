using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data.Models;

namespace SFC.GeneralTemplate.Infrastructure.Services.GeneralTemplate.Data;
public class GeneralTemplateDataService() : IGeneralTemplateDataService
{
    public Task<GetAllGeneralTemplateDataModel> GetAllGeneralTemplateDataAsync()
    {
        return Task.FromResult(new GetAllGeneralTemplateDataModel() { });
    }
}
