using System;
using System.Linq;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace SkybrudSpaExample.Models.Spa
{

    /// <summary>
    /// Master model is used for inherit properties which is used in the SPA-app (frontend)
    /// </summary>
    public class Master
    {
        #region Properties

        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonIgnore]
        public IPublishedContent Content { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("url")]
        public string Url { get; private set; }

        [JsonProperty("contentChangesGuid")]
        public Guid ContentChangesGuid { get; set; }

        [JsonProperty("JsChangesGuid")]
        public Guid JsChangesGuid { get; set; }

        [JsonProperty("path")]
        public int[] Path { get; private set; }

        [JsonProperty("templatename")]
        public string Templatename { get; private set; }

        [JsonProperty("created")]
        public DateTime Created { get; private set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; private set; }
        
        #endregion


        #region Constructors

        public Master(IPublishedContent content)
        {
            Id = content.Id;

            Content = content;

            Name = content.Name;

            Url = content.Url;

            Path = content.Path.Split(',').Select(x => Convert.ToInt32(x)).Skip(1).ToArray();
            Templatename = content.GetTemplateAlias() + ".html";
            Created = content.CreateDate;
            Updated = content.UpdateDate;
            ContentChangesGuid = Startup.ContentChangesGuid;
            JsChangesGuid = Startup.JsChangesGuid;
        }


        #endregion

    }
}
