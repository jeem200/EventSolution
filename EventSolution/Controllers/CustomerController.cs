using Event.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMongoCollection<CustomerModel> _customerModel;

        public CustomerController(IMongoClient client)
        {
            var database = client.GetDatabase("EventSoultion");
            _customerModel = database.GetCollection<CustomerModel>("Customers");
        }

        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return _customerModel.Find(new BsonDocument()).ToList();
        }


        [HttpGet("{id}")]
        public IActionResult Get(string Id)
        {
            try
            {
                ObjectId id = new ObjectId(Id);

                var filter = new BsonDocument { { "_id", id } };
                return Ok(_customerModel.Find(filter).First());

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost]

        public IActionResult post(CustomerModel model)
        {
            try
            {
                _customerModel.InsertOne(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string Id)
        {
            try
            {
                ObjectId id = new ObjectId(Id);
             
                var filter = new BsonDocument { { "_id", id } };
                return Ok(_customerModel.DeleteOne(filter));

            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
