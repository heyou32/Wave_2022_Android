using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPopup : MonoBehaviour
{
    public Slider volumeSlider;
    private SettingManager _sm;

    private void Awake() 
    {
        _sm = GameObject.Find("SettingManager").GetComponent<SettingManager>();
        volumeSlider.value = _sm.currentSetting.musicVolume;
    }

    public void OnChangeVolume(float volume) 
    {
        _sm.OnChangeMusicVolume(volume);
    }
}
