using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkybrudSpaExample.Models.Spa;
using Umbraco.Core.Models;

namespace SkybrudSpaExample.Models.SolutionSpecificModels
{
    public class StartView : Master
    {
        #region properties

        #endregion

        #region constructers

        protected StartView(IPublishedContent content)
            : base(content)
        {
        }

        #endregion

        #region static methods

        public static StartView GetFromContent(IPublishedContent content)
        {
            return content == null ? null : new StartView(content);
        }

        #endregion
    }
}
