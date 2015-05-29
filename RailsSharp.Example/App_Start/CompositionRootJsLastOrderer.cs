using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Smokey.Web
{
	public class CompositionRootJsLastOrderer : IBundleOrderer
	{
		public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
		{
			return files.OrderBy(x => x.IncludedVirtualPath.IndexOf("CompositionRoot.js", StringComparison.OrdinalIgnoreCase) > -1);
		}
	}
}