using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    float val;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = AudioListener.volume;

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            load();
        }
        else
        {
            load();
        }

    }
    

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }
    public void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
