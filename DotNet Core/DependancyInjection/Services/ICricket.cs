namespace DependancyInjection.Services
{
    /// <summary>
    /// Defines the Cricket interface with a Play method.
    /// </summary>
    public interface ICricket
    {
        /// <summary>
        /// Abstract Play method to be implemented by classes that use this interface.
        /// </summary>
        void Play();
    }
}