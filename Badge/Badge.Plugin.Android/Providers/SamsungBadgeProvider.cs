using Android.Content;
using System;

namespace Badge.Plugin
{
    /**
	 * BadgeProvider implementation to support badges on Samsung devices (WITH FIXES).
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# and fixed by Jake Henning
	 */
    public class SamsungBadgeProvider : BadgeProvider
    {
        private static Android.Net.Uri ContentUri = Android.Net.Uri.Parse("content://com.sec.badge/apps");

        private const string PackageId = "package";
        private const string ClassId = "class";
        private const string CountId = "badgecount";
        private const string PackageFilter = "package=?";

        public SamsungBadgeProvider(Context context)
            : base(context)
        {
        }

        public override void SetBadge(int count)
        {
            try
            {
                var cv = new ContentValues();
                cv.Put(PackageId, PackageName);
                cv.Put(ClassId, MainActivityClassName);
                cv.Put(CountId, count);

                var contentResolver = Context.ContentResolver;

                int updated = contentResolver.Update(ContentUri, cv, PackageFilter, new [] { PackageName });

                if (updated == 0)
                {
                    contentResolver.Insert(ContentUri, cv);
                }

            }
            catch (Exception e)
            {
                // Some Samsung devices are throwing SecurityException or RuntimeException when
                // trying to set the badge saying the app needs permission which are already added,
                // this try/catch protect us from these "crappy phones" :)
                throw new Java.Lang.UnsupportedOperationException();
            }
        }

        public override void RemoveBadge()
        {
            SetBadge(0);
        }
    }
}