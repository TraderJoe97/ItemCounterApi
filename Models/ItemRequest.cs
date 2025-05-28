namespace ItemCounterApi.Models
{
    /// <summary>
    /// Represents a request with a list of items to count.
    /// </summary>
    public class ItemRequest
    {
        /// <summary>
        /// The list of items to be counted.
        /// </summary>
        public required List<object> Items { get; set; }
    }
}
