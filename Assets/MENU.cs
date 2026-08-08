using UnityEngine;
using UnityEngine.SceneManagement; 

public class ControladorMenu : MonoBehaviour
{
    public void IniciarJogo()
    {
        // Tem que ser exatamente o nome da sua cena de corrida
        SceneManager.LoadScene("JOGO"); 
    }
}