using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data.Models;

namespace SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data;
public interface IGeneralTemplateDataService
{
    Task<GetAllGeneralTemplateDataModel> GetAllGeneralTemplateDataAsync();
}
