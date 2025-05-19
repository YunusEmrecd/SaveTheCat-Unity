using UnityEngine;

public class stayatcam : MonoBehaviour
{
    public Camera mainCamera; // Karakterin bağlı olduğu kamera
    private Vector2 screenBounds; // Kameranın sınırları
    private float objectWidth;
    private float objectHeight;
    void Start()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x; // Objeyi hesaba kat
        objectHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
    }


    void Update()
    {

    }
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;


    }
}
