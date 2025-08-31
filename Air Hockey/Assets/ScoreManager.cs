using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    public TMP_Text scoreTextP1;
    public TMP_Text scoreTextP2;

    public Transform disco;
    public Transform paleta_p1;
    public Transform paleta_p2;
    public Vector3 posInicialDisco = Vector3.zero;
    public Vector3 posInicialPaletaP1 = new Vector3(0f, -4.37f, 0f);
    public Vector3 posInicialPaletaP2 = new Vector3(0f, 4.4f, 0f);
    public float velocidadeInicial = 5f;

    //Função para marcar ponto.
    public void AddPoint(string alvo)
    {
        if (alvo == "Win1")
        {
            scorePlayer2++;
        }
        else if (alvo == "Win2")
        {
            scorePlayer1++;
        }

        AtualizaUI();

        //Volta o disco para o centro e as paletas.
        disco.position = posInicialDisco;
        paleta_p1.position = posInicialPaletaP1;
        paleta_p2.position = posInicialPaletaP2;

        //Zera a velocidade do disco.
        Rigidbody2D rb = disco.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        MovimentoInicialAleatorio();
    }

    void AtualizaUI()
    {
        if (scoreTextP1 != null)
        {
            scoreTextP1.text = scorePlayer1.ToString();
        }
        if (scoreTextP2 != null)
        {
            scoreTextP2.text = scorePlayer2.ToString();
        }
    }

    //Realiza um movimento aleatório do disco.
    void MovimentoInicialAleatorio()
    {
        script_disco discoScript = disco.GetComponent<script_disco>();
        discoScript.MovimentoInicialAleatorio();
    }
}
