using UnityEngine;

public class script_disco : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    public float aceleracao = 2f;
    public float velocidadeMax = 10f;
    public float velocidadeInicial = 5f;
    public AudioClip somColisao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        //Inicia o movimento aleatório
        MovimentoInicialAleatorio();
    }

    public void MovimentoInicialAleatorio()
{
    //Gera um ângulo aleatório.
    float angulo = Random.Range(0f, 360f);

    // Converte para vetor de direção
    Vector2 direcao = new Vector2(Mathf.Cos(angulo * Mathf.Deg2Rad), Mathf.Sin(angulo * Mathf.Deg2Rad)).normalized;

    //Aplica a velocidade inicial
    rb.linearVelocity = direcao * velocidadeInicial;
}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Toca som de colisão
        if (somColisao != null)
        {
            audioSource.PlayOneShot(somColisao);
        }

        //Pega a normal do ponto de colisão.
        Vector2 normal = collision.contacts[0].normal;

        //Reflete a velocidade do disco em relação à normal.
        rb.linearVelocity = Vector2.Reflect(rb.linearVelocity, normal);

        //Aplica aceleracao após refletir.
        rb.linearVelocity *= aceleracao + 10;

        //Limita a velocidade máxima
        if (rb.linearVelocity.magnitude > velocidadeMax)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * velocidadeMax;
        }
    }

    //Detectar gols.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Win1") || other.CompareTag("Win2"))
        {
            ScoreManager manager = FindFirstObjectByType<ScoreManager>();
            manager.AddPoint(other.tag);
        }
    }
}
