using UnityEngine;

public class GeradorObstaculos : MonoBehaviour
{
    [Header("Configuracoes do Spawn")]
    public GameObject prefabObstaculo; // Arraste o seu obstáculo aqui
    public float bpm = 117f; // Ritmo da musica
    public float multiplicadorBatidas = 2f; // A cada quantas batidas nasce um obstáculo (2 = a cada 2 batidas)

    [Header("Posicoes das Pistas")]
    // As posicoes X das suas 3 pistas (ajuste se precisar)
    public float[] posicoesX = { -3f, 0f, 3f }; 
    public float alturaSpawn = 7f; // Onde eles nascem em cima da tela

    private float temporizador;
    private float intervaloTempo;

    void Start()
    {
        // Calcula o tempo exato com base no BPM (60 / BPM)
        intervaloTempo = (60f / bpm) * multiplicadorBatidas;
    }

    void Update()
    {
        temporizador += Time.deltaTime;

        // Se o tempo acumulado atingir o intervalo da batida, gera um obstáculo
        if (temporizador >= intervaloTempo)
        {
            GerarObstaculo();
            temporizador = 0f; // Reinicia o cronômetro
        }
    }

    void GerarObstaculo()
    {
        if (prefabObstaculo == null) return;

        // Escolhe uma pista aleatória (0 = Esquerda, 1 = Centro, 2 = Direita)
        int pistaAleatoria = Random.Range(0, 3);
        float posX = posicoesX[pistaAleatoria];

        // Define a posicao onde o obstaculo vai nascer
        Vector3 posicaoSpawn = new Vector3(posX, alturaSpawn, 0f);

        // Cria o obstáculo na cena
        Instantiate(prefabObstaculo, posicaoSpawn, Quaternion.identity);
    }
}