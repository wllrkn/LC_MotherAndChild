using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetcodeStuff;
using HarmonyLib;

namespace LC_MotherAndChild.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        // using update as it updates every frame, which will apply our patch
        [HarmonyPatch("Update")] // as this private, we have to do it this way. If its public, use nameof(PlayerControllerB.Update)
        [HarmonyPostfix] // This tells us where to put the code, is it pre or post
        static void infiniteSprintPatch(ref float ___sprintMeter) // this tells us its a reference to something else, accessing the class
        {
            ___sprintMeter = 1f; // f defines it as a float, which means here we're just locking it at sprint speed 1
        }
    }
}
 