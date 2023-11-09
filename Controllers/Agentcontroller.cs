using Microsoft.AspNetCore.Mvc;
using transformatek_MP.Models;
using transformatek_MP.Data;
using System.Threading.Tasks.Dataflow;
namespace transformatek_MP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly TransforamTek_MP_Context _contxt;
        public  AgentController(TransforamTek_MP_Context contxt){
            _contxt = contxt;
        }

        [HttpGet]
        public IList<Admin> Get_Admin()
        {
            var Res = _contxt.Admins.ToList();
            return Res;
        }
    }
}