using UnityEngine;
public class ScreenBoundaryWalls : MonoBehaviour
{
    public Camera mainCamera;
    public float wallThickness = 1f;
    private BoxCollider topWall, bottomWall, leftWall, rightWall;
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        CreateWalls();
    }
    void CreateWalls()
    {
        Vector3 screenTopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Vector3 screenBottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));
        float screenWidth = screenTopRight.x - screenBottomLeft.x;
        float screenHeight = screenTopRight.y - screenBottomLeft.y;
        topWall = CreateWall("TopWall", new Vector3(0, screenTopRight.y + wallThickness / 2, 0), new Vector3(screenWidth, wallThickness, wallThickness));
        bottomWall = CreateWall("BottomWall", new Vector3(0, screenBottomLeft.y - wallThickness / 2, 0), new Vector3(screenWidth, wallThickness, wallThickness));
        leftWall = CreateWall("LeftWall", new Vector3(screenBottomLeft.x - wallThickness / 2, 0, 0), new Vector3(wallThickness, screenHeight, wallThickness));
        rightWall = CreateWall("RightWall", new Vector3(screenTopRight.x + wallThickness / 2, 0, 0), new Vector3(wallThickness, screenHeight, wallThickness));
    }
    BoxCollider CreateWall(string name, Vector3 position, Vector3 size)
    {
        GameObject wall = new GameObject(name);
        wall.transform.position = position;
        BoxCollider collider = wall.AddComponent<BoxCollider>();
        collider.size = size;
        return collider;
    }
}
