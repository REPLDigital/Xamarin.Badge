using Android.Content;
using Java.Lang;
using Java.Lang.Reflect;

namespace Badge.Plugin
{
    /**
	 * @author leolin
	 * 
	 * ported to C# by Jake Henning
	 */
    public class XiaomiBadgeProvider : BadgeProvider
    {
        private const string IntentAction = "APPLICATION_MESSAGE_UPDATE";
        private const string NotificationId = "android.app.MiuiNotification";
        private const string MessageCountId = "messageCount";
        private const string ComponentId = "android.intent.extra.update_application_component_name";
        private const string MessageId = "android.intent.extra.update_application_message_text";

        public XiaomiBadgeProvider(Context context)
            : base(context)
        {
        }

        public override void SetBadge(int count)
        {
            try
            {
                var miuiNotificationClass = Class.ForName(NotificationId);
                var miuiNotification = miuiNotificationClass.NewInstance();
                var field = miuiNotification.Class.GetDeclaredField(MessageCountId);
                field.Accessible = true;
                field.Set(miuiNotification, count == 0 ? string.Empty : count.ToString());
            }
            catch (System.Exception e)
            {
                var localIntent = new Intent(string.Format("{0}.{1}", AndroidIntentAction, IntentAction));
                localIntent.PutExtra(ComponentId, string.Format("{0}/{1}", PackageName, MainActivityClassName));
                localIntent.PutExtra(MessageId, count == 0 ? string.Empty : count.ToString());
                Context.SendBroadcast(localIntent);
            }
        }

        public override void RemoveBadge()
        {
            SetBadge(0);
        }
    }
}