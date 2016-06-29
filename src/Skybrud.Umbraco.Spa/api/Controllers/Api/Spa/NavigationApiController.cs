using System;
using System.Linq;
using System.Web;
using Skybrud.WebApi.Json;
using Skybrud.WebApi.Json.Meta;
using SkybrudSpaExample.Models.Spa;
using Umbraco.Web.WebApi;

namespace SkybrudSpaExample.Controllers.Api.Spa
{
    [JsonOnlyConfiguration]
    public class NavigationApiController : UmbracoApiController
    {
        /// <summary>
        /// API Endpoint to handle navigation
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="levels"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public object GetPageTree(int nodeId, int levels = 1){
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            
            return Request.CreateResponse(JsonMetaResponse.GetSuccess(NavItem.GetItem(UmbracoContext.ContentCache.GetById(nodeId), levels)));
        }

        /// <summary>
        /// API Endpoint to return an array og navigationitems.
        /// Ex. could be used to render a mntp property
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="levels"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public object GetByIds(string ids, int levels = 1){
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            int[] idArr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray();

            return Request.CreateResponse(JsonMetaResponse.GetSuccess(NavItem.GetItems(idArr, levels)));
        }
    }
}
