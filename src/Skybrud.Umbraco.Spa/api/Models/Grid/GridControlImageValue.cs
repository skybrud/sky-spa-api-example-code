using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Extensions.Json;
using Skybrud.Umbraco.GridData.Interfaces;
using SkybrudSpaExample.Models.Media;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace SkybrudSpaExample.Models.Grid
{
    public class GridControlImageValue : IGridControlValue
    {
        #region Properties

        [JsonIgnore]
        public JObject JObject { get; private set; }

        [JsonProperty("url")]
        public string Url { get; private set; }

        [JsonProperty("altText")]
        public string AltText { get; private set; }

        [JsonIgnore]
        public MediaItem Image { get; private set; }

        [JsonIgnore]
        public GridControl Control { get; private set; }

        #endregion

        public static GridControlImageValue Parse(GridControl control, JToken token)
        {
            return Parse(control, token as JObject);
        }

        public static GridControlImageValue Parse(GridControl control, JObject obj)
        {
            if (obj == null) return null;

            IPublishedContent m = UmbracoContext.Current.MediaCache.GetById(obj.GetInt32("id"));

            // Parse the JSON value
            var value = new GridControlImageValue
            {
                JObject = obj,
                Url = m != null
                    ? m.GetCropUrl(Convert.ToInt32(m.GetPropertyValue<string>("umbracoWidth")),
                        Convert.ToInt32(m.GetPropertyValue<string>("umbracoheight")),
                        imageCropMode: ImageCropMode.Crop, preferFocalPoint: true)
                    : null,
                AltText = obj.GetString("description")
            };

            return value;
        }
    }
}
