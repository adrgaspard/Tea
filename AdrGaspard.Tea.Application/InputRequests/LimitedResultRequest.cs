﻿using System.ComponentModel.DataAnnotations;

namespace AdrGaspard.Tea.Application.InputRequests
{
    [Serializable]
    public class LimitedResultRequest : ILimitedResultRequest, IValidatableObject
    {
        public virtual int DefaultMaxResultCount => 10;
        public virtual int MaxMaxResultCount => 1000;

        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }

        public LimitedResultRequest()
        {
            MaxResultCount = DefaultMaxResultCount;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MaxResultCount > MaxMaxResultCount)
            {
                // TODO : localization
                yield return new ValidationResult($"The {nameof(MaxResultCount)} exceeded the maximum accepted value ({MaxMaxResultCount})!", new[] { nameof(MaxResultCount) });
            }
        }
    }
}