using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class sound_manager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public AudioMixer audioMixer;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeVolume()
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volumeSlider.value) * 40);
        

    }

}

   
