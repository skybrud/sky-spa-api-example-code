using System.Net.Http;
using System.Web;
using System.Web.Http;
using Skybrud.WebApi.Json;
using Skybrud.WebApi.Json.Meta;
using SkybrudSpaExample.Models;
using Umbraco.Core.Models;
using Umbraco.Web.WebApi;

namespace SkybrudSpaExample.Controllers.Api.Spa {
    [JsonOnlyConfiguration]
    public class SettingsApiController : UmbracoApiController {

        /// <summary>
        ///     Return settings based on current domain
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetSettings() {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            IDomain domain =
                ApplicationContext.Services.DomainService.GetByName(
                    HttpContext.Current.Request.ServerVariables["SERVER_NAME"]);

            var rootNodeId = (int) domain.RootContentId;

            if (rootNodeId == 0) return "";

            IPublishedContent _settings = UmbracoContext.ContentCache.GetById(rootNodeId);

            return
                Request.CreateResponse<JsonMetaResponse>(
                    JsonMetaResponse.GetSuccess(Settings.GetFromContent(_settings, new Settings())));
        }
    }
}