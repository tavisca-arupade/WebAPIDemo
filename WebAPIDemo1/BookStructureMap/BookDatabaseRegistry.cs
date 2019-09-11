using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Database;
using WebAPIDemo1.Model;
using WebAPIDemo1.Service;

namespace WebAPIDemo1.BookStructureMap
{
    public class BookDatabaseRegistry : Registry
    {
        public BookDatabaseRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            For<IBookDatabase>().Use<BookDatabase>();
        }
    }
}

