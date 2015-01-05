using Android.Content;

namespace Badge.Plugin
{
    /**
     * @author Gernot Pansy
     * 
     * ported to C# by Jake Henning
     */
    public class AdwBadgeProvider : BadgeProvider
    {
        private const string IntentAction = "org.adw.launcher.counter.SEND";
        private const string PackageNameId = "PNAME";
        private const string CountId = "COUNT";

        public AdwBadgeProvider(Context context)
            : base(context)
        {
        }

        public override void SetBadge(int count)
        {
            var intent = new Intent(IntentAction);
            intent.PutExtra(PackageNameId, PackageName);
            intent.PutExtra(CountId, count);
            Context.SendBroadcast(intent);
        }

        public override void RemoveBadge()
        {
            SetBadge(0);
        }
    }
}