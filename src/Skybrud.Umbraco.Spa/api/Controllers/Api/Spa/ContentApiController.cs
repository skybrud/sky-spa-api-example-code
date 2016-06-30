using System.Net;
using System.Web;
using Skybrud.WebApi.Json;
using Skybrud.WebApi.Json.Meta;
using SkybrudSpaExample.Extensions;
using SkybrudSpaExample.Models.SolutionSpecificModels;
using Umbraco.Core.Models;
using Umbraco.Web.WebApi;

namespace SkybrudSpaExample.Controllers.Api.Spa
{
    [JsonOnlyConfiguration]
    public class ContentApiController : UmbracoApiController
    {
        [System.Web.Http.HttpGet]
        public object GetContent(string url)
        {
            // Allow request from other domains (schould be removed in production)
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            url = HttpUtility.UrlDecode(url);
            IPublishedContent content;
            
            if (url.IsPreviewUrl())
            {
                // get draft content
                content = UmbracoContext.ContentCache.GetById(true, url.GetPreviewId());
            }
            else
            {
                var urlName = url == "/"
                    ? "/home"   // or find another way to find the frontpage of the page
                    : url;

                // find content by url. If non found return 404
                content = !string.IsNullOrEmpty(urlName)
                    ? UmbracoContext.ContentCache.GetByRoute(urlName)  // if multisite solution, set mainnodeid as prefix for the urlName. Ex. (2121 + urlName)
                    : null;
            }
            

            if (content == null) return Request.CreateResponse(JsonMetaResponse.GetError(HttpStatusCode.NotFound, "The page was not found"));



            switch (content.DocumentTypeAlias)
            {

                case Constants.DocumentTypes.Frontpage:
                    return Request.CreateResponse(JsonMetaResponse.GetSuccessFromObject(content, Frontpage.GetFromContent));    //map ipublishedcontent to model and return JSON response

                
                case Constants.DocumentTypes.Subpage:
                    return Request.CreateResponse(JsonMetaResponse.GetSuccessFromObject(content, Subpage.GetFromContent));  //map ipublishedcontent to model and return JSON response

                
                //case ....


            }

            //throw error
            return Request.CreateResponse(JsonMetaResponse.GetError(HttpStatusCode.InternalServerError, "An error occurred."));
        }
    }
}
