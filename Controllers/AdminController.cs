using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using transformatek_MP.Models;
using Microsoft.AspNetCore.Mvc;
using transformatek_MP.Data;
using transformatek_MP.DTO;
using Microsoft.EntityFrameworkCore;
//using transformatek_MP.Models;

namespace transformatek_MP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly TransforamTek_MP_Context _context;
        public AdminController(TransforamTek_MP_Context context)
        {
            _context = context;
        }

        [HttpGet("Get_All_Affections/{admin_id:int}")]

        public ActionResult<IEnumerable<AffectionDTO>> Get_Affections(int admin_id)
        {
            var res = from a in _context.Affectation
                      join p in _context.Point on a.Affectation_ID equals p.Affectation_ID
                      join c in _context.Consigner on a.Affectation_ID equals c.Affectation_ID
                      where a.Admin.Admin_ID == admin_id
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


        [HttpGet("Affectations_By_AgentID/{agent_id:int}/{admin_id:int}")]
        public ActionResult<AffectionDTO> Get_AffectaionById(int admin_id, int agent_id)
        {
            var Res = from a in _context.Affectation
                      join p in _context.Point on a.Affectation_ID equals p.Affectation_ID
                      join c in _context.Consigner on a.Affectation_ID equals c.Affectation_ID

                      where a.Admin.Admin_ID == admin_id
                      where a.Agent.Id_Agent == agent_id
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

        [HttpGet("GetResultes_Of_All_Agents/{admin_id:int}")]

        public ActionResult<ResulteDTO> Get_Reslutes(int admin_id)
        {
            var resultsForAdmin = from a in _context.Affectation
                                  join ag in _context.Agent on a.Agent.Id_Agent equals ag.Id_Agent
                                  join r in _context.Resultes on ag.Id_Agent equals r.Agent.Id_Agent
                                  where a.Admin.Admin_ID == admin_id
                                  select new ResulteDTO
                                  {
                                      Date = r.Date,
                                      Id_Agent = ag.Id_Agent,
                                      Mesuretype = r.Mesuretype,
                                      Result_Id = Convert.ToString(r.Result_Id),
                                      Values = r.Values,
                                      Id_Affection = r.Affectation.Affectation_ID
                                  };

            return Ok(resultsForAdmin);

        }
        [HttpGet("GetResultes_Of_Specific_Agent/{admin_id:int}/{agent_id:int}")]

        public ActionResult<ResulteDTO> Get_ReslutesById(int admin_id, int agent_id)
        {
            var resultsForAdmin = from a in _context.Affectation
                                  join ag in _context.Agent on a.Agent.Id_Agent equals ag.Id_Agent
                                  join r in _context.Resultes on ag.Id_Agent equals r.Agent.Id_Agent
                                  where a.Admin.Admin_ID == admin_id
                                  where a.Agent.Id_Agent == agent_id
                                  select new ResulteDTO
                                  {
                                      Date = r.Date,
                                      Id_Agent = ag.Id_Agent,
                                      Mesuretype = r.Mesuretype,
                                      Result_Id = Convert.ToString(r.Result_Id),
                                      Values = r.Values,
                                      Id_Affection =r.Affectation.Affectation_ID
                                      
                                  };
            if (!resultsForAdmin.Any())
            {
                return NotFound(new { Error = "Affection not found" });

            }
            return Ok(resultsForAdmin);

        }


            [HttpPost("PostAffectations/{admin_id:int}/{agent_id:int}")]
            public async Task<ActionResult<AffectionDTO>> PostAffectations([FromBody] AffectionDTO value, int admin_id, int agent_id)
            {

                var lastResult = _context.Affectation.OrderBy(s => s.Affectation_ID).LastOrDefault();

                int a = lastResult != null ? lastResult.Affectation_ID : 0;
                ++a;
                Affectation res = new Affectation()
                {
                    Admin = _context.Admins.Find(admin_id),
                    Agent = _context.Agent.Find(agent_id),
                    Affectation_ID = a,
                    Description = value.Description,   /* handle null case */
                };
                Point res1 = new Point()
                {
                    Point_ID = value.Point_ID,
                    Lang = value.Lang,
                    Lat = value.Lat,
                    Affectation_ID = a,

                };
                Consigner res2 = new Consigner()
                {
                    Affectation_ID = a,
                    Consigner_ID = value.Conseigner_ID,
                    Nb_Repetations = value.Nb_Repetations,
                    Type_mesure = value.Type_mesure,
                };

                await _context.AddAsync(res);
                await _context.AddAsync(res1);
                await _context.AddAsync(res2);
                await _context.SaveChangesAsync();

                value.Affectation_ID = Convert.ToString(a);
                value.Agent_ID = agent_id;
                value.Admin_ID = admin_id;

                return Ok(value);
            }

        }
    }