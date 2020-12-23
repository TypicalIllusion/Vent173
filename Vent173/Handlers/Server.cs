using Exiled.Events.EventArgs;
using MEC;
using EPlayer = Exiled.API.Features.Player;
using static Vent173.Vent173;

namespace Vent173.Handlers
{
    class Server
    {
        public void OnRoundStarted()
        {
            foreach (EPlayer ply in EPlayer.List)
            {
                Timing.CallDelayed(0.1f, () =>
                {
                    Timing.RunCoroutine(Vent.VentCooldown(Singleton.Config.VentCooldown, ply));
                });
            }
        }
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            foreach (CoroutineHandle coroutine in Coroutine)
                Timing.KillCoroutines(coroutine);
        }
    }
}
