using System;

namespace Badge.Plugin
{
    /**
	 * Exception to tell the current launcher is not supported by Badges library.
	 *
	 * @author Arturo Gutiérrez Díaz-Guerra
	 * 
	 * ported to C# by Jake Henning
	 */
    public class BadgesNotSupportedException : Exception
    {
        /// <summary>
        /// Current home launcher is not supported by Badges library
        /// </summary>
        public BadgesNotSupportedException()
            : base("Current home launcher is not supported by Badges library")
        {
            
        }

        /// <summary>
        /// The home launcher package is not supported by Badges library
        /// </summary>
        public BadgesNotSupportedException(String homePackage)
            : base(string.Format("The home launcher with package {0} is not supported by Badges library", homePackage))
        {
            
        }
    }
}