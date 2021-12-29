using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MandatoryQueryStringParameters
{
    public class QueryParameters
    {
        public int id { get; set; }

        [BindRequired]
        public int number { get; set; }
    }
}
