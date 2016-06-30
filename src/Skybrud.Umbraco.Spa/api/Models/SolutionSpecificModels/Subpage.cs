using Newtonsoft.Json;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Extensions;
using SkybrudSpaExample.Grid.Spa;
using SkybrudSpaExample.Models.Spa;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace SkybrudSpaExample.Models.SolutionSpecificModels
{
    public class Subpage : Master
    {
        #region Properties

        [JsonProperty("grid")]
        [JsonConverter(typeof(SpaGridJsonConverter))]
        public GridDataModel Grid { get; private set; }

        [JsonProperty("customFieldExample")]
        public string CustomFieldExample { get; private set; }

        #endregion


        #region Constructors

        public Subpage(IPublishedContent content) : base(content) {
            Grid = content.GetGridModel("gridPropertyAlias");
            CustomFieldExample = content.GetPropertyValue<string>("customFieldPropertyAlias");
        }

        #endregion


        #region Statics 

        public static Subpage GetFromContent(IPublishedContent content) {

            if (content == null) return null;

            return new Subpage(content);
        }

        #endregion
    }
}
