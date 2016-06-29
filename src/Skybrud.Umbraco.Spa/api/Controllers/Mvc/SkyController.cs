using System.Web.Mvc;
using SkybrudSpaExample.Models.Spa;
using Umbraco.Web.Mvc;

namespace SkybrudSpaExample.Controllers.Mvc {
    public class SkyController : RenderMvcController {
        protected ViewResult View(Master model) {
            return View(null, model);
        }

        protected ViewResult View(string view, Master model) {
            return base.View(view, model);
        }
    }
}