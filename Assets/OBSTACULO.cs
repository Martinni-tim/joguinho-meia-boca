using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [Header("Configurações do Obstáculo")]
    // Velocidade de descida (pode ajustar direto no Unity depois)
    public float velocidade = 5f; 
    
    // Posição no eixo Y onde o objeto será destruído (ajuste para ficar abaixo da câmera)
    public float limiteInferior = -10f; 

    void Update()
    {
        // 1. O Movimento Constante
        // Vector3.down é o mesmo que ir para baixo no eixo Y
        // Time.deltaTime garante que ele ande no mesmo ritmo independente do FPS do seu computador
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);

        // 2. A Destruição
        // Verifica se a posição Y do obstáculo passou do limite inferior da tela
        if (transform.position.y < limiteInferior)
        {
            Destroy(gameObject); // Destrói a si mesmo para liberar memória
        }
    }
}