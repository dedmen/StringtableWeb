using Blazor.FileReader;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace StringtableWeb.Client {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddFileReaderService();
        }

        public void Configure(IComponentsApplicationBuilder app) {
            app.AddComponent<App>("app");
        }
    }
}

//Debugging
//dotnet run --configuration Debug --project .\StringtableWeb.Server\StringtableWeb.Server.csproj
//Open in chrome
//press SHIFT+ALT+D

