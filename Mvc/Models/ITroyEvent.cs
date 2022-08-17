using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Services.Events;

namespace SFAdvDevAugust2022.Mvc.Models
{
    public interface ITroyEvent: IEvent
    {
        string MyCustomMessage { get; set; }
    }
}