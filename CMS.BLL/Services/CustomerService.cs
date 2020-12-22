using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL.Interface;
using CMS.Domain;
using CMS.DAL.Repository;
using CMS.Domain.ViewModel;
using AutoMapper;

namespace CMS.BLL.Services
{
    public class CustomerService
    {
        private IRepository<Customers> db;

        public CustomerService()
        {
            db = new GenericRepository<Customers>();
        }

        //取得所有客戶資料
        public List<CustomerViewModel> Get()
        {
            var DbResult = db.Get().ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap <Customers, CustomerViewModel>()); // 註冊Model間的對映
            var mapper = config.CreateMapper(); // 建立 Mapper
            return mapper.Map<List<CustomerViewModel>>(DbResult); // 轉換型別
        }
        //取得客戶資訊
        public CustomerViewModel Get(string CustomerID)
        {
            var DbResult = db.Get().Where(c => c.CustomerID.Trim() == CustomerID.Trim()).FirstOrDefault();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customers, CustomerViewModel>()); // 註冊Model間的對映
            var mapper = config.CreateMapper(); // 建立 Mapper
            return mapper.Map<CustomerViewModel>(DbResult); // 轉換型別
        }
        // 新增客戶資料

        public void AddCustomer(CustomerViewModel models)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerViewModel, Customers>()); // 註冊Model間的對映
            var mapper = config.CreateMapper(); // 建立 Mapper
            db.Create(mapper.Map<CustomerViewModel, Customers>(models));  
        }

        //儲存客戶資訊
        public void SaveCustomer(CustomerViewModel models)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerViewModel, Customers>()); // 註冊Model間的對映
            var mapper = config.CreateMapper(); // 建立 Mapper
            db.Update(mapper.Map<CustomerViewModel, Customers>(models));
        }

        //刪除客戶資訊
        public void Delete(string CustomerID)
        {
            var Customer = db.GetByID(CustomerID);
            db.Delete(Customer);
        }
    }
}
