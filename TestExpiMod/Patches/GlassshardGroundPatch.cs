using HarmonyLib;
using TestExpiMod.Audio;
using UnityEngine;

namespace TestExpiMod.Patches
{
    [HarmonyPatch(typeof(Sound), "Play")]
    [HarmonyPatch(new[]
    {
        typeof(AudioClip),
        typeof(Vector2),
        typeof(bool),
        typeof(bool),
        typeof(Transform),
        typeof(float),
        typeof(float),
        typeof(bool),
        typeof(bool)
    })]
    class SoundPatch
    {
        [HarmonyPrefix]
        static void Prefix(ref AudioClip clip,
            Vector2 pos,
            bool twoDimensional,
            bool pitchShift,
            Transform follow,
            ref float volume,
            float pitch,
            bool noReverb,
            bool ignoreMixer)
        {
            if (clip != null)
            {
                if (clip.name == "glassshard")
                {
                    Debug.Log($"Glass shard target intercepted: {clip.name}");
                    clip = AudioLoader.CustomClip;
                    volume = 30f;
                }
            }
        }
    }
}