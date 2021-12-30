using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MandatoryQueryStringParameters
{
    public class QueryParameters
    {
        public int Id { get; set; }

        [BindRequired]
        public int Number { get; set; }
    }
}
