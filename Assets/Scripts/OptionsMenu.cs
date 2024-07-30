using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resDropdown,qualityDropdown;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    Resolution[] resolutions;
    private void Start()
    {
        StartingResulations();
        if (PlayerPrefs.HasKey("musicVolume") )
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }
    }
    void StartingResulations()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolationIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolationIndex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolationIndex;
        resDropdown.RefreshShownValue();
    }
    public void SetResulation(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
    public void SetVolume()
    {
        audioMixer.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        audioMixer.SetFloat("Volume", volumeSlider.value);
    }
}
