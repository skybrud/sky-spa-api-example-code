using System;
using Skybrud.Umbraco.GridData;
using SkybrudSpaExample.EventHandlers.Spa;
using SkybrudSpaExample.Grid;
using Umbraco.Core;

namespace SkybrudSpaExample
{
    public class Startup : IApplicationEventHandler
    {
        private static object _lock = new object();
        private static bool _started = false;

        private static AssetsWatcher _assetsWatcher;
        private static ContentWatcher _contentWatcher;

        public static Guid ContentChangesGuid;
        public static Guid JsChangesGuid;


        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            if (_started)
                return;

            lock (_lock)
            {
                if (!_started)
                {
                    _started = true;

                    //Adding Custom GridConverter
                    GridContext.Current.Converters.Add(new SolutionSpecificGridConverter());

                    _assetsWatcher = new AssetsWatcher();       // Watches pt. scripts-folder, to handle any js updates
                    _contentWatcher = new ContentWatcher();     // Wathces if content changes
                    ContentChangesGuid = Guid.NewGuid();        // Sets guid to handle changes in Umbracontent, to update frontend NG-cache
                    JsChangesGuid = Guid.NewGuid();             // Sets guid to handle changes in scripts-folder
                }
            }
        }

        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }
    }
}
