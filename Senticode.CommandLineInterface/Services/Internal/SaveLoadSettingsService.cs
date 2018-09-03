using System.Threading.Tasks;
using CommandLineInterface.Interfaces;

namespace CommandLineInterface.Services.Internal
{
    internal class SaveLoadSettingsService : ISaveLoadSettingsService
    {
        public async Task SaveAsync(AppSettingsBase settings)
        {
            //TODO throw new System.NotImplementedException();
            await Task.Delay(1000);
            return;
        }

        public async Task LoadAsync(AppSettingsBase settings)
        {
            //TODO throw new System.NotImplementedException();
            await Task.Delay(1000);
            return;
        }
    }
}