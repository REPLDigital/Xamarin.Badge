using Android.Content;

namespace Badge.Plugin
{
    /**
	 * @author MajeurAndroid
	 * 
	 * ported to C# by Jake Henning
	 */
    public class SolidBadgeProvider : BadgeProvider
    {
        private const string SolidIntentAction = "com.majeur.launcher.intent";
        private const string IntentAction = "action.UPDATE_BADGE";
        private const string PackageId = "extra.BADGE_PACKAGE";
        private const string CountId = "extra.BADGE_COUNT";
        private const string ClassId = "extra.BADGE_CLASS";

        public SolidBadgeProvider(Context context)
            : base(context)
        {
        }

        public override void SetBadge(int count)
        {
            var intent = new Intent(string.Format("{0}.{1}", SolidIntentAction, IntentAction));
            intent.PutExtra(string.Format("{0}.{1}", SolidIntentAction, PackageId), PackageName);
            intent.PutExtra(string.Format("{0}.{1}", SolidIntentAction, CountId), count);
            intent.PutExtra(string.Format("{0}.{1}", SolidIntentAction, ClassId), MainActivityClassName);
            Context.SendBroadcast(intent);
        }

        public override void RemoveBadge()
        {
            SetBadge(0);
        }
    }
}