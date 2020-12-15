using System.ComponentModel;

using Exiled.API.Interfaces;

namespace Vent173
{
    public class Config : IConfig
    {
        [Description("Enable the plugin?")]
        public bool IsEnabled { get; set; } = true;
        [Description("How long is the vent cooldown?")]
        public int VentCooldown { get; set; } = 30;
    }
}
