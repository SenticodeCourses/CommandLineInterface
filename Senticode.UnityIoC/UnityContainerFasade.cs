using System;
using Senticode.AppEnvironment.Common.Interfaces;
using Unity;

namespace Senticode.UnityIoC
{
    internal class UnityContainerFasade : IIoCContainer
    {
        public UnityContainerFasade()
        {
            Container.RegisterInstance<IIoCContainer>(this);
        }

        private IUnityContainer Container { get; set; } = new UnityContainer();

        public void Dispose()
        {
            Container.Dispose();
            Container = null;
        }

        public Guid Id { get; } = Guid.NewGuid();

        public bool IsRegistered<T>(string name = null)
        {
            return name != null ? Container.IsRegistered<T>(name) : Container.IsRegistered<T>();
        }

        public bool IsRegistered(Type type, string name = null)
        {
            return name != null ? Container.IsRegistered(type, name) : Container.IsRegistered(type);
        }

        public IIoCContainer RegisterType<T>(string name = null)
        {
            if (name != null)
            {
                Container.RegisterType<T>(name);
            }
            else
            {
                Container.RegisterType<T>();
            }

            return this;
        }

        public IIoCContainer RegisterType<TFrom, TTo>(string name = null) where TTo : TFrom
        {
            if (name != null)
            {
                Container.RegisterType<TFrom, TTo>(name);
            }
            else
            {
                Container.RegisterType<TFrom, TTo>();
            }

            return this;
        }

        public T RegisterInstance<T>(T instance, string name = null)
        {
            if (name != null)
            {
                Container.RegisterInstance(typeof(T), name, instance);
            }
            else
            {
                Container.RegisterInstance(typeof(T), instance);
            }

            return instance;
        }

        public T Resolve<T>(string name = null)
        {
            if (name != null)
            {
                return Container.Resolve<T>(name);
            }

            return Container.Resolve<T>();
        }

        public object Resolve(Type type, string name = null)
        {
            if (name != null)
            {
                return Container.Resolve(type, name);
            }

            return Container.Resolve(type);
        }
    }
}
