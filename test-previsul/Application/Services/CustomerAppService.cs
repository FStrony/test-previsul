using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test_previsul.Application.ViewModel;
using test_previsul.Domain.Bases;
using test_previsul.Domain.Entities;
using test_previsul.Infra.Data.Repositories;

namespace test_previsul.Application.Services
{
    public class CustomerAppService : ServiceBase<Customer, CustomerViewModel>
    {
        public async Task<string> Register(CustomerViewModel item)
        {
            var result = await this.Insert(item);
            if (result > 0)
                resultMessage = "Customer registered!";

            return resultMessage;
        }

        public async Task<string> EditCustomer(CustomerViewModel item)
        {
            using (var service = new CustomerRepository())
            {
                var result = await service.Save(Mapper.Map<Customer>(item));
                if (result > 0)
                {
                    resultMessage = "Customer modified!";
                }
                return resultMessage;
            }
        }

        public async Task<string> DeleteCustomer(Guid Id)
        {
            try
            {
                var model = await this.GetCustomer(Id);
                if (model != null)
                {
                    var result = await this.Delete(model);
                    if (result > 0)
                        resultMessage = "Customer deleted!";
                }
                else
                {
                    resultMessage = "Customer not found!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultMessage;
        }

        public async Task<CustomerViewModel> GetCustomer(Guid Id)
        {
            return await this.SearchObject(expression: x => x.Id == Id, Includes: new string[] { "Addresses" });
        }

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            return await this.ListAll(Includes: new string[] { "Addresses" });
        }
    }
}
