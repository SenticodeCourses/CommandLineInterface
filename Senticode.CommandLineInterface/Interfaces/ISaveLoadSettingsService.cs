using System.Threading.Tasks;

namespace CommandLineInterface.Interfaces
{
    internal interface ISaveLoadSettingsService
    {
        Task SaveAsync(AppSettingsBase settings);
        Task LoadAsync(AppSettingsBase settings);
    }
}