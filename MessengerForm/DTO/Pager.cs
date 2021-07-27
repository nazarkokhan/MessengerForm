﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MessengerForm.DTO
{
    public class Pager<TData>
    {
        public Pager(IReadOnlyCollection<TData> data, long totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }

        [DataMember]
        public IReadOnlyCollection<TData> Data { get; }

        public long TotalCount { get; }
    }
}