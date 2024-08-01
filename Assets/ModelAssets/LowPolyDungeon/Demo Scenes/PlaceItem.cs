using UnityEngine;

public class PlaceItem : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager2.instance.PlaceItemInCauldron();
        }
    }
}
