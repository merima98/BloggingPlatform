using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatform.WebAPI.Database
{
    public class Data
    {
        public static void Seed(BloggingPlatformContext context)
        {
            context.Database.Migrate();
        }
    }
}
