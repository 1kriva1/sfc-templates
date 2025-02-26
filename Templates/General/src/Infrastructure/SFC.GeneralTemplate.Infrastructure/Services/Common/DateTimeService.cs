using SFC.GeneralTemplate.Application.Interfaces.Common;

namespace SFC.GeneralTemplate.Infrastructure.Services.Common;
public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;

    public DateTime DateNow => DateTime.UtcNow.Date;
}
