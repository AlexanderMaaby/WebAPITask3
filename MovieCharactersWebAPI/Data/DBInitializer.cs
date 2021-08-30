using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MovieCharactersWebAPI.Data
{
    public class DBInitializer 
    {

        public static void Seed(IApplicationBuilder applicationBuilder) {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {

            }

        }
    }
}
