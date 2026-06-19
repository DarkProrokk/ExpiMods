using UnityEngine;

namespace TestExpiMod.Audio
{
    public class AudioBootstrap
    {
        public static AudioBootstrap Instance = new AudioBootstrap();

        private bool _initialized;

        public void Init()
        {
            if (_initialized)
                return;

            _initialized = true;

            Debug.Log("AudioBootstrap Init");

            var go = new GameObject("AudioRunner");
            GameObject.DontDestroyOnLoad(go);

            go.AddComponent<AudioRunner>();
        }
    }
}