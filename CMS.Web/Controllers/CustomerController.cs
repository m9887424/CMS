using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using CMS.Domain.ViewModel;

namespace CMS.Web.Controllers
{
    public class CustomerController : Controller
    {
        /*
        // GET: Customer
        public async Task<ActionResult> Index()
        {
            /*
            string TargetUri = "https://localhost:44368/api/Customer";

            HttpClient client = new HttpClient();

            client.MaxResponseContentBufferSize = Int32.MaxValue;

            var res = await client.GetStringAsync(TargetUri);

            IList<CustomerViewModel> models = JsonConvert.DeserializeObject<IList<CustomerViewModel>>(res);

            return View(models);
        }
        */
        public ActionResult Index()
        {
            return View();
        }
    }
}