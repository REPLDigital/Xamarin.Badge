using Android.Content;

namespace Badge.Plugin
{
    /**
	 * Abstract class created to be implemented by different classes to provide badge change support on
	 * different launchers.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Jake Henning
	 */

    public class BadgeProvider
    {
        /// <summary>
        /// Badge provider context
        /// </summary>
        protected Context Context;

        /// <summary>
        /// Get package name
        /// </summary>
        protected string PackageName { get { return Context.PackageName; } }

        /// <summary>
        /// Get main activity class name
        /// </summary>
        protected string MainActivityClassName { get { return Context.PackageManager.GetLaunchIntentForPackage(PackageName).Component.ClassName; } }

        protected const string AndroidIntentAction = "android.intent.action";

        /// <summary>
        /// Badge provider constructor
        /// </summary>
        public BadgeProvider(Context context)
        {
            Context = context;
        }

        /// <summary>
        /// Virtual set badge
        /// </summary>
        public virtual void SetBadge(int count)
        {
        }

        /// <summary>
        /// Virtual remove badge
        /// </summary>
        public virtual void RemoveBadge()
        {
        }
    }
}