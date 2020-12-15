using System;

using Exiled.API.Features;
using Exiled.API.Enums;
using PPlayer = Exiled.Events.Handlers.Player;
using System.Collections.Generic;
using MEC;

namespace Vent173
{
    public class Vent173 : Plugin<Config>
    {
        public override string Name { get; } = "Vent173";
        public override string Author { get; } = "TypicalIllusion";
        public override Version Version { get; } = new Version(1, 0, 1);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 19);
        public override string Prefix { get; } = "Vent173";

        private Handlers.Player player = new Handlers.Player();

        public override PluginPriority Priority { get; } = PluginPriority.Low;

        public static Vent173 Singleton;

        public static List<CoroutineHandle> Coroutine = new List<CoroutineHandle>();

        public void RegisterEvents()
        {
            PPlayer.Hurting += player.OnHurting;
            PPlayer.InteractingDoor += player.OnInteract;
            Singleton = this;
        }
        public void UnregisterEvents()
        {
            PPlayer.Hurting -= player.OnHurting;
            PPlayer.InteractingDoor -= player.OnInteract;
            Singleton = null;
            player = null;
        }
        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }
    }
}
