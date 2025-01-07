namespace UniqueListLibrary
{
    /// <summary>
    /// Represents a collection of unique elements that prevents duplicate entries.
    /// Inherits from <see cref="List{T}"/> and overrides the Add and AddRange methods to ensure uniqueness.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class UniqueList<T> : List<T>
    {
        /// <summary>
        /// Adds an element to the list if it is not already present, ensuring uniqueness.
        /// If the item already exists in the list, it will not be added.
        /// </summary>
        /// <param name="item">The element to add to the list.</param>
        public new void Add(T item)
        {
            // Check if the item is already in the list
            if (!Contains(item))
            {
                base.Add(item); // Add the item if it's unique
            }
        }

        /// <summary>
        /// Adds a collection of elements to the list, ensuring that only unique elements are added.
        /// Duplicates within the collection will be ignored.
        /// </summary>
        /// <param name="collection">The collection of elements to add to the list.</param>
        public new void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item); // Use the overridden Add method to ensure uniqueness
            }
        }
    }
}
