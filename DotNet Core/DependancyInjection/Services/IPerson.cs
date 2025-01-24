namespace DependancyInjection.Services
{
    /// <summary>
    /// Defines the Person interface with properties and methods related to education, greeting, playing, and teaching.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Gets or sets the Education service.
        /// </summary>
        IEducation objEducation { set; }

        /// <summary>
        /// Abstract Greet method to be implemented by classes that use this interface.
        /// </summary>
        void Greet();

        /// <summary>
        /// Abstract Play method to be implemented by classes that use this interface.
        /// </summary>
        /// <param name="objCricket">An object implementing the ICricket interface.</param>
        void Play(ICricket objCricket);

        /// <summary>
        /// Abstract Teach method to be implemented by classes that use this interface.
        /// </summary>
        void Teach();
    }
}