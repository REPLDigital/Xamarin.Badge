using Android.Content;
using System.Collections.Generic;
using System;

namespace Badge.Plugin
{
    /**
	 * Factory created to provide BadgeProvider implementations depending what launcher is being executed
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Jake Henning
	 */
    public class BadgeProviderFactory
    {
        private readonly Context _context;
        private Dictionary<string, BadgeProvider> _providers;

        /// <summary>
        /// Badge provider factory constructor
        /// </summary>
        public BadgeProviderFactory(Context context)
        {
            _context = context;
            _providers = new Dictionary<string, BadgeProvider>();

            /* from https://github.com/arturogutierrez/Badges */
            _providers.Add("com.sec.android.app.launcher", new SamsungBadgeProvider(_context));
            _providers.Add("com.sec.android.app.twlauncher", new SamsungBadgeProvider(_context));
            _providers.Add("com.lge.launcher", new LGBadgeProvider(_context));
            _providers.Add("com.lge.launcher2", new LGBadgeProvider(_context));
            _providers.Add("com.sonyericsson.home", new SonyBadgeProvider(_context));
            _providers.Add("com.htc.launcher", new HtcBadgeProvider(_context));

            /* from https://github.com/leolin310148/ShortcutBadger */
            _providers.Add("org.adw.launcher", new AdwBadgeProvider(_context));
            _providers.Add("org.adwfreak.launcher", new AdwBadgeProvider(_context));
            _providers.Add("com.anddoes.launcher", new ApexBadgeProvider(_context));
            _providers.Add("com.asus.launcher", new AsusBadgeProvider(_context));
            _providers.Add("com.teslacoilsw.launcher", new NovaBadgeProvider(_context));
            _providers.Add("com.majeur.launcher", new SolidBadgeProvider(_context));
            _providers.Add("com.miui.home", new XiaomiBadgeProvider(_context));
            _providers.Add("com.miui.miuilite", new XiaomiBadgeProvider(_context));
            _providers.Add("com.miui.miuihome", new XiaomiBadgeProvider(_context));
            _providers.Add("com.miui.miuihome2", new XiaomiBadgeProvider(_context));
            _providers.Add("com.miui.mihome", new XiaomiBadgeProvider(_context));
            _providers.Add("com.miui.mihome2", new XiaomiBadgeProvider(_context));
        }

        public BadgeProvider GetBadgeProvider()
        {
            var currentPackage = GetHomePackage();

            return _providers.ContainsKey(currentPackage) ? _providers[currentPackage] : new DefaultBadgeProvider(_context);
        }

        private string GetHomePackage()
        {
            var identify = new HomePackageIdentify();

            return identify.GetHomePackage(_context);
        }
    }
}