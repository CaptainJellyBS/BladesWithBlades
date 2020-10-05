using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaAudio : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        AudioListener.volume = 0.5f;
    }
}
