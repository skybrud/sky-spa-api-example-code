using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Interfaces;
using Skybrud.Umbraco.GridData.Rendering;
using SkybrudSpaExample.Models.Grid;

namespace SkybrudSpaExample.Grid
{
    public class SolutionSpecificGridConverter : IGridConverter
    {
        public bool ConvertControlValue(GridControl control, JToken token, out IGridControlValue value)
        {
            value = null;

            switch (control.Editor.Alias)
            {
                case "citat":
                    value = GridControlQuoteValue.Parse(token as JObject);
                    break;

                case "image":
                    value = GridControlImageValue.Parse(control, token as JObject);
                    break;

                //case "video":
                //    value = GridControlVideoValue.Parse(control, token as JObject);
                //    break;

                //case "gallery":
                //    value = GridControlGalleryValue.Parse(control, token as JObject);
                //    break;

                //case "folderview":
                //    value = GridControlFolderviewValue.Parse(token as JObject);
                //    break;

                //case "instagram":
                //    value = GridControlInstagramValue.Parse(token as JObject);
                //    break;
            }

            return value != null;
        }

        public bool ConvertEditorConfig(GridEditor editor, JToken token, out IGridEditorConfig config)
        {
            config = null;
            return false;
        }

        public bool GetControlWrapper(GridControl control, out GridControlWrapper wrapper)
        {
            wrapper = null;
            
            return false;
        }
    }
}
