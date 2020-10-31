using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DsServices.Models;
using DsServices.Repository;

namespace DsServices.Controllers
{

    public class TownController : ControllerBase
    {
        CommonLibrary Cl = new CommonLibrary();
        [HttpGet("api/GetTowns")]
        public List<City> GetActiveTowns()
        {
            try
            {
                var dbContext = new DsContext();
                var town = dbContext.City.Where(u => u.Active == 1);
                return town.ToList();
            }
            catch (Exception ex)
            {
                Cl.InsertLog(ex.Message);
                return null;
            }
        }


        [HttpGet("api/GetCountries")]
        public List<Country> GetActiveCountries()
        {
            try
            {
                var dbContext = new DsContext();
                var ctry = dbContext.Country.Where(u => u.Active == 1);
                return ctry.ToList();
            }
            catch (Exception ex)
            {

                Cl.InsertLog(ex.Message);
                return null;
            }
        }

        [HttpGet("api/GetStates")]
        public List<State> GetActiveStates()
        {
            try
            {
                var dbContext = new DsContext();
                var state = dbContext.State.Where(u => u.Active == 1);
                return state.ToList();
            }
            catch (Exception ex)
            {
                Cl.InsertLog(ex.Message);
                return null;
            }
        }


    }
}