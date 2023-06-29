using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.Contracts.OutputResults
{
    public readonly struct Response : IEquatable<Response>
    {
        public const string NullErrorName = $"{nameof(Response)} : Null error";
        public const string SuccessName = $"{nameof(Response)} : Success";

        public static readonly Response Ok = new();

        private readonly ResultState _state;
        private readonly ErrorResult? _error;

        public Response()
        {
            _state = ResultState.Success;
            _error = null;
        }

        private Response(ErrorResult error)
        {
            _state = ResultState.Failure;
            _error = error;
        }

        public bool IsFailure => _state == ResultState.Failure;

        public bool IsSuccess => _state == ResultState.Success;

        public ErrorResult Error => _error!;

        public static implicit operator Response(ErrorResult error)
        {
            return new(error);
        }

        public static bool operator ==(Response left, Response right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Response left, Response right)
        {
            return !(left == right);
        }

        public static Response Failure(ErrorResult ErrorResponse)
        {
            return ErrorResponse;
        }

        public static Response<TValue> Failure<TValue>(ErrorResult ErrorResponse)
        {
            return ErrorResponse;
        }

        public static Response<TValue> Success<TValue>(TValue value)
        {
            return value;
        }

        public override string ToString()
        {
            return IsFailure ? _error?.ToString() ?? NullErrorName : SuccessName;
        }

        public void IfFailure(Action<ErrorResult> function)
        {
            if (IsFailure)
            {
                function(_error!);
            }
        }

        public void IfSuccess(Action function)
        {
            if (IsSuccess)
            {
                function();
            }
        }

        public TResponse Match<TResponse>(Func<TResponse> success, Func<ErrorResult, TResponse> failure)
        {
            return IsFailure ? failure(_error!) : success();
        }

        public async Task<TResponse> MatchAsync<TResponse>(Func<TResponse> success, Func<ErrorResult, TResponse> failure)
        {
            ErrorResult error = _error!;
            return await (IsFailure ? Task.Run(() => failure(error)) : Task.Run(() => success()));
        }

        public Response<TResponse> Map<TResponse>(Func<TResponse> function)
        {
            return IsFailure ? new Response<TResponse>(_error!) : new Response<TResponse>(function());
        }

        public async Task<Response<TResponse>> MapAsync<TResponse>(Func<Task<TResponse>> function)
        {
            return IsFailure ? new Response<TResponse>(_error!) : new Response<TResponse>(await function());
        }

        public bool Equals(Response other)
        {
            return _state == other._state && ((_error is null && other._error is null) || _error!.Equals(other._error));
        }

        public override bool Equals(object? obj)
        {
            return obj is Response Response && Equals(Response);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_state, _error);
        }
    }

    public readonly struct Response<TValue> : IEquatable<Response<TValue>>
    {
        public const string NullValueName = $"{nameof(Response<TValue>)} : Null value";

        private readonly ResultState _state;
        private readonly TValue? _value;
        private readonly ErrorResult? _error;

        internal Response(TValue value)
        {
            _state = ResultState.Success;
            _value = value;
            _error = null;
        }

        internal Response(ErrorResult error)
        {
            _state = ResultState.Failure;
            _error = error;
            _value = default;
        }

        public bool IsFailure => _state == ResultState.Failure;

        public bool IsSuccess => _state == ResultState.Success;

        public ErrorResult Error => _error!;

        public TValue Value => _value!;

        public static implicit operator Response<TValue>(TValue value)
        {
            return new(value);
        }

        public static implicit operator Response<TValue>(ErrorResult error)
        {
            return new(error);
        }

        public static bool operator ==(Response<TValue> left, Response<TValue> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Response<TValue> left, Response<TValue> right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return IsFailure ? _error?.ToString() ?? Response.NullErrorName : _value?.ToString() ?? NullValueName;
        }

        public TValue IfFailure(TValue defaultValue)
        {
            return IsFailure ? defaultValue : _value!;
        }

        public TValue IfFailure(Func<ErrorResult, TValue> function)
        {
            return IsFailure ? function(_error!) : _value!;
        }

        public void IfFailure(Action<ErrorResult> function)
        {
            if (IsFailure)
            {
                function(_error!);
            }
        }

        public void IfSuccess(Action<TValue> function)
        {
            if (IsSuccess)
            {
                function(_value!);
            }
        }

        public TResponse Match<TResponse>(Func<TValue, TResponse> success, Func<ErrorResult, TResponse> failure)
        {
            return IsFailure ? failure(_error!) : success(_value!);
        }

        public async Task<TResponse> MatchAsync<TResponse>(Func<TValue, TResponse> success, Func<ErrorResult, TResponse> failure)
        {
            ErrorResult error = _error!;
            TValue value = _value!;
            return await (IsFailure ? Task.Run(() => failure(error)) : Task.Run(() => success(value)));
        }

        public Response<TResponse> Map<TResponse>(Func<TValue, TResponse> function)
        {
            return IsFailure ? new Response<TResponse>(_error!) : new Response<TResponse>(function(_value!));
        }

        public async Task<Response<TResponse>> MapAsync<TResponse>(Func<TValue, Task<TResponse>> function)
        {
            return IsFailure ? new Response<TResponse>(_error!) : new Response<TResponse>(await function(_value!));
        }

        public bool Equals(Response<TValue> other)
        {
            return _state == other._state &&
                ((_error is null && other._error is null) || _error!.Equals(other._error)) &&
                ((_value is null && other._value is null) || _value!.Equals(other._value));
        }

        public override bool Equals(object? obj)
        {
            return obj is Response<TValue> Response && Equals(Response);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_state, _value, _error);
        }
    }
}