using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Model;
using System.Text.RegularExpressions;
using FluentValidation;

namespace WebAPIDemo1.Service
{
    public class Validation:AbstractValidator<Book>
    {
        ErrorData errorData = new ErrorData();
        private List<Error> errorList = new List<Error>();

        public Validation()
        {
            RuleFor(book => book.Name).Must(IsNameValid);
            RuleFor(book => book.AuthorName).Must(IsAuthorNameValid);
            RuleFor(book => book.ISBNNumber).Must(IsInputNegative);
            RuleFor(book => book.Price).Must(IsPriceValid);
        }
        public bool IsInputNegative(int id)
        {
            if (id > 0) {
                
                return true;
            }
            errorList.Add(errorData.IDNegativeError);
            return false;
        }

        public bool IsPriceValid(double Price)
        {
            if (Price > 0)
            {
                return true;
            }

            errorList.Add(errorData.NegativePriceError);
            return false;
        }

        public bool IsAuthorNameValid(string AuthorName)
        {
            if(Regex.IsMatch(AuthorName, @"^[a-zA-Z\s]+$"))
            {
                return true;
            }

            errorList.Add(errorData.InvalidAuthorNameError);
            return false;
        }

        public bool IsNameValid(string Name)
        {
            if(!string.IsNullOrEmpty(Name))
            {
                return true;
            }
            errorList.Add(errorData.InvalidBookNameError);
            return false;
        }

        public List<Error> GetErrorList()
        {
            return errorList;
        }
    }
}
