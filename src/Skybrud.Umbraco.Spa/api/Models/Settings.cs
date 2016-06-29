using System.Collections.Generic;
using Newtonsoft.Json;
using SkybrudSpaExample.Models.Spa;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace SkybrudSpaExample.Models {

    /// <summary>
    /// Class used for returning settings from your Umbraco-setup
    /// This one i customised for the Fanoe-startup, but you could make your own
    /// </summary>
    public class Settings {
        [JsonProperty("sitename")]
        public string Sitename { get; private set; }

        [JsonProperty("siteRootId")]
        public int SiteRootId { get; private set; }

        [JsonProperty("siteDescription")]
        public string SiteDescription { get; private set; }

        [JsonProperty("siteLogoUrl")]
        public string SiteLogoUrl { get; private set; }

        
        public static Settings GetFromContent(IPublishedContent content, Settings model) {
            return new Settings {
                Sitename = content.GetPropertyValue<string>("siteTitle"),
                SiteRootId = content.Id,
                SiteDescription = content.GetPropertyValue<string>("siteDescription"),
                SiteLogoUrl = content.GetPropertyValue<string>("siteLogo")
            };
        }
    }
}