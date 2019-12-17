using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class Container
    {
        private static Container instance = new Container();
        private Container() { }
        public static Container Default(bool UpLoad)
        {

            if (UpLoad)
            {
                IJsonConvertor convertor = new JsonConvertor();
                instance.types = convertor.UpLoad<Dictionary<Type, Type>>(Path.Combine(FolderPath, TypesFileName));
                instance.repositories = instance.types.Where(i => (i.Key.GetType()).IsAssignableFrom(typeof(IRepository<object>)))
                    .ToDictionary(i => i.GetType(), i => instance.Resolve(i.GetType()));

                return instance;
            }
            else
                return instance;

        }

        private Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public void SaveContainerTypes(Action<Dictionary<Type, Type>, string> convertor)
        {
            convertor?.Invoke(types, Path.Combine(FolderPath, TypesFileName));
        }

        public void RegisterType<TInterface, TClass>()
        {
            RegisterType(typeof(TInterface), typeof(TClass));
        }

        private void RegisterType(Type interfaceType, Type classType)
        {
            types[interfaceType] = classType;
        }

        private object Resolve(Type interfaceType)
        {
            Type classType;
            if (types.TryGetValue(interfaceType, out classType))
            {
                var ctor = classType.GetConstructors().First();
                object[] param = ctor.GetParameters().Select(p => Resolve(p.ParameterType)).ToArray();
                return ctor.Invoke(param);
            }
            else
                throw new ArgumentException(string.Format("Type implementing {0} not registered", interfaceType.Name));
        }
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private const string TypesFileName = "TypesData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";



    }
}
