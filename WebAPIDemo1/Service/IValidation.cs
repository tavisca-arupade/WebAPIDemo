using FluentValidation;
using System.Collections.Generic;
using WebAPIDemo1.Model;

namespace WebAPIDemo1.Service
{
    public interface IValidation : IValidator
    {

        bool IsInputNegative(int id);
        bool IsPriceValid(double Price);
        bool IsAuthorNameValid(string AuthorName);
        bool IsNameValid(string Name);
        List<Error> GetErrorList();
    }
}
