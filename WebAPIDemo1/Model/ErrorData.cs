using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Service;

namespace WebAPIDemo1.Model
{
    public class ErrorData
    {
        public Error BookNotFoundError = new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Book Not Found" };
        public Error ISBNNumberTakenError = new Error { StatusCode = 400, ErrorMessages = "ERROR!!! ISBN Number taken" };
        public Error IDNegativeError = new Error { StatusCode = 400, ErrorMessages = "ERROR!!! ID must be Positive" };
        public Error InvalidBookNameError = new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Enter Valid Book Name" };
        public Error InvalidAuthorNameError = new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Enter Valid Author Name" };
        public Error NegativePriceError = new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Enter positive value for Price" };
    }
}
