using UnityEngine;
using UnityEngine.SceneManagement;

// Include UnityEditor to use SceneAsset
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShipSceneController : MonoBehaviour
{
    public SceneAsset mainMenuScene; // Drag and drop the main menu scene asset here in the editor
    public SceneAsset gameScene; // Drag and drop the game scene asset here in the editor

    public void LoadMainMenu()
    {
        // Load scene by name using SceneAsset
        SceneManager.LoadScene(mainMenuScene.name);
    }

    public void RetryGame()
    {
        // Load scene by name using SceneAsset
        SceneManager.LoadScene(gameScene.name);
    }
}
