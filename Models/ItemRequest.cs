namespace ItemCounterApi.Models
{
    using Swashbuckle.AspNetCore.Filters;
    /// <summary>
    /// Represents a request with a list of items to count.
    /// </summary>
    /// <remarks>
    /// ### Sample Request Body
    /// 
    ///
    public class ItemRequest
    {
        /// <summary>
        /// The list of items to be counted.
        /// </summary>
        public required List<object> Items { get; set; }
    }

    /// <summary>
    /// Provides a sample request body for the ItemRequest model.
    /// </summary>
    public class ItemRequestExample : IExamplesProvider<ItemRequest>
    {
        public ItemRequest GetExamples()
        {
            return new ItemRequest { Items = new List<object> { "apple", 42, true, "apple", null, 42 } };
        }
    }
}
