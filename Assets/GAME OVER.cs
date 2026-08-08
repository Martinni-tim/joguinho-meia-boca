using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeJogo : MonoBehaviour
{
    public GameObject painelGameOver;

    // Funciona se o colisor estiver como TRIGGER
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Encostou (Trigger em): " + collision.gameObject.name);
        DispararGameOver();
    }

    // Funciona se o colisor NÃO estiver como trigger (Colisão normal)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Encostou (Colisão normal em): " + collision.gameObject.name);
        DispararGameOver();
    }

    void DispararGameOver()
    {
        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true);
        }
        else
        {
            Debug.LogError("O Painel de Game Over não está arrastado na caixinha do Inspector!");
        }

        Time.timeScale = 0; // Congela o jogo
    }

    public void TentarNovamente()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}