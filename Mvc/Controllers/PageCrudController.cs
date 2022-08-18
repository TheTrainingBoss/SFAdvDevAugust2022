/* ------------------------------------------------------------------------------
<auto-generated>
    This file was generated by Sitefinity CLI v1.1.0.30
</auto-generated>
------------------------------------------------------------------------------ */

using SFAdvDevAugust2022.Mvc.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Personalization;

namespace SFAdvDevAugust2022.Mvc.Controllers
{
	[ControllerToolboxItem(Name = "PageCrud", Title = "Page Crud", SectionName = "SFAdvDev2022")]
	public class PageCrudController : Controller, IPersonalizable
	{
		PageManager pm = PageManager.GetManager();
		// GET: PageCrud
		public ActionResult Index()
		{
            var pages = pm.GetPageDataList().Where(p => p.Status == ContentLifecycleStatus.Live)
                                            .Select(p => p.NavigationNode)
                                            .Where(n => !n.IsBackend && !n.IsDeleted);

            var model = new PageCrudModel(pages);



            //var manager = PageManager.GetManager();
            //var page = manager.GetPageNodes().Where(p => p.Title == "pageTitle").FirstOrDefault();
            //Guid id = page.GetPageData().Id;

            //var cacheKeys = new List<CacheDependencyKey>();

            //var assembly = typeof(PageNode).Assembly;
            //var cacheDependencyPageDataObject = assembly.GetType("Telerik.Sitefinity.Pages.Model.CacheDependencyPageDataObject");
            //var sitemapCachePageDataObject = assembly.GetType("Telerik.Sitefinity.Pages.Model.SitemapCachePageDataObject");

            //cacheKeys.Add(new CacheDependencyKey { Key = id.ToString(), Type = typeof(PageData) });
            //cacheKeys.Add(new CacheDependencyKey { Key = id.ToString(), Type = cacheDependencyPageDataObject });

            //cacheKeys.Add(new CacheDependencyKey { Key = id.ToString(), Type = sitemapCachePageDataObject });

            //CacheDependency.Notify(cacheKeys);






            return View(model);
		}
		
        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

		public string Message { get; set; }
	}
}