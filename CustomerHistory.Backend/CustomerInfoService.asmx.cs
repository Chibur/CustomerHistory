using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CustomerHistory.Backend.Models;


namespace CustomerHistory.Backend
{
    /// <summary>
    /// Summary description for CustomerInfo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomerInfoService : System.Web.Services.WebService
    {


        [WebMethod]
        public string HelloInfo()
        {
            return "Hello from info";
        }
        [WebMethod]
        public CustomerInfo customerInfo(int id)
        {
            return new CustomerInfo(id);
        }
    }
}
