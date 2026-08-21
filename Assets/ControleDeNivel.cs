using UnityEngine;
using TMPro; // Necessário para mexer no texto do botão (TextMeshPro)

public class ControleDeNivel : MonoBehaviour
{
    [Header("Arraste o Texto do Botão aqui:")]
    public TextMeshProUGUI textoDoBotao; 

    // 0 = Fácil, 1 = Normal, 2 = Difícil
    private int nivelAtual = 1; 

    void Start()
    {
        // Puxa o último nível salvo (Padrão é 1 = Normal)
        nivelAtual = PlayerPrefs.GetInt("DificuldadeIndex", 1);
        AplicarDificuldade();
    }

    // Função que será ativada ao clicar no botão
    public void TrocarDificuldade()
    {
        nivelAtual++; // Aumenta 1 no nível
        
        // Se passar do Difícil (2), volta pro Fácil (0)
        if (nivelAtual > 2)
        {
            nivelAtual = 0; 
        }
        
        AplicarDificuldade();
    }

    private void AplicarDificuldade()
    {
        // Verifica o nível atual e aplica as configurações corretas
        if (nivelAtual == 0) // FÁCIL
        {
            PlayerPrefs.SetFloat("BPM_Salvo", 90f); 
            PlayerPrefs.SetFloat("Velocidade_Salva", 3f); 
            textoDoBotao.text = "NÍVEL: FÁCIL";
        }
        else if (nivelAtual == 1) // NORMAL
        {
            PlayerPrefs.SetFloat("BPM_Salvo", 117f); 
            PlayerPrefs.SetFloat("Velocidade_Salva", 5f); 
            textoDoBotao.text = "NÍVEL: NORMAL";
        }
        else if (nivelAtual == 2) // DIFÍCIL
        {
            PlayerPrefs.SetFloat("BPM_Salvo", 150f); 
            PlayerPrefs.SetFloat("Velocidade_Salva", 8f); 
            textoDoBotao.text = "NÍVEL: DIFÍCIL";
        }

        // Salva o índice atual para não perder quando reiniciar
        PlayerPrefs.SetInt("DificuldadeIndex", nivelAtual);
        PlayerPrefs.Save();
    }
}