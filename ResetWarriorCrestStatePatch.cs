using GlobalSettings;
using HarmonyLib;

namespace SilksongAnimals;

[HarmonyPatch(typeof(HeroController), "ResetWarriorCrestState")]
public class ResetWarriorCrestStatePatch {

    public static void Postfix(HeroController __instance) {
        Plugin.AudioSource.Stop();
    }
    
}
