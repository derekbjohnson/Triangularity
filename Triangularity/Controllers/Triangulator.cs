using Microsoft.AspNetCore.Mvc;
using Triangularity.Models;

namespace Triangularity.Controllers
{
    [Route("api/[controller]")]
    public class Triangulator : Controller
    {
        //Return coordinates of the given triangle
        // GET api/Triangulator/{row}/{column}
        [HttpGet("{row}/{column}")]
        public JsonResult Get(char row, int column)
        {
            var img = new Image();
            return Json(img.GetVerticesByRowCol(row, column));
        }

        // Given the vertex coordinates, calculate the row and column for the triangle
        // GET api/Triangulator/Coordinates
        [HttpGet("{v1x}/{v1y}/{v2x}/{v2y}/{v3x}/{v3y}")]
        public JsonResult FindByCoordinates(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            var img = new Image();
            return Json(img.GetLocationByVertices(v1x, v1y, v2x, v2y, v3x, v3y));
        }
    }
}
