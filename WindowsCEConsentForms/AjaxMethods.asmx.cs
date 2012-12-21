using System;
using System.Web.Services;

namespace WindowsCEConsentForms
{
    /// <summary>
    /// Summary description for AjaxMethods
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService]
    public class AjaxMethods : WebService
    {
        [WebMethod]
        public string GetAssociatedDoctors(string primaryPhysicianId)
        {
            return Utilities.GetAssociatedDoctors(Convert.ToInt32(primaryPhysicianId));
        }
    }
}