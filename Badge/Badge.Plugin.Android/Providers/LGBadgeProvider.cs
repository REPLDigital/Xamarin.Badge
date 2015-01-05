using Android.Content;

namespace Badge.Plugin
{
    /**
	 * BadgeProvider implementation to support badges on LG devices.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Jake Henning
	 */
    public class LGBadgeProvider : BadgeProvider
    {
        private const string IntentAction = "BADGE_COUNT_UPDATE";
        private const string PackageId = "badge_count_package_name";
        private const string ClassId = "badge_count_class_name";
        private const string CountId = "badge_count";

        public LGBadgeProvider(Context context)
            : base(context)
        {
        }

        public override void SetBadge(int count)
        {
            var intent = new Intent(string.Format("{0}.{1}", AndroidIntentAction, IntentAction));
            intent.PutExtra(PackageId, PackageName);
            intent.PutExtra(ClassId, MainActivityClassName);
            intent.PutExtra(CountId, count);

            Context.SendBroadcast(intent);
        }

        public override void RemoveBadge()
        {
            SetBadge(0);
        }
    }
}