using Integrify_s_Project.Application.Common.Interfaces;

namespace Integrify_s_Project.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
