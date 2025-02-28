using UnityEngine;

public class Jogador : MonoBehaviour
{
    private float saude;
    private float sede;
    private float fome;
    private float higiene;
    private Rigidbody2D rb;
    public float velocidade = 25f;

    public float Saude
    {
        get { return saude; }
        set { saude = Mathf.Clamp(value, 0, 100); }
    }

    public float Sede
    {
        get { return sede; }
        set { sede = Mathf.Clamp(value, 0, 100); }
    }

    public float Fome
    {
        get { return fome; }
        set { fome = Mathf.Clamp(value, 0, 100); }
    }

    public float Higiene
    {
        get { return higiene; }
        set { higiene = Mathf.Clamp(value, 0, 100); }
    }

    void Start()
    {
        Saude = 100;
        Sede = 100;
        Fome = 100;
        Higiene = 100;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movimento();
    }

    void Movimento()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector2 movimento = new Vector2(movimentoHorizontal, movimentoVertical) * velocidade * Time.deltaTime;
        rb.MovePosition(rb.position + movimento);
    }
}
