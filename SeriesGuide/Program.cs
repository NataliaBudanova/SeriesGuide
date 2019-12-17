using SeriesGuide.Core.ApplicationComponents;
using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;

namespace SeriesGuide
{
    class Program
    {
       
            static void Save(Dictionary<Type, Type> dataRepositoryTypes, string TypesFileName)
            {
                IJsonConvertor convertor = new JsonConvertor();
                convertor.Save<Dictionary<Type, Type>>(dataRepositoryTypes, TypesFileName);
            }
            static void Main(string[] args)
            {

                Container.Default(false).RegisterType<IRepository<Account>, AccountRepository>();
                Container.Default(false).RegisterType<IRepository<Film>, MovieRepository>();
                Container.Default(false).RegisterType<IRepository<Series>, SeriesRepository>();
                Container.Default(false).RegisterType<IJsonConvertor, JsonConvertor>();

                Container.Default(false).SaveContainerTypes(Save);

                Container.Default(true).RegisterType<IJsonConvertor, JsonConvertor>();

                Console.WriteLine($"{typeof(AccountRepository).GetInterfaces()[0].}");

        }   
    }
}
