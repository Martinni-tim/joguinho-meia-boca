using UnityEngine;
using UnityEngine.SceneManagement;

public class REINICIAR : MonoBehaviour
{
    public void RecarregarCenaAtual()
    {
        // 1. ISSO FAZ O TEMPO VOLTAR A CORRER
        Time.timeScale = 1f; 
        
        // 2. ISSO RECARREGA A CENA
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}