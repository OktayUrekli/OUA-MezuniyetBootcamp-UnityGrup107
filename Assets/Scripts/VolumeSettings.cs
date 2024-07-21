using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{

    [SerializeField] AudioMixer myAudioMixer;
    [SerializeField] Slider musicSlider;
    // [SerializeField] Image nonVolumeImage, volumeImage;

    private void Start()
    {

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().volume = volume;
         // UpdateVolumeImage();
        myAudioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    void LoadMusicVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume();
    }


    /*
    void UpdateVolumeImage()
    {
        if (musicSlider.value == musicSlider.minValue)
        {
            nonVolumeImage.gameObject.SetActive(true);
            volumeImage.gameObject.SetActive(false);
        }
        else
        {
            volumeImage.gameObject.SetActive(true);
            nonVolumeImage.gameObject.SetActive(false);
        }
    }
    */
}