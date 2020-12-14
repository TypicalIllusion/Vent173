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
                    if (Vector3.Distance(ev.Player.Rotation, ev.Door.localPos) >= 1.5f)
                    {
                        ev.IsAllowed = false;
                        ev.Player.Rotation += Vector3.forward * 1.5f;
                    }
                    else
                    {
                        if (Vector3.Distance(ev.Player.Rotation, ev.Door.localPos) >= -1.5f)
                        {
                            ev.IsAllowed = false;
                            ev.Player.Rotation += Vector3.forward * -1.5f;
                        }
                    }
                }
            }
        }
    }
}
