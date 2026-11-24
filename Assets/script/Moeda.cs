using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField] private float velocidadeGiro = 180f;

    [SerializeField] private bool flutuar = true;
    [SerializeField, Range(0f, 1f)] private float amplitude = 0.25f;
    [SerializeField, Range(0f, 5f)] private float frequencia = 2f;
    private Vector3 posicaoInicial;
    private float defasagem;

    void Start() 
        {
            posicaoInicial = transform.localPosition;
            defasagem = Random.Range(0f, 2f * Mathf.PI);
            Debug.Log($"Moeda pronta em {transform.position}");
        }

        void Update() {
            Girar();
            if (flutuar) 
        {
            Flutuar (); 
        }
        

        void Girar()
        {
            transform.Rotate(0f, velocidadeGiro * Time.deltaTime, 0f);
        }


        void Flutuar()
        {
            float t = Time.time * frequencia + defasagem;
            float Y = Mathf.Sin(t) * amplitude;
            transform.localPosition = posicaoInicial + Vector3.up * Y;
        }


        void Awake()
        {
            
        }


    }
}