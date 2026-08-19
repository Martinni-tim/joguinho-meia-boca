using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeJogo : MonoBehaviour
{
    public GameObject painelGameOver;

    private void Start()
    {
        // Garante que o painel comece desligado
        if (painelGameOver != null)
        {
            painelGameOver.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DispararGameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DispararGameOver();
    }

    void DispararGameOver()
    {
        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true);
        }
        Time.timeScale = 0; // Pausa o jogo
    }

    public void TentarNovamente()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VoltarAoMenu()
    {
         Debug.Log("O botão foi clicado!");
        Time.timeScale = 1; 
        // ATENÇÃO: O nome abaixo tem que ser igualzinho ao nome da sua cena de Menu
        SceneManager.LoadScene("MENU"); 
        
    }

}