using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace SkybrudSpaExample.Models.Spa {

    /// <summary>
    /// Class used for navigation
    /// </summary>
    public class NavItem {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("url")]
        public string Url { get; private set; }

        [JsonProperty("parentId")]
        public int ParentId { get; private set; }

        [JsonProperty("hasChildren")]
        public bool HasChildren { get; private set; }

        [JsonProperty("children")]
        public IEnumerable<NavItem> Children { get; private set; }


        public static NavItem GetItem(IPublishedContent content, int levels = 1, int levelcount = 1) {
            IPublishedContent[] children = content.Children(x => x.TemplateId > 0).ToArray();

            return new NavItem {
                Id = content.Id,
                Name = content.Name,
                Url = content.Url,
                ParentId = content.Parent != null ? content.Parent.Id : -1,
                HasChildren = children.Any(),
                Children = children.Any() && levels > levelcount ? GetItems(children, levels, levelcount) : null
            };
        }


        public static IEnumerable<NavItem> GetItems(IEnumerable<IPublishedContent> content, int levels = 1,
            int levelcount = 1) {
            if (content == null) return null;

            levelcount++;

            return content.Select(x => GetItem(x, levels, levelcount));
        }

        public static IEnumerable<NavItem> GetItems(int[] ids, int levels = 1, int levelcount = 1) {
            if (ids.Length == 0) return null;

            return
                ids.Select(x => UmbracoContext.Current.ContentCache.GetById(x))
                    .Where(x => x != null)
                    .Select(x => GetItem(x, levels, levelcount));
        }
    }
}