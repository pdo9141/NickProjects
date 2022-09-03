using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace EventsAreObsoleteApi
{
    public class TimedNotification : INotification
    {
        public TimedNotification(TimeOnly time)
        {
            Time = time;
        }

        public TimeOnly Time { get; }
    }
}