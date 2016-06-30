using SkybrudSpaExample.Models.Spa;
using Umbraco.Core.Models;

namespace SkybrudSpaExample.Models.SolutionSpecificModels
{
    public class Frontpage : Master
    {
        #region Properties

        #endregion


        #region Constructors

        public Frontpage(IPublishedContent content) : base(content) { }

        #endregion


        #region Statics 

        public static Frontpage GetFromContent(IPublishedContent content)
        {

            if (content == null) return null;

            return new Frontpage(content);
        }

        #endregion
    }
}
