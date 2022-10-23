using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace School.Repositories
{
    internal class DataBaseInitializer :IDataBaseInitializer
    {
        private readonly IServiceScopeFactory _scope;

        public DataBaseInitializer(IServiceScopeFactory scope)
        {
            _scope = scope;
        }

        public void Initialize()
        {
            using (var serviceScope = _scope.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SchoolDbContext>())
                {
                    try
                    {
                        context.Database.EnsureCreated();
                        context.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Write(ex);
                    }
                }
            }
        }
    }
}
