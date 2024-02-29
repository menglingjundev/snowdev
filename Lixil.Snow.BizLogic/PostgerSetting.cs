using Lixil.Snow.DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lixil.Snow.BizLogic
{
    public static class PostgerSetting
    {
        public static void Configure(IConfiguration configuration)
        {
            SqlManager.Configure(configuration);
        }
    }
}
