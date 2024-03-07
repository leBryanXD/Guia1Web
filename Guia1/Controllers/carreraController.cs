using Guia1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Guia1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class carreraController : ControllerBase
    {
        private readonly equiposContext _equiposContext;
        public carreraController(equiposContext context)
        {
            _equiposContext = context;
        }
        [HttpGet]
        [Route("GetAll")] 
        public IActionResult Get()
        {
            List<carreras> listadoCarreras=(from e in _equiposContext.carreras select e).ToList();

            if (listadoCarreras.Count == 0) return NotFound();
            return Ok(listadoCarreras);

        }
    }
}


