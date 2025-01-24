namespace DependancyInjection.Services
{
    /// <summary>
    /// Defines the Home interface with a Greet method.
    /// </summary>
    public interface IHome
    {
        /// <summary>
        /// Abstract Greet method to be implemented by classes that use this interface.
        /// </summary>
        void Greet();
    }
}