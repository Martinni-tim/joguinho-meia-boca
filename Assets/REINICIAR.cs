using UnityEngine;
using UnityEngine.SceneManagement; // Essencial para gerenciar cenas

public class GameManager : MonoBehaviour
{
    public void ReiniciarJogo()
    {
        // Pega o índice da cena atual e a recarrega
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}