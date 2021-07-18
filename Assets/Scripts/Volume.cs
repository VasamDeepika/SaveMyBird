using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    public void Start()
    {
        if(!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Volume",slider.value);
    }
    private void Load()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }
}
