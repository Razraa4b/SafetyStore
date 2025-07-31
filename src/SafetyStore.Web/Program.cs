using Microsoft.AspNetCore.StaticFiles;

namespace SafetyStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            IMvcBuilder mvcBuilder = builder.Services.AddControllersWithViews();
            if (builder.Environment.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }

            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler();
            }

            app.UseHsts();
            app.UseHttpsRedirection();

            StaticFileOptions staticFileOptions = new StaticFileOptions();
            // Add .glb extension with necessary MIME type
            var contentTypeProvider = new FileExtensionContentTypeProvider();
            contentTypeProvider.Mappings[".glb"] = "model/gltf-buffer";

            staticFileOptions.ContentTypeProvider = contentTypeProvider;
            app.UseStaticFiles(staticFileOptions);

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
