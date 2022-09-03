using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAreObsoleteApi
{
    public class TransientService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}