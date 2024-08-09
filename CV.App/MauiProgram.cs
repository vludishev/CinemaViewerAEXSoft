using CommunityToolkit.Maui;
using CV.App.Mapper;
using CV.App.Pages;
using CV.App.Services;
using CV.App.ViewModels;
using CV.Infrastructure;
using CV.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CV.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            //builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement();

#if IOS

            Microsoft.Maui.Handlers.ScrollViewHandler.Mapper.AppendToMapping(nameof(IScrollView.ContentSize), (h, v) =>
                {
                    var contentSize = h.VirtualView.ContentSize;

                    if (contentSize.IsZero)
                        return;

                    UIKit.UIScrollView uiScrollView = h.PlatformView;
                    var container = uiScrollView.Subviews.FirstOrDefault(x => x.Tag == 0x845fed);

                    if (container != null && container.Bounds.Height != contentSize.Height)
                    {
                        container.Bounds = new CoreGraphics.CGRect(
                            container.Bounds.X,
                            container.Bounds.Y,
                            contentSize.Width,
                            contentSize.Height);

                        (h.VirtualView as IView).InvalidateMeasure();
                    }
                });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var services = builder.Services;
            var configuration = builder.Configuration;

            var appConfig = ConfigurationHelper.LoadConfiguration();
            configuration.AddConfiguration(appConfig);

            services.AddInfrastructureServices(configuration);

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
                initializer.Initialise();
                initializer.Seed();
            }

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<IFilmsService, FilmsService>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<SearchViewModel>();
            mauiAppBuilder.Services.AddSingleton<FilmDetailViewModel>();
            mauiAppBuilder.Services.AddSingleton<NewsViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<SearchPage>();
            mauiAppBuilder.Services.AddSingleton<FilmDetailPage>();
            mauiAppBuilder.Services.AddSingleton<NewsPage>();

            return mauiAppBuilder;
        }
    }
}
