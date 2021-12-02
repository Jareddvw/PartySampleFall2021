using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioLord : MonoBehaviour
{
    public AudioClip music;

    public static AudioLord Instance
    {
        get
        {
            if (!_instance)
            {
                singletonRoot = new GameObject("audioLord");
                _source = singletonRoot.AddComponent<AudioSource>();
                _instance = singletonRoot.AddComponent<AudioLord>();
                DontDestroyOnLoad(singletonRoot);
                inited = true;
            }

            return _instance;
        }
    }

    public static GameObject singletonRoot;
    private static bool inited = false;
    private static AudioLord _instance;
    private static AudioSource _source;
    
    private void Awake() {
        if (inited) DestroyImmediate(gameObject);
        if (!_instance) _instance = this;
        singletonRoot = gameObject;
        _source.clip = music;
        _source.Play();
        _source.loop = true;
        inited = true;
        DontDestroyOnLoad(gameObject);
    }
}