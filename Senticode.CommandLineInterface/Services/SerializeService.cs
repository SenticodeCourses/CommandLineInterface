using System;
using CommandLineInterface.Interfaces;

namespace CommandLineInterface.Services
{
    /// <summary>
    /// Записывает все свойства AppCommands в xml файл при выходе из приложения,
    /// и при старте приложения в методе Application.Initialize()
    /// заполняет свойства AppCommands из xml.
    /// </summary>
    public class SerializeService : ISerializeService
    {
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public void Deserialize()
        {
            throw new NotImplementedException();
        }
    }
}
