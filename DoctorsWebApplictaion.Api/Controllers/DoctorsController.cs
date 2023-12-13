using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorsWebApplictaion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository Finish;
        // GET: api/<DoctorsController>
        public DoctorsController()
        {
            Finish = new DoctorsRepository();
        }
        [HttpGet]
        public List<Doctors> Get()
        {
            return Finish.GetAll();
        }

       

        // POST api/<DoctorsController>
        [HttpPost]
        public void Post([FromBody] Doctors value)
        {
            Finish.Insert(value);
        }

        // PUT api/<DoctorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Doctors value)
        {
            Finish.Update(id, value);
        }

        // DELETE api/<DoctorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Finish.Delete(id);
        }
    }
}
