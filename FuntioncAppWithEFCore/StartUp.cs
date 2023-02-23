using Empower.DataAccess.ApplicationContext.Empower;
using Empower.DataAccess.ApplicationContext.Eviti;
using Empower.DataAccess.Repositories.UnitOfWork;
using Empower.DataAccess.UnitOfWork.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

[assembly: Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(typeof(FuntioncAppWithEFCore.StartUp))]

namespace FuntioncAppWithEFCore
{
    public class StartUp : FunctionsStartup
    {
        private EvitiContext _evitiContext;
        private EmpowerContext _empowerContext;
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = BuildConfiguration(builder.GetContext().ApplicationRootPath);
            builder.Services.AddAppConfiguration(configuration);

            
            string evitiConnString = "Data Source=DevDb-01.ita.local;Initial Catalog=evitiDev;User Id=kbApp;Password=tanstaafl;MultipleActiveResultSets=True;TrustServerCertificate=Yes";
            string empowerConnString = "Data Source=TCP:DevDb-01.ita.local;Initial Catalog=EmpowerDB;User Id=kbApp;Password=tanstaafl;MultipleActiveResultSets=True;TrustServerCertificate=Yes"; // Environment.GetEnvironmentVariable("EmpowerDBConnection");

            builder.Services.AddDbContext<EvitiContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, evitiConnString));

            builder.Services.AddDbContext<EmpowerContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, empowerConnString));            

            #region UnitOfWork
            builder.Services.AddTransient<IEmpowerUnitOfWork, EmpowerUnitOfWork>();
            builder.Services.AddTransient<IEvitiUnitOfWork, EvitiUnitOfWork>();
            #endregion
            
        }

        private IConfiguration BuildConfiguration(string applicationRootPath)
        {
            var config =
                new ConfigurationBuilder()
                    .SetBasePath(applicationRootPath)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            return config;
        }
    }
}
