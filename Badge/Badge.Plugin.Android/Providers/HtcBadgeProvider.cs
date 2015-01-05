using Android.Content;

namespace Badge.Plugin
{
    /**
	 * BadgeProvider implementation to support badges on HTC devices.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Jake Henning
	 */
    public class HtcBadgeProvider : BadgeProvider
    {
        private const string HtcPackage = "com.htc.launcher";
        private const string IntentAction = "action.UPDATE_SHORTCUT";
        private const string PackageId = "packagename";
        private const string CountId = "count";
        private const string SetNotificationAction = "action.SET_NOTIFICATION";
        private const string ComponentExtra = "extra.COMPONENT";
        private const string CountExtra = "extra.COUNT";

        public HtcBadgeProvider(Context context)
            : base(context)
        {
        }

        public override void SetBadge(int count)
        {
            var intent = new Intent(string.Format("{0}.{1}", HtcPackage, IntentAction));
            intent.PutExtra(PackageId, PackageName);
            intent.PutExtra(count, count);
            Context.SendBroadcast(intent);

            var setNotificationIntent = new Intent(string.Format("{0}.{1}", HtcPackage, SetNotificationAction));
            var componentName = new ComponentName(PackageName, MainActivityClassName);
            setNotificationIntent.PutExtra(string.Format("{0}.{1}", HtcPackage, ComponentExtra), componentName.FlattenToShortString());
            setNotificationIntent.PutExtra(string.Format("{0}.{1}", HtcPackage, CountExtra), count);
            Context.SendBroadcast(setNotificationIntent);
        }

        public override void RemoveBadge()
        {
            SetBadge(0);
        }
    }
}