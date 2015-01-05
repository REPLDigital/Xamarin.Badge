using Java.Lang;

namespace Badge.Plugin
{
    /**
	 * NullObject implementation for BadgeProvider (not used, replaced by DefaultBadgeProvider).
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Jake Henning
	 */
    public class NullBadgeProvider : BadgeProvider
    {
        public NullBadgeProvider()
            : base(null)
        {
        }

        public override void SetBadge(int count)
        {
            throw new UnsupportedOperationException();
        }

        public override void RemoveBadge()
        {
            throw new UnsupportedOperationException();
        }
    }
}