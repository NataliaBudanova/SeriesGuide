using SeriesGuide.Core.ApplicationComponents;
using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;

namespace SeriesGuide
{
    class Program
    {
       
            static void Save(Dictionary<Type, Type> dataRepositoryTypes, string TypesFileName, string RepositoryTypesFileName)
            {
                IJsonConvertor convertor = new JsonConvertor();
                /*convertor.Save<Dictionary<Type, Type>>(dataTypes, TypesFileName);*/
                convertor.Save<Dictionary<Type, Type>>(dataRepositoryTypes, RepositoryTypesFileName);
            }
            static void Main(string[] args)
            {

                Container.Default(false).RegisterType<IRepository<Account>, AccountRepository>();
                Container.Default(false).RegisterType<IRepository<Film>, MovieRepository>();
                Container.Default(false).RegisterType<IRepository<Series>, SeriesRepository>();
                Container.Default(false).RegisterType<IJsonConvertor, JsonConvertor>();

                /*Container.Default(false).RegisterRepository<IRepository<Account>, AccountRepository>();
                Container.Default(false).RegisterRepository<IRepository<Film>, MovieRepository>();
                Container.Default(false).RegisterRepository<IRepository<Series>, SeriesRepository>();*/

                Container.Default(false).SaveContainerTypes(Save);
            }   
    }
}
