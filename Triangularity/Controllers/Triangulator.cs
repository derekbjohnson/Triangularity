using Microsoft.AspNetCore.Mvc;
using Triangularity.Models;

namespace Triangularity.Controllers
{
    [Route("api/[controller]")]
    public class Triangulator : Controller
    {
        // GET: api/Triangulator
        [HttpGet]
        public IActionResult Get()
        {
            //Return all triangle coordinates in JSON
            var img = new Image();
            return new ObjectResult(img.GetAllVertices());
        }

        // GET api/Triangulator/{row}/{column}
        [HttpGet("{row}/{column}")]
        public IActionResult Get(char row, int column)
        {
            try
            {
                var img = new Image();

                //Return coordinates of the given triangle
                return new ObjectResult(img.GetVerticesByRowCol(row, column));
            }
            catch { return NotFound(); }
        }

        // Given the vertex coordinates, calculate the row and column for the triangle
        // GET api/Triangulator/Coordinates
        [HttpGet("{vertex1}")]
        public string FindByCoordinates(string vertex1)
        {
            return "Coming soon";
        }
    }
}
