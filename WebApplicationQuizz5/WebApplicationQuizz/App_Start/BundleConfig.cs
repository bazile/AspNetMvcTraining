using System.Web.Optimization;

namespace WebApplicationQuizz
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/css/bundle-all").Include(
                      "~/css/normalize.css",
                      "~/css/main.css",
                      "~/css/form.css"
                      )
                );
        }
    }
}
