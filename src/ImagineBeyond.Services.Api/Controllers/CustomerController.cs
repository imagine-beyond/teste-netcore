using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImagineBeyond.Services.Api.Controllers
{    
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [AllowAnonymous]        
        public async Task<IActionResult> Get()
        {
            return Ok(new { success = true, data = await _customerAppService.Get() }) ;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("getbyid")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(new { success = true, data = await _customerAppService.GetById(id) });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {                
                return BadRequest(new
                {
                    success = false,
                    errors = ModelState.Values.SelectMany(v => v.Errors)
                });
            }

            await _customerAppService.CreateCostumer(customerViewModel);

            return Ok(new { success = true, data = customerViewModel } );
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ModelState.Values.SelectMany(v => v.Errors)
                });
            }

            await _customerAppService.UpdateCostumer(customerViewModel);

            return Ok(new { success = true, data = customerViewModel });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerAppService.DeleteCostumer(id);

            return Ok(new { success = true, data = id });
        }
    }
}