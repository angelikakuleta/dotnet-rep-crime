using REP_CRIME01.Crime.Application.Responses;

namespace REP_CRIME01.Crime.API.Extensions
{
    public static class BaseResponseextensions
    {
        public static int GetStatusCode(this BaseResponse response)
        {
            return response.Status switch
            {
                ResponseStatus.Success => 200,
                ResponseStatus.BadQuery => 400,
                ResponseStatus.ValidationError => 400,
                ResponseStatus.NotFound => 404,
                _ => 500
            };
        }
    }
}
