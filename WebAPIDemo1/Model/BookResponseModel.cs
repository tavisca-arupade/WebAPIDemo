using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Service;

namespace WebAPIDemo1.Model
{
    public class BookResponseModel
    {
        public Book BookData { get; set; }
        public List<Error> ErrorData { get; set; }
    }
}
