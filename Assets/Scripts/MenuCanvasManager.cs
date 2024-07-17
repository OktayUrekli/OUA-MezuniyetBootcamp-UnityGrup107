using UnityEngine;

public class MenuCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject grupPanel, optionsPanel,quitPanel,chaptersPanel;
    
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
    }

    public void QuitButton()
    {
        quitPanel.SetActive(true);
    }

    public void YesForQuit()
    {
        Application.Quit();
    }



}
