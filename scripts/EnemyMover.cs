
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform target;
    public float speed;

    private SpriteRenderer spriteRenderer;





    public void Initialize(Transform targetTransform)
    {
        target = targetTransform;

    }

    void Update()
    {
        if (target != null)
        {

            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }

        }
    }


}

