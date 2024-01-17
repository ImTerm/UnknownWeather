using BepInEx;
using HarmonyLib;

namespace UnknownWeather
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class UnknownWeather : BaseUnityPlugin
    {
        public static Harmony _harmony;

        private void Awake()
        {
            _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            _harmony.PatchAll();
        }
    }
}