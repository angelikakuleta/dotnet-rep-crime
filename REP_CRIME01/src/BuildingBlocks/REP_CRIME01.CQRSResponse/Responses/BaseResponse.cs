namespace REP_CRIME01.CQRSResponse.Responses
{
    public record BaseResponse
    {
        public ResponseStatus Status { get; init; } = ResponseStatus.Success;
        public object ErrorMessage { get; init; } = string.Empty;
        public bool IsSuccess => Status == ResponseStatus.Success;
    }

    public record BaseResponse<T> : BaseResponse
    {
        public T Result { get; init; }
    }
}
