using System;

namespace Senticode.AppEnvironment.Common.Interfaces
{
    public interface IIoCContainer : IDisposable
    {
        Guid Id { get; }
        bool IsRegistered<T>(string name = null);
        bool IsRegistered(Type type, string name = null);
        IIoCContainer RegisterType<T>(string name = null);

        IIoCContainer RegisterType<TFrom, TTo>(string name = null) where TTo : TFrom;

        T RegisterInstance<T>(T instance, string name = null);

        T Resolve<T>(string name = null);
        object Resolve(Type type, string name = null);
    }
}
