﻿using System.ComponentModel;

namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    public class SortSpecificationRequest
    {
        public ListSortDirection SortDirection { get; init; }

        public string PropertyName { get; init; }
    }
}