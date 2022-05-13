﻿using NewOcean.Core.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOcean.Core.Events
{
    public abstract class Message : IRequest<ResponseBase>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
