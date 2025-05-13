using MyPlant.Services.Interfaces;
using System.Diagnostics;

namespace MyPlant.Services
{
    public class LogFileService : ILogService
    {
        public async Task Log(string logText)
        {
            await Task.Delay(2000);
            
            Debug.WriteLine("log registrado en archivo de texto");
        }
    }
}
