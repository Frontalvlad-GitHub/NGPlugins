using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace NGPlugins
{
    [ApiVersion(2, 1)]
    public class NGPlugins : TerrariaPlugin
    {
        public override string Author => "Frontalvlad";

        public override string Description => "Просмотр плагинов. Специально для NGVille (host.frontalvlad.ml)";

        public override string Name => "NGPlugins";

        public override Version Version => new Version(1, 0, 0, 0);

        public NGPlugins(Main game)
          : base(game)
        {
        }

        public override void Initialize() => Commands.ChatCommands.Add(new Command("ngplugins.listplugins", new CommandDelegate(this.ListPluginsCommand), new string[3]
        {
      "ngplugin",
      "ngplugins",
      "plugins"
        }));

        private void ListPluginsCommand(CommandArgs args)
        {
            uint packedValue = Color.White.packedValue;
            string colorTag = string.Format("[c/{0:X}:", (object)((uint)(((int)packedValue & (int)byte.MaxValue) << 16 | (int)packedValue & 65280) | (packedValue & 16711680U) >> 16));
            string msg = "[i:547] [c/e3693f:Plugins]: " + string.Join("[c/ffffff:,] ", ((IEnumerable<PluginContainer>)ServerApi.Plugins).Select<PluginContainer, string>((Func<PluginContainer, string>)(p => colorTag + p.Plugin.Name.Replace("]", "]" + colorTag + "]") + "]")));
            args.Player.SendInfoMessage(msg);
        }
    }
}
