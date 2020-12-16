using System.ComponentModel;

using Exiled.API.Interfaces;

using BBroadcast = Exiled.API.Features.Broadcast;

namespace Vent173
{
    public class Config : IConfig
    {
        [Description("Enable the plugin?")]
        public bool IsEnabled { get; set; } = true;
        [Description("How long is the vent cooldown?")]
        public float VentCooldown { get; set; } = 30;
        [Description("What is the cooldown broadcast?")]
        public BBroadcast CBroadcast { get; set; } = new BBroadcast($"You are on cooldown!", 1);
        [Description("Be able to cancel vent early?")]
        public bool VentCancel { get; set; } = true;
    }
}
