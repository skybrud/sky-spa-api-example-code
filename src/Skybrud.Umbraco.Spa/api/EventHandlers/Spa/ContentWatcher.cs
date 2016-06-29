using System;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace SkybrudSpaExample.EventHandlers.Spa
{
    /// <summary>
    /// Watcher is used for keeping an eye on content-changes and change the ContentChangeGuid property. 
    /// When the application changes the ContentChangeGuid-property, the NG-app will take over and clear the navigation-cache
    /// </summary>
    internal class ContentWatcher
    {

        public ContentWatcher() {
            ContentService.Published += ContentService_Published;
        }

        private void ContentService_Published(IPublishingStrategy sender, PublishEventArgs<IContent> e) {
            // Change ContentChangesGuid
            OnChange();
        }


        private void OnChange() {
            Startup.ContentChangesGuid = Guid.NewGuid();    // sets new guid to handle cacheinvalidation in sky-spa (NG app)
        }
    }
}
