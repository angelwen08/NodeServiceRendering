using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace NodeServiceRenderingSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly INodeServices nodeServices;

        public ValuesController(INodeServices nodeServices)
        {
            this.nodeServices = nodeServices;
        }
       
        [HttpGet("render")]
        public async Task<ActionResult<string>> RenderByNode()
        {
            var htmlContent = await nodeServices.InvokeAsync<string>("./wwwroot/js/renderMyNpm");
            return Content(htmlContent, "text/html");
        }

      
    }
}
