using BepInEx;
using HarmonyLib;
using UnityEngine;


[BepInPlugin("com.test.simplemod", "Simple Mod", "1.0.0")]
public class SimpleMod : BaseUnityPlugin
{
    private void Awake()
    {
        Logger.LogInfo("Mod loaded!");
        UnityEngine.Debug.Log("Mod loaded! GameLog");
        Harmony harmony = new Harmony("com.test.simplemod");
        harmony.PatchAll();
    }

    private void Update()
    {
        Logger.LogInfo("tick");

        if (Input.GetKeyDown(KeyCode.F5))
        {
            Logger.LogInfo("F5 pressed!");
        }
    }
}
[HarmonyPatch(typeof(GroundGlass), "OnCollisionEnter2D")]
class PatchGlass
{
    static void Postfix()
    {
        UnityEngine.Debug.Log("Glass event hooked");
    }
}
[HarmonyPatch(typeof(Sound), "Play")]
class Patch_Sound_Play
{
    static bool Prefix(ref string clip, Vector2 pos)
    {
        if (clip != null && clip == "glassshard")
        {
            UnityEngine.Debug.Log("Glass sound");
        }

        return true;
    }
}