using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InteractionPanel : MonoBehaviour
{
    public static InteractionPanel instance;
    public CanvasGroup canvasGroup;
    public List<string> strings = new List<string>();
    public TextMeshProUGUI text;
    public List<GameObject> buttons = new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }
    int textIndex = 0;
    public void OpenPanel()
    {
        text.rectTransform.anchoredPosition = new Vector2(0f, 0f);
        textIndex = 0;
        stopNext=false;
        canvasGroup.gameObject.SetActive(true);
        text.text = strings[textIndex];
        textIndex++;
    }
    public void ClosePanel()
    {
        canvasGroup.gameObject.SetActive(false);
        text.text = "";
    }
    bool stopNext=false;
    public void NextText()
    {
        text.text = strings[textIndex];
        textIndex++;
        if (textIndex == strings.Count)
        {
            stopNext = true;
            text.rectTransform.anchoredPosition = new Vector2(0f, 106f);
            OpenYesOrNoBtn();
        }
    }
    private void OpenYesOrNoBtn(bool b=true)
    {
      foreach (GameObject go in buttons)
        {
          go.SetActive(b);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (stopNext) return;
            NextText();
        }
    }
    public void YesBtnPressed()
    {
        OpenYesOrNoBtn(false);
        ClosePanel();
        InteractionManager.instance.transform.position = new Vector3(0f,0.41f,0f);
    }
    public void NoBtnPressed()
    {
        OpenYesOrNoBtn(false);
        ClosePanel();
    }
}
