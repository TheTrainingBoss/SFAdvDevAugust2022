/* ------------------------------------------------------------------------------
<auto-generated>
    This file was generated by Sitefinity CLI v1.1.0.28
</auto-generated>
------------------------------------------------------------------------------ */

using Progress.Sitefinity.Renderer.Designers.Attributes;
using Progress.Sitefinity.Renderer.Entities.Content;
using SFAdvDevAugust2022.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.News.Model;
using Telerik.Sitefinity.Personalization;
using Telerik.Sitefinity.Workflow;

namespace SFAdvDevAugust2022.Mvc.Controllers
{
	[ControllerToolboxItem(Name = "LinoWidget", Title = "Lino Widget", SectionName = "SFAdvAug2022")]
	public class LinoWidgetController : Controller, IPersonalizable
	{
		// GET: LinoWidget
		public ActionResult Index()
		{
			var model = new LinoWidgetModel();
			model.Message = this.Message;
			model.Enum = this.Enum;
			model.MyDate = this.MyDate;
			model.Number = this.Number;

			LibrariesManager lbmanager = LibrariesManager.GetManager();
			var image = lbmanager.GetImage(Guid.Parse(this.Images.ItemIdsOrdered[0]));
			
			
			model.Images = image.MediaUrl;
			model.Flag = this.Flag;
                
			return View(model);
		}

		public ActionResult CreatePressRelease()
		{
            NewsManager nm = NewsManager.GetManager();
            NewsItem item = nm.CreateNewsItem();
			item.Title = "News Item 1";
			item.Content = "<h2>Test content here</h2>";
			item.DateCreated = DateTime.UtcNow;
			item.PublicationDate = DateTime.UtcNow;
			item.LastModified = DateTime.UtcNow;
			item.UrlName = Regex.Replace(item.Title, @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
            nm.SaveChanges();

			var bag = new Dictionary<string, string>();
			bag.Add("ContentType", typeof(NewsItem).FullName);
			WorkflowManager.MessageWorkflow(item.Id, typeof(NewsItem), null, "Publish", false, bag);


			return View();
        }
        
        public ActionResult CreateWithFluent()
        {
            var myGuid = Guid.NewGuid();
            App.WorkWith().NewsItem().CreateNew(myGuid).Do(n =>
            {
                n.Title = "News Item 2";
                n.Content = "<h2>Test content here</h2>";
                n.DateCreated = DateTime.UtcNow;
                n.PublicationDate = DateTime.UtcNow;
                n.LastModified = DateTime.UtcNow;
                n.UrlName = Regex.Replace(n.Title, @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
            }).SaveChanges();
            return View();
        }
    
		
        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        [Category("Lino")]
		public string Message { get; set; }
		[Category("Lino")]
		public bool Flag { get; set; }
		[Category("Lino")]
		public Enumeration Enum { get; set; }
        [Browsable(false)]
		public int Number { get; set; }
		public DateTime MyDate { get; set; }
        [Content(Type = KnownContentTypes.Images)]
		public MixedContentContext Images { get; set; }

		[Content(Type = KnownContentTypes.Pages)]
		public MixedContentContext Page { get; set; }
		
		[Content(Type = KnownContentTypes.Tags)]
		public MixedContentContext Tags { get; set; }
		[Content(Type = KnownContentTypes.News)]
		public MixedContentContext News { get; set; }
	}
}