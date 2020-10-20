using InventoryAPI.Models;
using InventoryAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRep;

 

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRep = customerRepository;
        }

        // GET api/values
        [HttpGet]
        //[Produces(MediaTypeNames.Application.Xml)]
        //[Consumes("application/xlm")]
        public async Task<List<Customer>> GetCustomers()
        {
            return await _customerRep.GetCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetByCustomerByID(int id)
        {
            return await _customerRep.GetCustomerByID(id);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> ADDEditCustomer([FromBody] Customer customer)
        {
            if (customer == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }

            var existingItem = _customerRep.GetCustomerByID(customer.CustID);
            if (existingItem == null)
            {
                return NotFound(ErrorCode.RecordNotFound.ToString());
            }
            return await _customerRep.ADDEditCustomer(customer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteById(int id)
        {
            return await _customerRep.DeleteCustomer(id);
        }


        public enum ErrorCode
        {
            TodoItemNameAndNotesRequired,
            TodoItemIDInUse,
            RecordNotFound,
            CouldNotCreateItem,
            CouldNotUpdateItem,
            CouldNotDeleteItem
        }

    }
}