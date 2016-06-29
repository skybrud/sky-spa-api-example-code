using System;
using System.IO;

namespace SkybrudSpaExample.EventHandlers.Spa
{
    /// <summary>
    /// Watcher is used for keeping an eye on js-changes and change the JsChangeGuid property. 
    /// These will require a reload of the application, which the frontend-application will handle when you change the JsChangesGuid.
    /// </summary>
    internal class AssetsWatcher{
        private FileSystemWatcher _watcher;

        public AssetsWatcher(){
            _watcher = new FileSystemWatcher();
            _watcher.Path = System.Web.HttpContext.Current.Server.MapPath("~/scripts/");    //folder containing you NG-app
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Filter = "*.js";
            _watcher.Changed += new FileSystemEventHandler(OnChanged);
            _watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e){
            Startup.JsChangesGuid = Guid.NewGuid();
        }
    }
}
