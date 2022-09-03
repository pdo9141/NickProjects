using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace EventsAreObsoleteApi
{
    public class EverySecondHandler : INotificationHandler<TimedNotification>
    {
        private readonly TransientService _transientService;

        public EverySecondHandler(TransientService transientService)
        {
            _transientService = transientService;
        }

        public Task Handle(TimedNotification notification, CancellationToken cancellationToken)
        {
            // When leveraging MediatR instead of traditional Events you now get the proper transient Id printed
            Console.WriteLine(_transientService.Id);
            Console.WriteLine(notification.Time.ToLongTimeString());
            return Task.CompletedTask;
        }
    }
}