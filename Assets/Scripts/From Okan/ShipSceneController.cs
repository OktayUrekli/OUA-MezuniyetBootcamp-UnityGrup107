using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipSceneController : MonoBehaviour
{

    public void LoadMainMenu()
    {
        
        SceneManager.LoadScene(0);
    }

    public void RetryGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
