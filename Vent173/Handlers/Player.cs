using Exiled.Events.EventArgs;

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
                ev.Player.Position += ev.Player.CameraTransform.forward * 2.5f;
            }
        }
        public void OnSpawning(SpawningEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp173)
            {
                ev.Player.Broadcast(7, "You can vent by typing `.vent` in the `~` console!\nYou will have 5 seconds until you will be vent locked");
            }
        }
    }
}
