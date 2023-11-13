using Microsoft.AspNetCore.Mvc;
using transformatek_MP.Models;
using transformatek_MP.Data;
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
            if (Res == null)
            {
                return NotFound(new { Error = "Affection not found" });
            }
            return Ok(Res);
        }
        [HttpGet("GetResultes")]
        public ActionResult<ResulteDTO> Get_resultes(string agent_id)
        {
            var res = from r in _contxt.Resultes
                      where r.Agent.Id_Agent == agent_id
                      select new ResulteDTO()
                      {
                          Id_Agent = agent_id,
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

        [HttpPost("{id:int}")]

        public ActionResult postResultes([FromBody] ResulteDTO value, int id)
        {
            Resultes res = new Resultes()
            {
                Result_Id = Convert.ToString(Guid.NewGuid()), // Use GUID for Result_Id
                Date = value.Date,
                Mesuretype = value.Mesuretype,
                Values = value.Values,
                Agent = _contxt.Agent.Find(Convert.ToString(id))  /* handle null case */
            };

            _contxt.Add(res);
            _contxt.SaveChanges();


            value.Date = res.Date;
            value.Id_Agent = res.Agent.Id_Agent;
            value.Mesuretype = res.Mesuretype;
            value.Result_Id = res.Result_Id;
            value.Values = res.Values;
            // Save changes to the database

            return Ok(value);
        }




    }
}