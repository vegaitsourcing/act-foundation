using ACTFoundation.Common.Extensions;
using System.Web.Mvc;

namespace ACTFoundation.Core.Extensions
{
    public static class StringExtensions
	{
		/// <summary>
		/// Returns <paramref name="controllerName"/> string after stripping "Controller" suffix from it.
		/// </summary>
		/// <param name="controllerName">The name of the controller class.</param>
		/// <returns>Name without "Controller" suffix.</returns>
		public static string RemoveControllerSuffix(this string controllerName)
		{
			return controllerName.RemoveSuffix(nameof(Controller));
		}

		public static string GetTextPreview(this string text, int shortTextLength)
        {
			return text.Length < shortTextLength
				? text
				: text.Substring(0, shortTextLength) + "...";
		}
	}
}
