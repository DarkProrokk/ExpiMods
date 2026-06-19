using System.Collections;
using System.IO;
using System.Threading;
using BepInEx;
using HarmonyLib;
using TestExpiMod.Audio;
using UnityEngine;
using UnityEngine.Networking;


[BepInPlugin("com.test.simplemod", "Simple Mod", "1.0.0")]
public class SimpleMod : BaseUnityPlugin
{
    private void Awake()
    {
        Debug.Log($"GO: {gameObject.name}");
        Debug.Log($"Scene: {gameObject.scene.name}");
        Debug.Log($"Unity version: {Application.unityVersion}");
        Debug.Log("AWAKE ENTERED");
        Harmony harmony = new Harmony("com.test.simplemod");
        harmony.PatchAll();
    }

    

    [HarmonyPatch(typeof(PreRunScript), "Start")]
    class PreRunPatch
    {
        [HarmonyPostfix]
        static void Postfix()
        {
            
            Debug.Log($"PreRunPatch Postfix");
            AudioBootstrap.Instance.Init();
        }

    }
}




