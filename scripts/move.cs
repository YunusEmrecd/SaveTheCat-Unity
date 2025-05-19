using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;
    public SpriteRenderer swordSprite;



    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Hareket
        transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0);
        if (moveX > 0) // Sağa hareket
        {
            spriteRenderer.flipX = false;
            swordSprite.flipX = false; // Normal görünüm
        }
        else if (moveX < 0) // Sola hareket
        {
            spriteRenderer.flipX = true;
            swordSprite.flipX = true;
        }



    }
}
