namespace DependancyInjection.Services
{
    /// <summary>
    /// Defines the Education interface with a Teach method.
    /// </summary>
    public interface IEducation
    {
        /// <summary>
        /// Abstract Teach method to be implemented by classes that use this interface.
        /// </summary>
        void Teach();
    }
}