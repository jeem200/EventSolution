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
    [Route("api/[controller]/[action]")]
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
        public VendorModel Get(string Id)
        {
            try 
            {
                ObjectId id = new ObjectId(Id);
                //id.ToString();
                var filter = new BsonDocument { { "_id", id } };
                return _vendorModel.Find(filter).First();

            }
            catch (Exception e)
            {
                VendorModel model = new VendorModel(); 
                return model;
            }
        }


        [HttpPost]
       
        public string post(VendorModel model)
        {
            try 
            {

                var a = model;
                 _vendorModel.InsertOne(model);
                return model.ToString();
            }
            catch (Exception e) 
            {
                return e.ToString();
            }

        }

        [HttpDelete("{id}")]
        public string Delete(string Id)
        {
            try
            {
                ObjectId id = new ObjectId(Id);
                //id.ToString();
                var filter = new BsonDocument { { "_id", id } };
                return _vendorModel.DeleteOne(filter).ToString();

            }
            catch (Exception e)
            {
               
                return e.ToString();
            }
        }

    }
}
