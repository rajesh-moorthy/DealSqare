using System;
using DsServices.Models;

namespace DsServices.Repository
{
    public class CommonLibrary
    {
        public void InsertLog(string ExceptionMessage)
        {
            Log logger = new Log();
            logger.LogDescription = ExceptionMessage;
            logger.LogDate = DateTime.UtcNow;
        }
    }
}
