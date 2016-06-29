using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SkybrudSpaExample.Extensions {
    public static class HtmlHelperExtensions {
        public static string GetCacheableUrl(this HtmlHelper helper, string url) {
            return GetCacheableUrl(url);
        }

        public static string GetCacheableUrl<T>(this HtmlHelper<T> helper, string url) {
            return GetCacheableUrl(url);
        }

        public static string GetCacheableUrl(string url) {
            if (String.IsNullOrWhiteSpace(url)) return "";
            if (url.StartsWith("/") && !url.StartsWith("//")) {
                var file = new FileInfo(HttpContext.Current.Server.MapPath("~" + url));
                if (file.Exists) {
                    long ticks = file.LastWriteTimeUtc.Ticks;
                    return url + (url.Contains("?") ? "&" : "?") + ticks;
                }
                return url;
            }
            return url;
        }
    }
}