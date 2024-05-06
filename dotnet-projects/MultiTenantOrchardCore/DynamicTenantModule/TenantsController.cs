using Microsoft.AspNetCore.Mvc;

namespace DynamicTenantModule;

[ApiController, Route("api/tenants")]
public class TenantsController(DynamicTenantSetup tenantSetup) : Controller
{
    public IActionResult Index()
    {
        return Ok("Tenant controller home");
    }
    
    [HttpPost("create")]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Create()
    {
        await tenantSetup.CreateTenant();
        
        return Ok("Tenant created");
    }
}