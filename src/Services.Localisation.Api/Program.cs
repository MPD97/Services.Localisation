using System.Collections.Generic;
using System.Threading.Tasks;
using Convey;
using Convey.Logging;
using Convey.Secrets.Vault;
using Convey.Types;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Services.Localisation.Application;
using Services.Localisation.Application.Commands;
using Services.Localisation.Application.DTO;
using Services.Localisation.Application.Queries;
using Services.Localisation.Infrastructure;

namespace Services.Localisation.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddConvey()
                    .AddWebApi()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build())
                .Configure(app => app
                    .UseInfrastructure()
                    .UseDispatcherEndpoints(endpoints => endpoints
                        .Get("", ctx => ctx.Response.WriteAsync(ctx.RequestServices.GetService<AppOptions>().Name))
                        .Get<GetLocation, LocationDto>("locations/{locationId}")
                        .Get<GetLocations, IEnumerable<LocationDto>>("locations")
                        .Post<AddLocation>("locations",
                            afterDispatch: (cmd, ctx) => ctx.Response.Created($"locations/{cmd.LocationId}"))))
                .UseLogging();
    }
}