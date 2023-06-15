namespace AdrGaspard.Tea.CommonTools
{
    public readonly struct Result : IEquatable<Result>
    {
        public const string NullErrorName = "Result : Null error";
        public const string SuccessName = "Result : Success";

        public static readonly Result Ok = new();

        private readonly ResultState _state;
        private readonly Exception? _error;

        public Result()
        {
            _state = ResultState.Success;
            _error = null;
        }

        private Result(Exception error)
        {
            _state = ResultState.Failure;
            _error = error;
        }

        public static implicit operator Result(Exception error)
        {
            return new(error);
        }

        public static bool operator ==(Result left, Result right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Result left, Result right)
        {
            return !(left == right);
        }

        public static Result Failure(Exception exception)
        {
            return exception;
        }

        public static Result<TValue> Failure<TValue>(Exception exception)
        {
            return exception;
        }

        public static Result<TValue> Success<TValue>(TValue value)
        {
            return value;
        }

        public bool IsFailure => _state == ResultState.Failure;

        public bool IsSuccess => _state == ResultState.Success;

        public Exception Error => _error!;

        public override string ToString()
        {
            return IsFailure ? _error?.ToString() ?? NullErrorName : SuccessName;
        }

        public void IfFailure(Action<Exception> function)
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

        public TResult Match<TResult>(Func<TResult> success, Func<Exception, TResult> failure)
        {
            return IsFailure ? failure(_error!) : success();
        }

        public Result<TResult> Map<TResult>(Func<TResult> function)
        {
            return IsFailure ? new Result<TResult>(_error!) : new Result<TResult>(function());
        }

        public async Task<Result<TResult>> MapAsync<TResult>(Func<Task<TResult>> function)
        {
            return IsFailure ? new Result<TResult>(_error!) : new Result<TResult>(await function());
        }

        public bool Equals(Result other)
        {
            return _state == other._state && ((_error is null && other._error is null) || _error!.Equals(other._error));
        }

        public override bool Equals(object? obj)
        {
            return obj is Result result && Equals(result);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_state, _error);
        }
    }

    public readonly struct Result<TValue> : IEquatable<Result<TValue>>
    {
        public const string NullValueName = "Result : Null value";

        private readonly ResultState _state;
        private readonly TValue? _value;
        private readonly Exception? _error;

        internal Result(TValue value)
        {
            _state = ResultState.Success;
            _value = value;
            _error = null;
        }

        internal Result(Exception error)
        {
            _state = ResultState.Failure;
            _error = error;
            _value = default;
        }

        public static implicit operator Result<TValue>(TValue value)
        {
            return new(value);
        }

        public static implicit operator Result<TValue>(Exception error)
        {
            return new(error);
        }

        public static bool operator ==(Result<TValue> left, Result<TValue> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Result<TValue> left, Result<TValue> right)
        {
            return !(left == right);
        }

        public bool IsFailure => _state == ResultState.Failure;

        public bool IsSuccess => _state == ResultState.Success;

        public Exception Error => _error!;

        public TValue Value => _value!;

        public override string ToString()
        {
            return IsFailure ? _error?.ToString() ?? Result.NullErrorName : _value?.ToString() ?? NullValueName;
        }

        public TValue IfFailure(TValue defaultValue)
        {
            return IsFailure ? defaultValue : _value!;
        }

        public TValue IfFailure(Func<Exception, TValue> function)
        {
            return IsFailure ? function(_error!) : _value!;
        }

        public void IfFailure(Action<Exception> function)
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

        public TResult Match<TResult>(Func<TValue, TResult> success, Func<Exception, TResult> failure)
        {
            return IsFailure ? failure(_error!) : success(_value!);
        }

        public Result<TResult> Map<TResult>(Func<TValue, TResult> function)
        {
            return IsFailure ? new Result<TResult>(_error!) : new Result<TResult>(function(_value!));
        }

        public async Task<Result<TResult>> MapAsync<TResult>(Func<TValue, Task<TResult>> function)
        {
            return IsFailure ? new Result<TResult>(_error!) : new Result<TResult>(await function(_value!));
        }

        public bool Equals(Result<TValue> other)
        {
            return _state == other._state &&
                ((_error is null && other._error is null) || _error!.Equals(other._error)) &&
                ((_value is null && other._value is null) || _value!.Equals(other._value));
        }

        public override bool Equals(object? obj)
        {
            return obj is Result<TValue> result && Equals(result);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_state, _value, _error);
        }
    }
}