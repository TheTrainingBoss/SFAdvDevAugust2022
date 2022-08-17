using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Localization;

namespace SFAdvDevAugust2022.Localization
{
    [ObjectInfo(typeof(MyWidgetResources), ResourceClassId = "MyWidgetResources", Title = "MyWidgetResourcesTitle", TitlePlural = "MyWidgetResourcesTitlePlural", Description = "This is MyWidget Resource")]
    public class MyWidgetResources: Resource
    {
        [ResourceEntry("Message", Value = "Message", Description = "Message in English", LastModified = "2022/08/17")]
        public string Message
        {
            get
            {
                return this["Message"];
            }
        }
    }
}