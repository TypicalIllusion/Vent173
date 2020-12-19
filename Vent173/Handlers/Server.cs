using Exiled.Events.EventArgs;
using MEC;
using EPlayer = Exiled.API.Features.Player;
using static Vent173.Vent173;

namespace Vent173.Handlers
{
    class Server
    {
        public void OnRoundStart(float duration, EPlayer pp)
        {
            Timing.RunCoroutine(Vent.VentCooldownStart(Singleton.Config.VentCooldownStart, pp));
        }
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            foreach (CoroutineHandle coroutine in Coroutine)
                Timing.KillCoroutines(coroutine);
        }
    }
}
