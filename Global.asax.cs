using SFAdvDevAugust2022.Mvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Modules.Libraries.Web.Events;
using Telerik.Sitefinity.Services;

namespace SFAdvDevAugust2022
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialized += Bootstrapper_Initialized; 
        }

        private void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                EventHub.Subscribe<IMediaContentDownloadedEvent>(evt => MyMediaEvent(evt));
                EventHub.Subscribe<ITroyEvent>(evt => TroyRaizedEvent(evt));
            }
        }

        private void TroyRaizedEvent(ITroyEvent evt)
        {
            string path = "~/App_Data/Sitefinity/Temp/Lino.txt";
            File.AppendAllText(HttpContext.Current.Server.MapPath(path), evt.MyCustomMessage);

        }

        private void MyMediaEvent(IMediaContentDownloadedEvent evt)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            EventHub.Unsubscribe<IMediaContentDownloadedEvent>(MyMediaEvent);
        }
    }
}