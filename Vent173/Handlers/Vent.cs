using System;
using System.Linq;

using CommandSystem;

using CustomPlayerEffects;

using RemoteAdmin;

using MEC;

using EPlayer = Exiled.API.Features.Player;
using Exiled.API.Features;
using static Vent173.Vent173;

using System.Collections.Generic;

namespace Vent173.Handlers
{
    [CommandHandler(typeof(ClientCommandHandler))]
    class Vent : ICommand
    {
        public static List<EPlayer> CmdCooldown = new List<EPlayer>();

        public string Command => "vent";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Makes SCP-173 go invisible to escape people or outplay them";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            PlayerCommandSender playerCommandSender = sender as PlayerCommandSender;
            EPlayer pplayer = EPlayer.Get(((CommandSender)sender).SenderId);
            if (!CmdCooldown.Contains(pplayer))
            {
                if (sender is PlayerCommandSender ply && EPlayer.Get(ply.SenderId) is EPlayer player1 && player1.Role == RoleType.Scp173)
                {
                    foreach (var effect in player1.ReferenceHub.playerEffectsController.AllEffects.Values
                        .Where(x => x.GetType() == typeof(Scp268) || x.GetType() == typeof(Amnesia)))
                        if (!effect.Enabled)
                            player1.ReferenceHub.playerEffectsController.EnableEffect(effect, 15f);
                        else
                            effect.ServerDisable();
                    player1.IsInvisible = !player1.IsInvisible;
                    player1.Broadcast(7, $"You are {(player1.IsInvisible ? "Invisible" : "Visible")}");
                    response = $"You are {(player1.IsInvisible ? "Invisible" : "Visible")} now";
                    Timing.CallDelayed(15f, () =>
                    {
                        player1.IsInvisible = false;
                    });
                    foreach (EPlayer shitass in EPlayer.List)
                    {
                        if (shitass.Team != Team.SCP && shitass.IsAlive) Scp173.TurnedPlayers.Add(shitass);
                    }
                    Timing.CallDelayed(3f, () =>
                    {
                        Coroutine.Add(Timing.RunCoroutine(VentCooldown(Singleton.Config.VentCooldown, player1)));
                        CmdCooldown.Add(player1);
                    });
                    return true;
                }
                else
                {
                    response = "You are not SCP-173";
                    return false;
                }
            }
            else
            {
                response = "You are on cooldown!";
                pplayer.Broadcast(Singleton.Config.CBroadcast.Duration, Singleton.Config.CBroadcast.Content);
                return false;
            }
        }
        public static IEnumerator<float> VentCooldown(float duration, EPlayer player)
        {
            yield return Timing.WaitForSeconds(Singleton.Config.VentCooldown);
            CmdCooldown.Remove(player);
        }
    }
}
