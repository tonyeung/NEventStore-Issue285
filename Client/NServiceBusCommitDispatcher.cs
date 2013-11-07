using NEventStore;
using NEventStore.Dispatcher;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public sealed class NServiceBusCommitDispatcher<T> : IDispatchCommits
    {

        public IBus Bus { get; set; }

        public void Dispatch(Commit commit)
        {
            for (var i = 0; i < commit.Events.Count; i++)
            {
                try
                {
                    var eventMessage = commit.Events[i];
                    var busMessage = (T)eventMessage.Body;
                    Bus.Publish(busMessage);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    } 
}
