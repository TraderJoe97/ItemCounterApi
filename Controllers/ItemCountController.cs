using Microsoft.AspNetCore.Mvc;
using ItemCounterApi.Models;
using System.Text.Json;

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
        /// <param name="request">The request containing the list of items to count.</param>  
        /// <returns>A dictionary with item occurrences or a bad request response if the input is invalid.</returns>  
        [HttpPost]
        [ProducesResponseType(typeof(Dictionary<string, int>), 200)]
        [ProducesResponseType(400)]
        public IActionResult CountItems([FromBody] ItemRequest request)
        {
            if (request?.Items == null || !request.Items.Any())
                return BadRequest("The list of items must not be empty.");

            var normalized = request.Items.Select(item => JsonSerializer.Serialize(item));
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
