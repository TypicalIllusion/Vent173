using Exiled.Events.EventArgs;
using MEC;

namespace Vent173.Handlers
{
    class Server
    {
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            foreach (CoroutineHandle coroutine in Vent173.Coroutine)
                Timing.KillCoroutines(coroutine);
        }
    }
}
