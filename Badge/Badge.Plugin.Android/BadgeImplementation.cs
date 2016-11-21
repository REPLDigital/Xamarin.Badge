using Android.App;
using Badge.Plugin.Abstractions;

// Permissions for different launchers (default):
[assembly:UsesPermission( Name = "com.android.launcher.permission.READ_SETTINGS" )]
[assembly:UsesPermission( Name = "com.android.launcher.permission.WRITE_SETTINGS" )]
[assembly:UsesPermission( Name = "com.android.launcher.permission.INSTALL_SHORTCUT" )]
[assembly:UsesPermission( Name = "com.android.launcher.permission.UNINSTALL_SHORTCUT" )]

// Samsung:
[assembly:UsesPermission( Name = "com.sec.android.provider.badge.permission.READ" )]
[assembly:UsesPermission( Name = "com.sec.android.provider.badge.permission.WRITE" )]

// HTC:
[assembly:UsesPermission( Name = "com.htc.launcher.permission.READ_SETTINGS" )]
[assembly:UsesPermission( Name = "com.htc.launcher.permission.UPDATE_SHORTCUT" )]

// Sony:
[assembly:UsesPermission( Name = "com.sonyericsson.home.permission.BROADCAST_BADGE" )]

// Apex:
[assembly:UsesPermission( Name = "com.anddoes.launcher.permission.UPDATE_COUNT" )]

// Solid:
[assembly:UsesPermission( Name = "com.majeur.launcher.permission.UPDATE_BADGE" )]


namespace Badge.Plugin
{
    /// <summary>
    /// Implementation of Badge for Android
    /// </summary>
    public class BadgeImplementation : IBadge
    {
        /// <summary>
        /// Sets the badge.
        /// </summary>
        /// <param name="badgeNumber">The badge number.</param>
        public void SetBadge(int badgeNumber)
        {
            Badges.SetBadge(Application.Context, badgeNumber);
        }

        /// <summary>
        /// Clears the badge.
        /// </summary>
        public void ClearBadge()
        {
            Badges.RemoveBadge(Application.Context);
        }
    }
}