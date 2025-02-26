using SFC.GeneralTemplate.Api.Infrastructure.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder
       .ConfigureServices()
       .ConfigurePipeline();

app.Run();

public partial class Program { }
