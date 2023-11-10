using Microsoft.AspNetCore.Mvc;
using transformatek_MP.Models;
using System.Linq;
using transformatek_MP.Data;
using System.Threading.Tasks.Dataflow;
using transformatek_MP.DTO;
namespace transformatek_MP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly TransforamTek_MP_Context _contxt;
        public AgentController(TransforamTek_MP_Context contxt)
        {
            _contxt = contxt;
        }

        [HttpGet("{agent_id:alpha}")]

        public ActionResult<IEnumerable<AffectionDTO>> Get_Affections(string agent_id)
        {
            var res = from a in _contxt.Affectation
                      join p in _contxt.Point on a.Affectation_ID equals p.Affectation_ID
                      join c in _contxt.Consigner on a.Affectation_ID equals c.Affectation_ID
                      where a.Agent.Id_Agent == agent_id
                      select new AffectionDTO()
                      {
                          Admin_ID = (int)a.Admin.Admin_ID,
                          Agent_ID = a.Agent.Id_Agent,
                          Affectation_ID = a.Affectation_ID,
                          Description = a.Description,
                          Point_ID = p.Point_ID,
                          Lang = p.Lang,
                          Lat = p.Lat,
                          Nb_Repetations = c.Nb_Repetations,
                          Type_mesure = c.Type_mesure
                      };
            ;
            if (res != null)
            {
                return NotFound(new { Error = "Affections not found" });
            }
            return Ok(res);
        }
        [HttpGet("{affectation_id:alpha}/{agent_id:alpha}")]
        public ActionResult<AffectionDTO> Get_AffectaionById(string agent_id, string affectation_id)
        {
            var Res = from a in _contxt.Affectation
                      join p in _contxt.Point on a.Affectation_ID equals p.Affectation_ID
                      join c in _contxt.Consigner on a.Affectation_ID equals c.Affectation_ID

                      where a.Agent.Id_Agent == agent_id
                      where a.Affectation_ID == affectation_id
                      select new AffectionDTO()
                      {
                          Admin_ID = (int) a.Admin.Admin_ID,
                          Agent_ID = a.Agent.Id_Agent,
                          Affectation_ID = a.Affectation_ID,
                          Description = a.Description,
                          Point_ID = p.Point_ID,
                          Lang = p.Lang,
                          Lat = p.Lat,
                          Nb_Repetations = c.Nb_Repetations,
                          Type_mesure = c.Type_mesure
                      };
            if (Res == null)
            {
                return NotFound(new { Error = "Affection not found" });
            }
            return Ok(Res);
        }
        [HttpGet]
        public ActionResult<ResulteDTO> Get_resultes(string agent_id)
        {
            var res = from r in _contxt.Resultes
                      where r.Agent.Id_Agent == agent_id
                      select new ResulteDTO()
                      {
                          Id_Agent = r.Agent.Id_Agent,
                          Result_Id = r.Result_Id,
                          Date = r.Date,
                          Mesuretype = r.Mesuretype,
                          Values = r.Values,
                      };
            if (res == null)
            {
                return NotFound(new { Error = "Resultes not found" });
            }
            return Ok(res);
        }
    }
}