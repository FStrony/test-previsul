using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_previsul.Application.Services;
using test_previsul.Application.ViewModel;
using test_previsul.Domain.Bases;

namespace test_previsul.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : CustomControllerBase
    {
        [HttpGet("index")]
        public async Task<List<CustomerViewModel>> ListAll()
        {
            using (var service = new CustomerAppService())
            {
                var customers = await service.GetAllCustomers();
                return customers;
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Create([FromBody]CustomerViewModel model)
        {
            var errors = ValidateModelState(ModelState);
            if (errors.Any())
                return JsonModelErrors(errors);

            using (var service = new CustomerAppService())
            {
                var result = await service.Register(model);
                return JsonSuccess(result);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody]CustomerViewModel model)
        {
            var errors = ValidateModelState(ModelState);
            if (errors.Any())
                return JsonModelErrors(errors);

            using (var service = new CustomerAppService())
            {
                var result = await service.EditCustomer(model);
                return JsonSuccess(result);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            using (var service = new CustomerAppService())
            {
                var result = await service.DeleteCustomer(id);
                return JsonSuccess(result);
            }
        }

        [HttpGet("search/{id}")]
        public async Task<CustomerViewModel> GetCustomer([FromRoute]Guid id)
        {
            using (var service = new CustomerAppService())
            {
                var customer = await service.GetCustomer(id);
                return customer;
            }
        }
    }
}
