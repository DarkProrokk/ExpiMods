using System.Collections;
using System.IO;
using BepInEx;
using UnityEngine;

namespace TestExpiMod.Audio
{
    public class AudioRunner : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(Run());
        }

        private IEnumerator Run()
        {
            Debug.Log("AudioRunner Start");

            yield return null;

            string path = Path.Combine(Paths.PluginPath, "sounds", "zhopaexplosion.mp3");

            yield return AudioLoader.LoadMp3(path);
        }
    }
}