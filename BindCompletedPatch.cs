using GlobalSettings;
using HarmonyLib;

namespace SilksongAnimals;

[HarmonyPatch(typeof(HeroController), "BindCompleted")]
public class BindCompletedPatch {

    public static void Postfix(HeroController __instance) {
        if(Gameplay.WarriorCrest.IsEquipped) {
            Plugin.AudioSource.Play();
        }
    }
    
}
