using Microsoft.AspNetCore.Mvc;
using System;
using Triangularity.Models;

namespace Triangularity.Controllers
{
    [Route("api/[controller]")]
    public class Triangulator : Controller
    {
        //Return coordinates of the given triangle
        // GET api/Triangulator/{row}/{column}
        [HttpGet("{row}/{column}")]
        public IActionResult Get(char row, int column)
        {
            try
            {
                var img = new Image();
                return new ObjectResult(img.GetVerticesByRowCol(row, column));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // Given the vertex coordinates, calculate the row and column for the triangle
        // GET api/Triangulator/Coordinates
        [HttpGet("{v1x}/{v1y}/{v2x}/{v2y}/{v3x}/{v3y}")]
        public IActionResult FindByCoordinates(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            try
            {
                var img = new Image();
                return new ObjectResult(img.GetLocationByVertices(v1x, v1y, v2x, v2y, v3x, v3y));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
