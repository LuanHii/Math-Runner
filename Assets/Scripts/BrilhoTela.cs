using UnityEngine;
using UnityEngine.UI;

public class BrilhoTela : MonoBehaviour
{
    public float duracaoAparecer = 0.5f;
    public float duracaoDesaparecer = 2f;

    private Image imagem;
    private bool aparecendo = false;
    private bool desaparecendo = false;
    private float tempoPassado = 0f;
    private float visibilidadeMaxima = 0f;
    private Color corInicial;

    void Start()
    {
        imagem = GetComponent<Image>();
        corInicial = imagem.color;
        imagem.color = new Color(imagem.color.r, imagem.color.g, imagem.color.b, 0f); 
    }

    void Update()
    {
        if (aparecendo)
        {
            tempoPassado += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, visibilidadeMaxima, tempoPassado / duracaoAparecer); 
            imagem.color = new Color(imagem.color.r, imagem.color.g, imagem.color.b, alpha);

            if (tempoPassado >= duracaoAparecer)
            {
                aparecendo = false;
                desaparecendo = true;
                tempoPassado = 0f;
            }
        }

        if (desaparecendo)
        {
            tempoPassado += Time.deltaTime;
            float alpha = Mathf.Lerp(visibilidadeMaxima, 0f, tempoPassado / duracaoDesaparecer); 
            imagem.color = new Color(imagem.color.r, imagem.color.g, imagem.color.b, alpha);

            if (tempoPassado >= duracaoDesaparecer)
            {
                desaparecendo = false;
               
            }
        }
    }

    public void IniciarBrilho(float maxVisibility, bool corVerde)
    {
        visibilidadeMaxima = Mathf.Clamp01(maxVisibility);
        aparecendo = true;
        imagem.color = corVerde ? new Color(0f, 1f, 0f, corInicial.a) : new Color(1f, 0f, 0f, corInicial.a);
       
    }
}