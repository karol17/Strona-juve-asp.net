using System.Web.Optimization;

namespace juve
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/reset.css",
                      "~/Content/Style.css",
                      "~/Content/bootstrap.css"));
        }
    }
}