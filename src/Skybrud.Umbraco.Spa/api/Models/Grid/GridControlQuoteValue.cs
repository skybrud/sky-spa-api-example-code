using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Extensions.Json;
using Skybrud.Umbraco.GridData.Interfaces;

namespace SkybrudSpaExample.Models.Grid
{
    public class GridControlQuoteValue : IGridControlValue
    {
        #region Properties

        [JsonIgnore]
        public JObject JObject { get; private set; }

        [JsonIgnore]
        public GridControl Control { get; private set; }

        [JsonProperty("quote")]
        public string Quote { get; private set; }

        #endregion


        #region Static methods

        public static GridControlQuoteValue Parse(JToken token)
        {
            return Parse(token as JObject);
        }

        public static GridControlQuoteValue Parse(JObject obj)
        {
            if (obj == null) return null;

            return new GridControlQuoteValue
            {
                Quote = obj.GetString("quote"),
            };
        }

        #endregion
    }
}
