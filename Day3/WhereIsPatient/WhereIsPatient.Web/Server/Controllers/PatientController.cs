using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WhereIsPatient.DB;
using WhereIsPatient.DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WhereIsPatient.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        //private readonly WhereIsPatientContext _dbContext;
        private readonly IDbContextFactory<WhereIsPatientContext> _dbContextFactory;     

        public PatientController(IDbContextFactory<WhereIsPatientContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public Patient Get(string id)
        {
            return null;
        }

        // GET api/<PatientController>/5
        [HttpGet("GetAsync")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Patient))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync([FromQuery] string umrn)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                Patient searchPatient = new Patient();

                searchPatient = context.Patients.Where(p => p.UMRN == umrn).SingleOrDefault();

                if(searchPatient == null || string.IsNullOrEmpty(searchPatient.FirstName))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(searchPatient);
                }
            }
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
