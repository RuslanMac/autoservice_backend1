using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Tables;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication13.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Rates : ControllerBase
    {
        // GET: api/<Rates>
        [HttpGet]
        public IEnumerable<Rate> GetServices()
        {
            List<Rate> rates = new List<Rate>();

            using (var db = new Service5nContext())
            {
                rates = db.Rates.ToList();
            }

            return rates;
        }

       
        // POST api/<Rates>
        [HttpPost]
        public void PostRequest([FromBody] Rate ratenk)
        {
            

            Rate rate = new Rate();

            rate.name = ratenk.name;
            rate.description = ratenk.description;
            rate.price = ratenk.price;
            using (var db = new Service5nContext())
            {
                db.Rates.Add(rate);
                db.SaveChanges();
            }


        }

        // PUT api/<Rates>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPost]
        public void UpdateTarrif([FromBody] List<Rate> rates)
        {

            using (var db = new Service5nContext())
            {
                for (int i = 0; i < rates.Count; i++)
                {
                    db.Rates.Add(rates[i]);
                }

                db.SaveChanges();

            }
        }

        // DELETE api/<Rates>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]

        public List<Rate> updateRows([FromBody] List<Rate> rates)
        {
            var xp = 5;
            List<Rate> newRates = new List<Rate>();
            using (var db = new Service5nContext())
            {
                
                for (int i=0; i< rates.Count; i++ )
                {
                    Rate rate = new Rate();
                    rate = db.Rates.Where(p => p.IdRate == rates[i].IdRate).FirstOrDefault();
                    if (!(rates[i].name == rate.name && rates[i].description == rate.description && rates[i].price == rate.price))
                    {
                        db.Rates.Remove(rate);
                        db.Rates.Add(rates[i]);
                    }


                }
                    


                newRates = db.Rates.ToList();

                db.SaveChanges();

                return newRates; 
                
            }
        }
        
    }
}
