using UnityEngine;

public class script_paletaP2 : MonoBehaviour
{
    public Transform disco;        //Referência do disco
    public float velocidade = 3f;  //Velocidade

    //Limites que a paleta pode ir
    public float minX = -3.22f, maxX = 3.21f;
    public float minY = 0.52f, maxY = 4.39f;

    void Update()
    {
        //Pega a posição atual da paleta.
        Vector3 novaPos = transform.position;

        //Segue o disco no eixo x.
        novaPos.x = Mathf.MoveTowards(transform.position.x, disco.position.x, velocidade * Time.deltaTime);

        //Segue o disco no eixo y.
        novaPos.y = Mathf.MoveTowards(transform.position.y, disco.position.y, velocidade * Time.deltaTime);

        //Restringe a área da paleta.
        novaPos.x = Mathf.Clamp(novaPos.x, minX, maxX);
        novaPos.y = Mathf.Clamp(novaPos.y, minY, maxY);

        //Atualiza a posição.
        transform.position = novaPos;
    }
    
}
