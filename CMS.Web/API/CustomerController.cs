using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMS.BLL.Services;

namespace CMS.Web.API
{
    public class CustomerController : ApiController
    {
        private CustomerService service;

        public CustomerController()
        {
            service = new CustomerService();
        }

        // GET: api/Customer
        [HttpGet]
        public HttpResponseMessage Customers()
        {
            try
            {
                // 取得客戶資料
                var datas = service.Get();
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (Exception ex)
            {
                // 發生錯誤，寫入Log，回傳失敗及錯誤訊息
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }

        }
    }
}
