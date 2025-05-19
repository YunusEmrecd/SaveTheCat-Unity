using UnityEngine;


public class SwordTarget : MonoBehaviour
{
    public GameObject swordChild;
    public float swordDuration = 1f;
    public float pushForce = 2f;
    public float pushRadius = 2f;
    public LayerMask enemy;

    private GameObject currentSwordForm;
    private bool isSwordActive = false;  // Kılıç aktif mi?
                                         // Karakter hareket edebilir mi?

    void Start()
    {
        // Başlangıçta kılıçlı hal kapalı
        swordChild.SetActive(false);
    }
    void Update()
    {
        // Boşluk tuşuna basıldığında ve kılıç aktif değilken
        if (Input.GetKeyDown(KeyCode.Space) && !isSwordActive)
        {
            swordChild.SetActive(true);
            isSwordActive = true;
            PushEnemies();
            Invoke(nameof(DeactivateSword), swordDuration);
        }



    }


    void DeactivateSword()
    {

        swordChild.SetActive(false);
        isSwordActive = false;
    }

    void PushEnemies()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, pushRadius, enemy);

        foreach (Collider2D enemyCollider in enemies)
        {
            Vector2 pushDirection = (enemyCollider.transform.position - transform.position).normalized;


            Vector2 enemyNewPosition = (Vector2)enemyCollider.transform.position + pushDirection * pushForce;

            enemyCollider.transform.position = enemyNewPosition;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pushRadius);
    }
}
