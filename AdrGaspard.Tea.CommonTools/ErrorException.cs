﻿namespace AdrGaspard.Tea.CommonTools
{
    public abstract class ErrorException : Exception
    {
        protected ErrorException() { }

        protected ErrorException(string? message) : base(message) { }

        protected ErrorException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
