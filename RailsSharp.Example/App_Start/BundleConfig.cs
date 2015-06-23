using System.Web.Optimization;

namespace RailsSharp.Example
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));


			var bundle = new ScriptBundle("~/bundles/app")
			{
				Orderer = new CompositionRootJsLastOrderer()
			};
			bundle.Include(
				"~/Scripts/jquery-{version}.js",
				"~/Scripts/jquery.signalr-{version}.js",
				"~/Scripts/underscore.js",
				"~/Scripts/moment.js",
				"~/Scripts/bootstrap.js",
				"~/Scripts/angular.js",
				"~/Scripts/LogR.js",
				"~/Scripts/jMess.js",
				"~/Scripts/respond.js",
				"~/App/*.js");
			bundles.Add(bundle);

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css"));
		}
	}
}
