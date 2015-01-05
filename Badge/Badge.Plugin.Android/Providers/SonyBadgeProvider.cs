using Android.Content;

namespace Badge.Plugin
{
    /**
	 * BadgeProvider implementation to support badges on Sony devices.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Jake Henning
	 */
    public class SonyBadgeProvider : BadgeProvider
    {
        private const string SonyIntentAction = "com.sonyericsson.home";
        private const string IntentAction = "action.UPDATE_BADGE";
        private const string PackageId = "extra.badge.PACKAGE_NAME";
        private const string ClassId = "extra.badge.ACTIVITY_NAME";
        private const string ShowMessageId = "extra.badge.SHOW_MESSAGE";
        private const string MessageId = "extra.badge.MESSAGE";

        public SonyBadgeProvider(Context context)
            : base(context)
        {
        }

        public override void SetBadge(int count)
        {
            var intent = new Intent();

            intent.SetAction(string.Format("{0}.{1}", SonyIntentAction, IntentAction));
            intent.PutExtra(string.Format("{0}.{1}", SonyIntentAction, PackageId), PackageName);
            intent.PutExtra(string.Format("{0}.{1}", SonyIntentAction, ClassId), MainActivityClassName);
            intent.PutExtra(string.Format("{0}.{1}", SonyIntentAction, ShowMessageId), count > 0);
            intent.PutExtra(string.Format("{0}.{1}", SonyIntentAction, MessageId), count.ToString());

            Context.SendBroadcast(intent);
        }

        public override void RemoveBadge()
        {
            SetBadge(0);
        }
    }
}