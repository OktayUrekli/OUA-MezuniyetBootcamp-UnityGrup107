using UnityEngine;
using UnityEngine.SceneManagement;

// Include UnityEditor to use SceneAsset
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShipSceneController : MonoBehaviour
{
    public SceneAsset mainMenuScene; 
    public SceneAsset gameScene; 

    public void LoadMainMenu()
    {
        
        SceneManager.LoadScene(mainMenuScene.name);
    }

    public void RetryGame()
    {
        
        SceneManager.LoadScene(gameScene.name);
    }
}
