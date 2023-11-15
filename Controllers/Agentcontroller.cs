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

        [HttpGet("Get_Affections{agent_id:int}")]

        public ActionResult<IEnumerable<AffectionDTO>> Get_Affections(int agent_id)
        {
            var res = from a in _contxt.Affectation
                      join p in _contxt.Point on a.Affectation_ID equals p.Affectation_ID
                      join c in _contxt.Consigner on a.Affectation_ID equals c.Affectation_ID
                      where a.Agent.Id_Agent == agent_id
                      select new AffectionDTO()
                      {
                          Admin_ID = a.Admin.Admin_ID,
                          Agent_ID = a.Agent.Id_Agent,
                          Affectation_ID = Convert.ToString(a.Affectation_ID),
                          Description = a.Description,
                          Point_ID = p.Point_ID,
                          Lang = p.Lang,
                          Lat = p.Lat,
                          Nb_Repetations = c.Nb_Repetations,
                          Type_mesure = c.Type_mesure
                      };
            ;
            if (res == null)
            {
                return NotFound(new { Error = "Affections not found" });
            }
            return Ok(res);
        }
        [HttpGet("Get_Affectation_By_Id{affectation_id:int}/{agent_id:int}")]
        public ActionResult<AffectionDTO> Get_AffectaionById(int agent_id, int affectation_id)
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
                          Affectation_ID = Convert.ToString(a.Affectation_ID),
                          Description = a.Description,
                          Point_ID = p.Point_ID,
                          Conseigner_ID = Convert.ToString(c.Consigner_ID),
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

        [HttpGet("Get_All_Resultes")]
        public ActionResult<ResulteDTO> Get_resultes(int agent_id)
        {
            var res = from r in _contxt.Resultes
                      where r.Agent.Id_Agent == agent_id
                      select new ResulteDTO()
                      {
                          Id_Agent = agent_id,
                          Result_Id = Convert.ToString(r.Result_Id),
                          Date = r.Date,
                          Mesuretype = r.Mesuretype,
                          Values = r.Values,
                          Id_Affection = r.Affectation.Affectation_ID
                      };
            if (res == null)
            {
                return NotFound(new { Error = "Resultes not found" });
            }
            return Ok(res);
        }

        [HttpPost("PostResultes")]

        public async Task<ActionResult<ResulteDTO>> PostResultes([FromBody] ResulteDTO value)
        {
            var lastResult = _contxt.Resultes.OrderByDescending(s => s.Result_Id).FirstOrDefault();

            int a = lastResult != null ? lastResult.Result_Id : 0;

            Resultes res = new Resultes()
            {
                Result_Id = a+1,
                Date = value.Date,
                Mesuretype = value.Mesuretype,
                Values = value.Values,
                Agent = _contxt.Agent.Find(value.Id_Agent),
                Affectation = _contxt.Affectation.Find(value.Id_Affection)  
            };

            await _contxt.AddAsync(res);
            await _contxt.SaveChangesAsync();
            value.Result_Id = Convert.ToString(a + 1);
            

            return Ok(value);
        }




    }
}