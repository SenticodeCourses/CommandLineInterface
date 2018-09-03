using System.Threading.Tasks;
using CommandLineInterface.Interfaces;
using CommandLineInterface.Services.Internal;

namespace CommandLineInterface
{
    /// <summary>
    ///     This class contains global settings.
    /// </summary>
    public abstract class AppSettingsBase
    {
        ISaveLoadSettingsService Service { get; } = new SaveLoadSettingsService();

        public AppSettingsBase()
        {
            
        }

        /// <summary>
        ///     Realize command validation.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool Validate(string command, string[] parameters, out object value);
        /// <summary>
        ///     Save settings.
        /// </summary>
        /// <returns></returns>
        public virtual async Task SaveAsync() => await Service.SaveAsync(this);
        /// <summary>
        ///     Load saved settings.
        /// </summary>
        /// <returns></returns>
        public virtual async Task LoadAsync() => await Service.LoadAsync(this);
    }
}
