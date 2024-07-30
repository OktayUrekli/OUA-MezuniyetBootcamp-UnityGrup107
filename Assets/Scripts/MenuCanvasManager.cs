using UnityEngine;
public class MenuCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject grupPanel, optionsPanel,quitPanel,chaptersPanel;
    [SerializeField] AudioSource musicSource, SFXSource;
    [SerializeField] AudioClip buttonClickClip;
    void Start()
    {
        grupPanel.SetActive(false);
        optionsPanel.SetActive(false);
        quitPanel.SetActive(false);
        chaptersPanel.SetActive(false);
    }
    public void PlayButton()
    {
        chaptersPanel.SetActive(true);
        ButtonClickSound();
    }
    public void QuitButton()
    {
        quitPanel.SetActive(true);
        ButtonClickSound();
    }
    public void YesForQuit()
    {
        Application.Quit();
    }
    public void ButtonClickSound()
    {
        SFXSource.PlayOneShot(buttonClickClip);
    }
}
