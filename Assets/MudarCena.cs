using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{
    public void IrParaMenu()
    {
        // Despausa o jogo caso esteja pausado
        Time.timeScale = 1f; 
        
        // Carrega a cena do menu
        SceneManager.LoadScene("MENU"); 
        
        Debug.Log("Fui para o menu!"); // Para termos certeza que rodou
    }
}