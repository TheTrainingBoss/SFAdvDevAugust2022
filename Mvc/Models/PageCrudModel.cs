/* ------------------------------------------------------------------------------
<auto-generated>
    This file was generated by Sitefinity CLI v1.1.0.30
</auto-generated>
------------------------------------------------------------------------------ */

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Pages.Model;

namespace SFAdvDevAugust2022.Mvc.Models
{
		public class PageCrudModel
		{
			public List<PageInfo> PagesInfo
			{
				get;
				private set;
			}

			public class PageInfo
			{
				public string PageTitle { get; set; }
			}

			public PageCrudModel(IQueryable<PageNode> pages)
			{
				this.PagesInfo = GetPagesInfo(pages);
			}

			private List<PageInfo> GetPagesInfo(IQueryable<PageNode> pages)
			{
				List<PageInfo> pagesinfo = new List<PageInfo>();
				foreach (var p in pages)
				{
					PageInfo pageinfo = new PageInfo();
					pageinfo.PageTitle = p.Title;
					pagesinfo.Add(pageinfo);
				}
				return pagesinfo;
			}
		}
}