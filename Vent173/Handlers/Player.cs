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
            }
        }
        public void OnInteract(InteractingDoorEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp173 && ev.Player.IsInvisible)
            {
                if (!ev.Door.isOpen)
                {
                    if (Vector3.Distance(Vector3.forward, Vector3.back))
                    {
                        ev.IsAllowed = false;
                    }
                }
            }
        }
    }
}
