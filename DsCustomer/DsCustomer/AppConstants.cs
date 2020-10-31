using System;
using System.Collections.Generic;
using System.Text;

namespace DsCustomer
{
    public class AppConstants
    {
#if Dev
    public const string BaseURL = "http://mydevapi.com/devApi";
#elif Test
    public const string BaseURL = "http://mytestapi.com/testApi";
#elif SIT
    public const string BaseURL = "http://mytestapi.com/testApi";
#elif UAT
        public const string BaseURL = "http://myuatapi.com/uatApi"
#elif Prod
    public const string BaseURL = "http://myliveapi.com/LiveApi";
#endif
    }
}
