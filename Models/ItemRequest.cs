using Swashbuckle.AspNetCore.Filters;

namespace ItemCounterApi.Models;

/// <summary>
/// Represents a request containing a list of items whose occurrences will be counted.
/// </summary>
/// <remarks>
/// Each item can be of any JSON-compatible type (e.g., string, number, boolean, null).
/// </remarks>
public class ItemRequest
{
    /// <summary>
    /// The list of items to be counted.
    /// </summary>
    /// <example>["apple", 42, true, "apple", null]</example>
    public required List<object> Items { get; set; }

}

/// <summary>
/// Provides an example of an <see cref="ItemRequest"/> for Swagger UI.
/// </summary>
public class ItemRequestExample : IExamplesProvider<ItemRequest>
{
    /// <summary>
    /// Gets the example <see cref="ItemRequest"/>.
    ///
    /// </summary>
    /// <returns>An example <see cref="ItemRequest"/>.</returns>
    public ItemRequest GetExamples()
    {
        return new ItemRequest
        {
            Items = new List<object> { "apple", 42, true, "apple", null, 42 }
        };
    }
}
