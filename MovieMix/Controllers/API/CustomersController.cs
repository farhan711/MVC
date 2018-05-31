using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieMix.Dtos;
using MovieMix.Models;

namespace MovieMix.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get /API/Customers
        public IHttpActionResult GetCustomers()
        {
            List<Customer> customers = _context.Customers.ToList();
            List<CustomerDTO> vm = Mapper.Map<List<CustomerDTO>>(customers);
            return Ok(vm);
        }
        //Get /API/Customers/1
        public CustomerDTO GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            return Mapper.Map<Customer, CustomerDTO>(customer);
        }
        //POST /API/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);

        }
        //PUT API/customer/1
        [HttpPut]
        public void UpdateCutomer (int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            if(customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
           Mapper.Map(customerDto, customerInDB);
            _context.SaveChanges();

        }

        [HttpDelete]
        //Delete API/Customer/1
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}