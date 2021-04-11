using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebApplication13;
using WebApplication13.Tables;
using Newtonsoft.Json;
using System.Web;

namespace WebApplication13.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Orders : ControllerBase
    {
        private Service5nContext _context;


        public Orders(Service5nContext db)
        {
            _context = db;
        }
        // POST api/<Orders>
        [HttpGet]
        public OrderVM FirstInitPage()
        {
            OrderVM orderVM = new OrderVM();
            try
            {
             


                using (var db = _context)
                {
                    orderVM.Rates = db.Rates.Select(p => new RateVM
                    {
                        Name = p.name,
                        Value = p.IdRate
                    }).ToList();

                    orderVM.Regionsnp = db.Regions.Select(s => new RegionVM
                    {
                        Name = s.Name,
                        Value = s.IdRegion
                    }).ToList();


                }


                return orderVM;




            }
            catch (Exception ex)
            {
                string exception = ex.Message;
                

            }

            return orderVM;

        }
        //[HttpGet]
        [HttpGet("info")]
        public List<RegionVM> getRegions(int idRegion)
        {
            List<RegionVM> regions = new List<RegionVM>();
            try
            {
                using (var db = _context)
                {

                    regions = db.Routes.Where(pr => pr.IdRegion == idRegion).Select(p => new RegionVM
                    {
                        Value = p.IdRegionDNavigation.IdRegion,
                        Name = p.IdRegionDNavigation.Name
                    }).ToList();








                
                }
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            return regions;

        }
        [HttpGet("info")]
        public List<CarsVM> getCarsVM(int idRegion, int idRegionD, DateTime dateTime)
        {
            
                using (var db = _context)
                {
                    /*  List<CarsVM> cars = db.Orders.Where(route => route.OrderDate <= dateTime).Where(s => s.IdOrder == IdROUTE).Select(p => new CarsVM
                      {
                          Brand = p.IdCarNavigation.Brand


                      }).ToList();
                      return cars;*/
                    int idRoute = db.Routes.Where(tp => tp.IdRegion == idRegion && tp.IdRegionD == idRegionD).Select(s => s.IdRoute).FirstOrDefault();
                    List<CarsVM> cars = db.Cars.Select(p => new CarsVM
                    {
                        Brand = p.Brand,
                        Model = p.Model,
                        Capacity = Convert.ToInt32(p.Capacity),
                        IdCars = p.IdCar,
                        IdRoute = idRoute
                    }).ToList();


                    return cars;
                }
            


        }

        [HttpGet("info")]
        public ClientVM getClients(long telephone)
        {
            ClientVM client = new ClientVM();
            try
            {
                using (var db = new Service5nContext())
                {
                    client = db.Clients.Select(t => new ClientVM
                    {
                        IdClient = t.IdClient,
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        Patronymic = t.Patronymic,
                        Telephone = t.Telephone
                    }).Where(p => p.Telephone == telephone).FirstOrDefault();
                }
            }
            catch( Exception ex)
            {
                string exception = ex.Message;
                
            }
            return client;
        }

       

        [HttpPost]

        public string DoOrder(Order ordert)
        {

            Order order = new Order();
            try
            {
                order.Capacity = ordert.Capacity;
                order.IdClient = ordert.IdClient;
                order.IdRoute = ordert.IdRoute;
                order.IdTariff = ordert.IdTariff;
                order.OrderDate = ordert.OrderDate;
                order.IdCar = ordert.IdCar;
                order.IdDriver = 1;




                using (var db = _context)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                };
                return "order added";
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
                return exception;
            }
        }

 






    } 

}




