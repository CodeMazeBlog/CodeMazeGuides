using System.Net;

namespace ActionAndFuncDelegatesInCSharp.AdvancedDelegates
{
    public class ExceptionHandlerService
    {
        Dictionary<string, Func<Exception, Error>> errorsDictionary;
        public ExceptionHandlerService()
        {
            errorsDictionary = new Dictionary<string, Func<Exception, Error>>
          {
              { nameof(NotFoundException), (ex) => GenerateNotFoundError(ex) },
              { nameof(ValidationException), (ex) => GenerateBadRequestError(ex) }
          };
        }

        public Error GetError(Exception ex) => errorsDictionary.ContainsKey(ex.GetType().Name) ? errorsDictionary[ex.GetType().Name](ex) : GenerateInternalServerError(ex);
        private Error GenerateInternalServerError(Exception ex) => new Error(ex.Message, (int)HttpStatusCode.InternalServerError);
        private Error GenerateNotFoundError(Exception ex) => new Error(ex.Message, (int)HttpStatusCode.NotFound);
        private Error GenerateBadRequestError(Exception ex) => new Error(ex.Message, (int)HttpStatusCode.BadRequest);
    }
}
