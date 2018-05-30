using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //Get /API/Customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            return customer;
        }
        //POST /API/customer
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();


            return customer;

        }
        //PUT API/customer/1
        [HttpPut]
        public void UpdateCutomer (int id, Customer customer)
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
            customerInDB.Name = customer.Name;
            customerInDB.Id = customer.Id;
            customerInDB.DOB = customer.DOB;
            customerInDB.IsSubscribeToNewsletter = customer.IsSubscribeToNewsletter;
            customerInDB.MembershipType = customer.MembershipType;

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
