using Event.DataAccess.Models;
using EventSolution.ViewModels;
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
    public class VendorController : ControllerBase
    {
        private IMongoCollection<VendorModel> _vendorModel;

        public VendorController(IMongoClient client)
        {
            var database = client.GetDatabase("EventSoultion");
            _vendorModel = database.GetCollection<VendorModel>("Vendors");
        }

        [HttpGet]
        public IEnumerable<VendorModel> Get()
        {
            return _vendorModel.Find(new BsonDocument()).ToList();
        }


        [HttpGet("{id}")]
        public IActionResult Get(string Id)
        {
            try
            {
                ObjectId id = new ObjectId(Id);

                var filter = new BsonDocument { { "_id", id } };
                return Ok(_vendorModel.Find(filter).First());

            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }


        [HttpPost]

        public IActionResult post(VendorModel model)
        {
            try
            {
                _vendorModel.InsertOne(model);
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
                return Ok(_vendorModel.DeleteOne(filter));

            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpPatch]
        public IActionResult Patch(VendorModel model)
        {
            try
            {
                ObjectId id = new ObjectId(model.Id);
                var filter = new BsonDocument { { "_id", id } };
                var update = Builders<VendorModel>.Update.Set("ServiceType", model.ServiceType);
                return Ok(_vendorModel.UpdateOne(filter, update));

            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

    }
}
