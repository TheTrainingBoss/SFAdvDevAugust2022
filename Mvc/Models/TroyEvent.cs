using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFAdvDevAugust2022.Mvc.Models
{
    public class TroyEvent : ITroyEvent
    {
        public string MyCustomMessage { get; set; }
        public string Origin { get; set; }
    }
}