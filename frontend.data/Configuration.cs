using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.data
{
    static class Configuration
    {
        static public string ConnectionString
        {
            
            get
            {
                ConfigurationManager configurationManager = new();
                try
                {

                    var extension = "../frontend.webui";
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), extension));
                    configurationManager.AddJsonFile("appsettings.json");
                }
                catch
                {
                    configurationManager.AddJsonFile("appsettings.json");
                }

                return configurationManager.GetConnectionString("SQLServer");
            }
        }
    }
}

