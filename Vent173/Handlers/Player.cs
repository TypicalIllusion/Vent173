using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;

namespace Vent173.Handlers
{
    class Player
    {
        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Attacker.Role == RoleType.Scp173 && ev.Attacker.IsInvisible)
            {
                ev.IsAllowed = false;
                ev.Amount = 0f;
            }
        }
        public void OnInteract(InteractingDoorEventArgs ev)
        {
            if (ev.Player.Role != RoleType.Scp173 || !ev.Player.IsInvisible)
                return;

            if (Vector3.Distance(ev.Player.Position, ev.Door.localPos) >= 1.5f)
            {
                ev.IsAllowed = false;
                ev.Player.Position += ev.Player.CameraTransform.forward;
            }
        }
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            foreach (CoroutineHandle coroutine in Vent173.Coroutine)
                Timing.KillCoroutines(coroutine);
        }
        public void OnSpawning(SpawningEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp173)
            {
                ev.Player.Broadcast(7, "You can vent by type `.vent` in the `~` console!\nYou have 5 seconds until you will be vent locked");
            }
        }
    }
}
