using Android.Content;

namespace Badge.Plugin
{
    /**
     * @author leolin
     * 
     * ported to C# by Jake Henning
     */
    public class AsusBadgeProvider : BadgeProvider
    {
        private const string IntentAction = "BADGE_COUNT_UPDATE";
        private const string CountId = "badge_count";
        private const string PackageId = "badge_count_package_name";
        private const string ClassId = "badge_count_class_name";
        private const string VipCountId = "badge_vip_count";

        public AsusBadgeProvider(Context context)
            : base(context)
        {
        }

        public override void SetBadge(int count)
        {
            var intent = new Intent(string.Format("{0}.{1}", AndroidIntentAction, IntentAction));
            intent.PutExtra(CountId, count);
            intent.PutExtra(PackageId, PackageName);
            intent.PutExtra(ClassId, MainActivityClassName);
            intent.PutExtra(VipCountId, 0);
            Context.SendBroadcast(intent);
        }

        public override void RemoveBadge()
        {
            SetBadge(0);
        }
    }
}