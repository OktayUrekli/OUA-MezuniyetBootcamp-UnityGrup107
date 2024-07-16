using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanelManager : MonoBehaviour
{
    [SerializeField] Image[] levels;
    [SerializeField] Button leftBtn, RightBtn;


    int levelIndex;


    void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].enabled = false;
        }
        levels[0].enabled = true;
        leftBtn.enabled = false;
    }



    public void LeftButton()
    {
        levelIndex--;
        RightBtn.enabled = true;
        if (levelIndex <= 0)
        {
            levelIndex = 0;
            LoadLevelImage(levelIndex);
            leftBtn.enabled = false;
        }
        else
        {
            LoadLevelImage(levelIndex);
        }
    }

    public void RightButton()
    {
        levelIndex++;
        leftBtn.enabled =true ; 
        if (levelIndex >= levels.Length)
        {
            levelIndex = levels.Length-1;
            LoadLevelImage(levelIndex);
            RightBtn.enabled = false;
        }
        else
        {
            LoadLevelImage(levelIndex);
        }
    }

    

    void LoadLevelImage(int index)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].enabled = false;
        }
        levels[index].enabled = true;
        
    }

    public void LoadLevelButton()
    {
        SceneManager.LoadScene(levelIndex+1);
    }
}
