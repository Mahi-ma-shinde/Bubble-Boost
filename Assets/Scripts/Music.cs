using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music instance = null;
    private void Awake()
    {
        if(instance != null )
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    public void ToggleSoundMusic()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
    }
    public void ToggleSoundSFX()
    {
        if (PlayerPrefs.GetInt("SMuted", 0) == 0)
        {
            PlayerPrefs.SetInt("SMuted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SMuted", 0);
        }
    }
}
