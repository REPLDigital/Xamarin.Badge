using Android.Content;
using Java.Lang;

namespace Badge.Plugin
{
    /**
	 * Helper to set badge count on current application icon on any supported launchers.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Jake Henning
	 */
    public static class Badges
    {
        /**
	     * Set badge count on app icon
	     *
	     * @param context context activity
	     * @param count   should be &gt;= 0, passing count as 0 the badge will be removed.
	     * @throws BadgesNotSupportedException when the current launcher is not supported by Badges
	     */
        public static void SetBadge(Context context, int count)
        {
            if (context == null)
            {
                throw new BadgesNotSupportedException();
            }

            var badgeFactory = new BadgeProviderFactory(context);
            var badgeProvider = badgeFactory.GetBadgeProvider();

            try
            {
                badgeProvider.SetBadge(count);
            }
            catch (UnsupportedOperationException ex)
            {
                throw new BadgesNotSupportedException();
            }
        }

        /**
	     * Remove current badge count
	     *
	     * @param context context activity
	     * @throws BadgesNotSupportedException when the current launcher is not supported by Badges
	     */
        public static void RemoveBadge(Context context)
        {
            Badges.SetBadge(context, 0);
        }
    }
}