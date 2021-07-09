using UnityEngine;

public class Iventitem : MonoBehaviour
{
    public GameObject dialogo;

    public Inventario Inventario;
    public Ativafala fala;

    void Start()
    {
        Inventario = GameObject.Find("Inventario").GetComponent<Inventario>();
        fala = this.gameObject.GetComponent<Ativafala>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if ((Inventario.inve.Length != 0) && (Inventario.inve[0] == 1 || Inventario.inve[1] == 1))
                fala.Ativarfala(true);
            else
                fala.Ativarfala(false);
        }
    }
}