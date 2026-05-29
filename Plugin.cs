using System.Collections;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;

namespace SilksongAnimals;

[BepInPlugin("rinsoko.animals", "Animals", "0.0.0")]
public class Plugin : BaseUnityPlugin {

    public static AudioSource AudioSource { get; private set; }

    public void Start() {
        Logger.LogInfo("Awwwwwwwww!");
        new Harmony("rinsoko.animals").PatchAll();

        var path = Path.Combine(Paths.PluginPath, "animals.ogg");
        var go = new GameObject("MyPluginAudio");
        DontDestroyOnLoad(go);
        AudioSource = go.AddComponent<AudioSource>();
        AudioSource.spatialBlend = 0f;
        StartCoroutine(Load(path));
    }

    private IEnumerator Load(string path) {
        using var req = UnityWebRequestMultimedia.GetAudioClip($"file://{path}", AudioType.OGGVORBIS);
        yield return req.SendWebRequest();
        if (req.result != UnityWebRequest.Result.Success) {
            Logger.LogError(req.error);
            yield break;
        }
        var clip = DownloadHandlerAudioClip.GetContent(req);
        AudioSource.clip = clip;
    }

}
