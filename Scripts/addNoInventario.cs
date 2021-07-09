using UnityEngine;

public class addNoInventario : MonoBehaviour
{
    public Inventario Inventario;

    public int umItem;
    public string nomeDoItem;

    void Start()
    {
        Inventario = GameObject.Find("Inventario").GetComponent<Inventario>();
    }

    void OnMouseDown()
    {
        Inventario.addNoInventario(umItem);
    }
}