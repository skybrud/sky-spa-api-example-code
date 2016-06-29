using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData.Extensions.Json;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace SkybrudSpaExample.Models.Media
{
    public class MediaItem
    {
        #region Properties

        [JsonIgnore]
        public IPublishedContent Content { get; private set; }

        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("backofficePreviewUrl")]
        public string BackOfficePreviewUrl { get; private set; }

        #endregion

        #region Static Methods
        public static MediaItem GetFromContent(IPublishedContent content)
        {
            if (content == null) return null;

            return new MediaItem
            {
                Content = content,
                BackOfficePreviewUrl = content.GetCropUrl(266, 173, imageCropMode: ImageCropMode.Crop, preferFocalPoint: true),
                Id = content.Id

            };
        }

        public static MediaItem Parse(JObject obj)
        {
            if (obj == null) return null;

            int mediaId = obj.GetInt32("id");

            if (mediaId == 0) return null;

            var media = UmbracoContext.Current == null ? null : UmbracoContext.Current.MediaCache.GetById(mediaId);

            if (media == null) return null;

            return GetFromContent(media);
        }

        #endregion
    }
}
