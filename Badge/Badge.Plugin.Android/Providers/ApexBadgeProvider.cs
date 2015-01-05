using Android.Content;

namespace Badge.Plugin
{
    /**
     * @author Gernot Pansy
     * 
     * ported to C# by Jake Henning
     */
    public class ApexBadgeProvider : BadgeProvider
    {
        private const string IntentAction = "com.anddoes.launcher.COUNTER_CHANGED";
        private const string PackageId = "package";
        private const string CountId = "count";
        private const string ClassId = "class";

        public ApexBadgeProvider(Context context)
            : base(context)
        {
        }

        public override void SetBadge(int count)
        {
            var intent = new Intent(IntentAction);
            intent.PutExtra(PackageId, PackageName);
            intent.PutExtra(CountId, count);
            intent.PutExtra(ClassId, MainActivityClassName);
            Context.SendBroadcast(intent);
        }

        public override void RemoveBadge()
        {
            SetBadge(0);
        }
    }
}