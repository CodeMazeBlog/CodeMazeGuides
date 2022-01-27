using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MandatoryQueryStringParameters
{
    public class QueryParameters
    {
        public int Id { get; set; }

        [BindRequired]
        public int Number { get; set; }
    }
}
