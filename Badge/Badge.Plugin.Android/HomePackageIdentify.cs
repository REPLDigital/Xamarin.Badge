using Android.Content;
using Android.Content.PM;

namespace Badge.Plugin
{
    /**
	 * Helper to identify the package of current home launcher running
	 *
	 * Created by Arturo Gutiérrez on 19/12/14.
	 * 
	 * ported to C# by Jake Henning
	 */
    public class HomePackageIdentify
    {
        /// <summary>
        /// Get home package
        /// </summary>
        public string GetHomePackage(Context context)
        {
            var intent = new Intent(Intent.ActionMain);
            intent.AddCategory(Intent.CategoryHome);

            var resolveInfo = context.PackageManager.ResolveActivity(intent, PackageInfoFlags.MatchDefaultOnly);

            if (resolveInfo != null
                && resolveInfo.ActivityInfo != null
                && resolveInfo.ActivityInfo.PackageName != null)
            {
                return resolveInfo.ActivityInfo.PackageName;
            }

            return context.PackageName;
        }
    }
}