using UnityEngine;
// Precisamos dessa linha para avisar o Unity que vamos usar o Novo Sistema
using UnityEngine.InputSystem; 

public class MOVIMENTO : MonoBehaviour
{
    [Header("Configurações de Pista")]
    public float distanciaPista = 15f; 
    public float velocidadeTroca = 150f; 

    // 0 = Pista Esquerda, 1 = Pista do Centro, 2 = Pista Direita
    private int pistaAtual = 1; 
    
    private Vector3 posicaoAlvo;

    void Start()
    {
        posicaoAlvo = transform.position;
    }

    void Update()
    {
        // Prevenção de erro: verifica se há algum teclado conectado
        if (Keyboard.current == null) return;

        // 1. Detectar os botões usando o Novo Sistema de Input (wasPressedThisFrame equivale ao GetKeyDown)
        bool esquerdaPressionada = Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame;
        bool direitaPressionada = Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame;

        if (esquerdaPressionada)
        {
            MoverParaEsquerda();
        }
        else if (direitaPressionada)
        {
            MoverParaDireita();
        }

        // 2. Calcular qual deve ser a posição no eixo X
        float novoX = (pistaAtual - 1) * distanciaPista;
        posicaoAlvo = new Vector3(novoX, transform.position.y, transform.position.z);

        // 3. Mover suavemente do ponto atual até o ponto alvo
        transform.position = Vector3.MoveTowards(transform.position, posicaoAlvo, velocidadeTroca * Time.deltaTime);
    }

    void MoverParaEsquerda()
    {
        if (pistaAtual > 0)
        {
            pistaAtual--;
        }
    }

    void MoverParaDireita()
    {
        if (pistaAtual < 2)
        {
            pistaAtual++;
        }
    }
    // Essa função é chamada automaticamente pelo Unity quando o BoxCollider2D 
    // do jogador encosta em um BoxCollider2D marcado como "Is Trigger"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Aqui é onde você coloca o que acontece quando perde!
        Debug.Log("GAME OVER! Bateu no obstáculo!");
        
        // Se quiser que o jogador suma da tela ao bater, tire as duas barras da linha abaixo:
         Destroy(gameObject);
    }
}