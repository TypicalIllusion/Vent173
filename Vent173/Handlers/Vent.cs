using System;
using System.Linq;

using CommandSystem;

using CustomPlayerEffects;

using RemoteAdmin;

using EAPF = Exiled.API.Features.Player;

namespace Vent173.Handlers
{
    class Vent : ICommand
    {
        public string Command => "vent";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "vent";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            PlayerCommandSender playerCommandSender = sender as PlayerCommandSender;
            if (sender is PlayerCommandSender ply && EAPF.Get(ply.SenderId) is EAPF player1 && player1.Role == RoleType.Scp173)
            {
                foreach (var effect in player1.ReferenceHub.playerEffectsController.AllEffects.Values
                    .Where(x => x.GetType() == typeof(Scp268) || x.GetType() == typeof(Amnesia)))
                    if (!effect.Enabled)
                        player1.ReferenceHub.playerEffectsController.EnableEffect(effect, 15f);
                    else
                        effect.ServerDisable();
                player1.IsInvisible = !player1.IsInvisible;
                player1.ShowHint($"You are {(player1.IsInvisible ? "Invisible" : "Visible")}");
                response = $"You are {(player1.IsInvisible ? "Invisible" : "Visible")} now";
                return true;
            }
            else
            {
                response = "You are not SCP-173";
                return false;
            }
        }
    }
}
