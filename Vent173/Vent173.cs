using System;

using Exiled.API.Features;
using Exiled.API.Enums;

namespace Vent173
{
    public class Vent173 : Plugin<Config>
    {
        public override string Name { get; } = "Vent173";
        public override string Author { get; } = "TypicalIllusion";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 19);
        public override string Prefix { get; } = "Vent173";

        public override PluginPriority Priority { get; } = PluginPriority.Low;

        public override void OnEnabled()
        {
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
        }
        public override void OnReloaded()
        {
            base.OnReloaded();
        }
    }
}
