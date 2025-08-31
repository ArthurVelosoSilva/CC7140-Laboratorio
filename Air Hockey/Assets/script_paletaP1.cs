using UnityEngine;

public class scipt_paletaP1 : MonoBehaviour
{
    //Limite que a paleta pode ir (eixo X)
    public float minX = -3.23f, maxX = 3.22f;

    //Limite que a paleta pode ir (eixo Y).
    public float minY = -4.402f, maxY = -0.55f;
    void Update()
    {
        //Pega a posição do mouse em coordenadas de mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Mantém a posição Z da paleta
        mousePos.z = 0f;

        //Restringe a área da paleta
        mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);
        mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);

        //Atualiza a posição da paleta
        transform.position = mousePos;
    }
}
