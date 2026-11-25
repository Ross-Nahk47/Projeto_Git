using UnityEngine;

public class Moeda : MonoBehaviour
{
    [Header("Movimentação da moeda")]
    [SerializeField] private bool girar = true;
    [SerializeField] private float velocidadeGiro = 180f;

    [Header("Flutuação")]
    [SerializeField] private bool flutuar = true;
    [Tooltip("Altura máxima em unidades")]
    [SerializeField, Range(0f, 1f)] private float amplitude = 0.25f;
    [SerializeField, Range(0f, 5f)] private float frequencia = 2f;

    [Header("Pulso")]
    [SerializeField] private bool pulsar = true;
    [SerializeField, Range(0f, 10f)] private float velocidadePulso = 3f;
    [SerializeField, Range(0f, 1f)] private float intensidadePulso = 0.1f;

    [Header("Brilho")]
    [SerializeField] private bool brilhar = true;
    [SerializeField] private Color corA = Color.yellow;
    [SerializeField] private Color corB = Color.white;
    [SerializeField, Range(0f, 5f)] private float velocidadeBrilho = 1f;

    // Variáveis internas
    private Vector3 posicaoInicial;
    private Vector3 escalaInicial;
    private float defasagem;
    private SpriteRenderer sprite;

    void Awake()
    {
        // Pega o Sprite Renderer do mesmo objeto, uma vez só
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        posicaoInicial = transform.localPosition;
        escalaInicial = transform.localScale;
        defasagem = Random.Range(0f, 2f * Mathf.PI);
        
        Debug.Log($"Moeda pronta em {transform.position}");
    }

    void Update()
    {
        if (girar) Girar();
        if (flutuar) Flutuar();
        if (pulsar) Pulsar();
        if (brilhar && sprite != null) Brilhar();
    }

    void Girar()
    {
        transform.Rotate(0f, velocidadeGiro * Time.deltaTime, 0f);
    }

    void Flutuar()
    {
        float t = Time.time * frequencia + defasagem;
        float y = Mathf.Sin(t) * amplitude;
        transform.localPosition = posicaoInicial + Vector3.up * y;
    }

    void Pulsar()
    {
        float onda = Mathf.Sin(Time.time * velocidadePulso + defasagem);
        float fator = 1f + onda * intensidadePulso;
        transform.localScale = escalaInicial * fator;
    }

    void Brilhar()
    {
        // t vai de 0 a 1 e volta: 0 = corA, 1 = corB
        float t = Mathf.PingPong(Time.time * velocidadeBrilho, 1f);
        sprite.color = Color.Lerp(corA, corB, t);
    }
}