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
    public class PreferenceController : ControllerBase
    {
        CommonLibrary Cl = new CommonLibrary();

        [HttpGet("api/GetPreferences")]
        public List<Preferences> GetPreferences()
        {
            try
            {
                var dbContext = new DsContext();
                var pref = dbContext.preferences.Where(u => u.Active == 1);
                return pref.ToList();
            }
            catch (Exception ex)
            {
                Cl.InsertLog(ex.Message);
                return null;
            }
        }
    }
}
