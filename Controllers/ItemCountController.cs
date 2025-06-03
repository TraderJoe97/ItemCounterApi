using Microsoft.AspNetCore.Mvc;
using ItemCounterApi.Models;
using System.Text.Json;
using System.Net.Mime;

namespace ItemCounterApi.Controllers
{
    /// <summary>  
    /// API controller for counting item occurrences in a list.  
    /// </summary>  
    [ApiController]
    [Route("api/[controller]")]
    public class ItemCountController : ControllerBase
    {
        /// <summary>  
        /// Counts the occurrences of items in the provided list.  
        /// </summary>  
        /// <remarks>  
        /// This endpoint accepts a JSON object with a single property, "items",  
        /// which is an array of items (strings, numbers, objects, etc.).  
        /// It returns a JSON object where keys are the unique items from the input  
        /// list (converted to their string representation) and values are their  
        /// respective counts.  
        ///  
        /// Example Request Body:  
        ///  
        ///     POST /api/ItemCount  
        ///     Content-Type: application/json  
        ///  
        ///     {  
        ///        "items": ["apple", 123, "banana", "apple", {"name": "test"}, 123]  
        ///     }  
        ///  
        /// Example Success Response (200 OK):  
        ///  
        ///     Content-Type: application/json  
        ///  
        ///     {  
        ///        "apple": 2,  
        ///        "123": 2,  
        ///        "banana": 1,  
        ///        "{\"name\":\"test\"}": 1  
        ///     }  
        ///  
        /// Example Error Response (400 Bad Request):  
        ///  
        ///     Content-Type: application/problem+json  
        ///  
        ///     {  
        ///         "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",  
        ///         "title": "Bad Request",  
        ///         "status": 400,  
        ///         "detail": "The list of items must not be empty.",  
        ///         "instance": "/api/ItemCount"  
        ///     }  
        /// </remarks>  
        /// <param name="request">The request containing the list of items to count.</param>  
        /// <returns>A dictionary with item occurrences or a bad request response if the input is invalid.</returns>  
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dictionary<string, int>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CountItems([FromBody] ItemRequest request)
        {
            if (request?.Items == null || !request.Items.Any())
                return BadRequest("The list of items must not be empty.");

            var normalized = request.Items.Select(item => JsonSerializer.Serialize(item)).ToList();
            var counted = CountOccurrences(normalized);

            var readable = counted.ToDictionary(
                kvp => JsonSerializer.Deserialize<object>(kvp.Key)?.ToString() ?? "null",
                kvp => kvp.Value
            );

            return Ok(readable);
        }

        private Dictionary<T, int> CountOccurrences<T>(IEnumerable<T> items) where T : notnull
        {
            var counts = new Dictionary<T, int>();
            foreach (var item in items)
            {
                counts[item] = counts.GetValueOrDefault(item, 0) + 1;
            }
            return counts;
        }
    }
}
