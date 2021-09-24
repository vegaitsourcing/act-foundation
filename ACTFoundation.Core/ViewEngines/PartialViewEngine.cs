﻿using System.Web.Mvc;

namespace ACTFoundation.Core.ViewEngines
{
	public class PartialViewEngine : RazorViewEngine
	{
		public PartialViewEngine()
		{
			PartialViewLocationFormats = new[]
			{
				"~/Views/Partials/{1}/{0}.cshtml",
				"~/Views/Partials/{1}/_{0}.cshtml",
				"~/Views/Partials/NestedContent/{0}.cshtml",
				"~/Views/Partials/NestedContent/_{0}.cshtml",
			};
		}
	}
}
