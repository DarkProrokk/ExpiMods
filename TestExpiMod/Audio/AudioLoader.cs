using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace TestExpiMod.Audio
{
    public static class AudioLoader
    {
        public static AudioClip CustomClip;

        public static IEnumerator LoadMp3(string path)
        {
            string url = "file://" + path;

            using (var req = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.UNKNOWN))
            {
                Debug.Log("BEFORE REQ");
                yield return (object) req.SendWebRequest();
                Debug.Log("AFTER REQ");

                if (req.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log($"REQ ERR OR: {req.error}");
                    yield break;
                }

                CustomClip = DownloadHandlerAudioClip.GetContent(req);
                Debug.Log($"Loaded AudioClip: {CustomClip.name}");
            }
        }
    }
}