using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NorthwindUwp.Activation;
using NorthwindUwp.Core.Helpers;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NorthwindUwp.Services
{
    // For more information on application activation see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/activation.md
    internal class ActivationService
    {
        private readonly App _app;
        private readonly Lazy<UIElement> _shell;
        private readonly Type _defaultNavItem;

        public ActivationService(App app, Type defaultNavItem, Lazy<UIElement> shell = null)
        {
            _app = app;
            _shell = shell;
            _defaultNavItem = defaultNavItem;
        }

        public async Task ActivateAsync(object activationArgs)
        {
            if (IsInteractive(activationArgs))
            {
                // Initialize things like registering background task before the app is loaded
                await InitializeAsync();

                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (Window.Current.Content == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    Window.Current.Content = _shell?.Value ?? new Frame();
                }
            }

            var activationHandler = GetActivationHandlers()
                                                .FirstOrDefault(h => h.CanHandle(activationArgs));

            if (activationHandler != null)
            {
                await activationHandler.HandleAsync(activationArgs);
            }

            if (IsInteractive(activationArgs))
            {
                var defaultHandler = new DefaultLaunchActivationHandler(_defaultNavItem);
                if (defaultHandler.CanHandle(activationArgs))
                {
                    await defaultHandler.HandleAsync(activationArgs);
                }

                // Ensure the current window is active
                Window.Current.Activate();

                // Tasks after activation
                await StartupAsync();
            }
        }

        private async Task InitializeAsync()
        {
            await ThemeSelectorService.InitializeAsync();
        }

        private async Task StartupAsync()
        {
            await ThemeSelectorService.SetRequestedThemeAsync();
            await FirstRunDisplayService.ShowIfAppropriateAsync();
        }

        private IEnumerable<ActivationHandler> GetActivationHandlers()
        {
            yield return Singleton<SuspendAndResumeService>.Instance;
            yield return Singleton<SchemeActivationHandler>.Instance;
        }

        private bool IsInteractive(object args)
        {
            return args is IActivatedEventArgs;
        }
    }
}
