using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LC_MotherAndChild.Patches;

namespace LC_MotherAndChild
{
    // this bit tells it that its a bepinex plugin
    [BepInPlugin(modGUID, modName, modVersion)]
    public class MrMiinxxTutorialModBase : BaseUnityPlugin
    {
        // define the mods (TD Why Poseiden?)
        private const string modGUID = "Poseidon.LCTutorialMod";
        private const string modName = "LC Tutorial Mod";
        private const string modVersion = "1.0.0.0";

        // define Harmony mod
        private readonly Harmony harmony = new Harmony(modGUID);

        private static MrMiinxxTutorialModBase Instance;

        internal ManualLogSource mls;

        // entry point of the mod
        void Awake()
        {
            if (Instance == null)
            {
                // load the instance
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("This is Wills first mod");

            harmony.PatchAll(typeof(MrMiinxxTutorialModBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
