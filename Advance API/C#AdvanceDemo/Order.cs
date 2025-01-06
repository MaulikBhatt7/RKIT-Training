namespace CSharpAdvanceDemo
{
    /// <summary>
    /// Represents an order made by a person.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the person who placed the order.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the order.
        /// </summary>
        public int TotalAmount { get; set; }
    }
}
