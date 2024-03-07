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
        private readonly carrerasContext _carrerasContext;
        public carreraController(carrerasContext context)
        {
            _carrerasContext = context;
        }
        [HttpGet]
        [Route("GetAll")] 
        public IActionResult Get()
        {
            List<carreras> listadoCarreras=(from e in _carrerasContext.carreras select e).ToList();

            if (listadoCarreras.Count == 0) return NotFound();
            return Ok(listadoCarreras);

        }
        [HttpGet]
        [Route("GetAllFiltered")]
        public IActionResult FiltroPorId(int id)
        {
            carreras? listadoCarreras = (from e in _carrerasContext.carreras where e.carrera_id==id select e).FirstOrDefault();

            if (listadoCarreras ==null) return NotFound();
            return Ok(listadoCarreras);

        }
        [HttpPost]
        [Route("Post")]
        public IActionResult agregarCarrera([FromBody] carreras carrera)
        {
            try
            {
                _carrerasContext.carreras.Add(carrera);
                _carrerasContext.SaveChanges();
                return Ok(carrera);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        [Route("Put")]
        public IActionResult actualizarCarrera(int id,[FromBody] carreras carreraModificar)
        {
            carreras? CarreraActualizar = (from e in _carrerasContext.carreras where e.carrera_id == id select e).FirstOrDefault();

            if (CarreraActualizar == null) return NotFound();
            

            CarreraActualizar.nombre_carrera= carreraModificar.nombre_carrera;
            _carrerasContext.Entry(CarreraActualizar).State=EntityState.Modified;
            _carrerasContext.SaveChanges();
           return Ok(CarreraActualizar);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult EliminarCarrera(int id)
        {
            carreras? CarreraBorrar = (from e in _carrerasContext.carreras where e.carrera_id == id select e).FirstOrDefault();

            if (CarreraBorrar == null) return NotFound();

            _carrerasContext.carreras.Attach(CarreraBorrar);
            _carrerasContext.carreras.Remove(CarreraBorrar);
            _carrerasContext.SaveChanges(); 
            return Ok(CarreraBorrar);
        }
    }
}


