using BepInEx;
using HarmonyLib;

namespace BetterTotalScrap
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class BetterTotalScrap : BaseUnityPlugin
    {
        private const string modGUID = "impulse.BetterTotalScrap";
        private const string modName = "BetterTotalScrap";
        private const string modVersion = "1.0.0";
        private readonly Harmony harmony = new Harmony(modGUID);
        void Awake()
        {
            harmony.PatchAll(typeof(HUDManagerPatch));
        }
    }
}