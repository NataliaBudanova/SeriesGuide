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
                instance.repositoryTypes = convertor.UpLoad<Dictionary<Type, Type>>(Path.Combine(FolderPath, RepositoryTypesFileName));
                foreach (var item in instance.repositoryTypes)
                {

                    instance.Repositories[item.Key] = instance.Resolve(item.Key);
                }

                return instance;
            }
            else
                return instance;

        }

        private Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();
        private Dictionary<Type, Type> repositoryTypes = new Dictionary<Type, Type>();

        public void SaveContainerTypes(Action<Dictionary<Type, Type>, Dictionary<Type, Type>, string, string> convertor)
        {
            convertor?.Invoke(types, repositoryTypes, Path.Combine(FolderPath, TypesFileName), Path.Combine(FolderPath, RepositoryTypesFileName));
        }
        /*public void UdateRepository(Type itemType,object item)
        {
            repositories[itemType].Add(item);
        }*/

        public void RegisterRepository<TInterface, TClass>()
        {
            RegisterRepository(typeof(TInterface), typeof(TClass));
        }

        private void RegisterRepository(Type interfaceType, Type classType)
        {
            repositoryTypes[interfaceType] = classType;
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

        private const string RepositoryTypesFileName = "RepositoryTypesData.json";
        private const string TypesFileName = "TypesData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";



    }
}
