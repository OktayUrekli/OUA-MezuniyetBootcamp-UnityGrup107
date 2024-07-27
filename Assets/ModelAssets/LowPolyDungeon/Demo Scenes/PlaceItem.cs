using UnityEngine;

public class PlaceItem : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.PlaceItemInCauldron();
        }
    }
}
