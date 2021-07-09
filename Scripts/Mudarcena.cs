using UnityEngine;
using UnityEngine.SceneManagement;

public class Mudarcena : MonoBehaviour
{
    public string cena;

    public Inventario Inventario;

    void Start()
    {
        Inventario = GameObject.Find("Inventario").GetComponent<Inventario>();
    }

    void OntriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Inventario.inve[0] == 2 || Inventario.inve[1] == 2)
            SceneManager.LoadScene(cena);
    }
}