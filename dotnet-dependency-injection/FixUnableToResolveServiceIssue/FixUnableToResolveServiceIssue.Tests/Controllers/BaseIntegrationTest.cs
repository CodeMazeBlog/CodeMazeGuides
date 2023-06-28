using DependencyInjectionLifetimeScopesTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixUnableToResolveServiceIssue.Tests.Controllers
{
    internal class BaseIntegrationTest
    {
        internal readonly HttpClient httpClient;
        internal BaseIntegrationTest() 
        { 
            var application = new CustomWebApplicationFactory();
            httpClient = application.CreateClient();
        }
    }
}
