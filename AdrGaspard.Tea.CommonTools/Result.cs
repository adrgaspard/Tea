namespace AdrGaspard.Tea.CommonTools
{
    public readonly struct Result : IEquatable<Result>
    {
        public const string NullErrorName = $"{nameof(Result)} : Null error";
        public const string SuccessName = $"{nameof(Result)} : Success";

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

        public bool IsFailure => _state == ResultState.Failure;

        public bool IsSuccess => _state == ResultState.Success;

        public Exception Error => _error!;

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

        public Result With(Result other)
        {
            return IsFailure ? this : other;
        }

        public Result<TValue> With<TValue>(Result<TValue> other)
        {
            return IsFailure ? Error : other;
        }

        public override string ToString()
        {
            return IsFailure ? _error?.ToString() ?? NullErrorName : SuccessName;
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
        public const string NullValueName = $"{nameof(Result<TValue>)} : Null value";

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

        public bool IsFailure => _state == ResultState.Failure;

        public bool IsSuccess => _state == ResultState.Success;

        public Exception Error => _error!;

        public TValue Value => _value!;

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

        public Result<TValue> With(Result other)
        {
            return IsFailure ? this : other.IsFailure ? other.Error : this;
        }

        public Result<(TValue, TOtherValue)> With<TOtherValue>(Result<TOtherValue> other)
        {
            return IsFailure ? Error : other.IsFailure ? other.Error : (Value, other.Value);
        }

        public override string ToString()
        {
            return IsFailure ? _error?.ToString() ?? Result.NullErrorName : _value?.ToString() ?? NullValueName;
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