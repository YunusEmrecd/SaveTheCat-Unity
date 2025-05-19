using UnityEngine;
using UnityEngine.SceneManagement;
public class yakalanma : MonoBehaviour
{
    public float collisionRadius = 1f;
    public LayerMask enemy;
    public GameObject GameOverPanel;

    public float timeScaleWhenGameOver = 0f;

    private bool gameOverTriggered = false;



    void Update()
    {

        if (!gameOverTriggered)
        {
            CheckCollisionWithEnemies();
        }
    }

    private void CheckCollisionWithEnemies()
    {

        Vector2 catPos = transform.position;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(catPos, collisionRadius, enemy);


        if (enemies.Length > 0)
        {

            gameOverTriggered = true;
            ShowGameOver();
        }
    }





    private void ShowGameOver()
    {
        if (GameOverPanel != null)
            GameOverPanel.SetActive(true);

        Time.timeScale = timeScaleWhenGameOver;
    }

    public void OnTryAgainButton()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuButton()
    {
        // Ana menü sahnesine geçiş
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Ana Menü sahnenizin adı (henüz oluşturmadım bu kısmı)
    }
}

