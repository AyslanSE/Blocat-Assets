using UnityEngine;

public class Inventario : MonoBehaviour
{
    public string[] intems;
    public int[] inve;
    public int inveLimit;
    public void addNoInventario(int num)
    {
        for (int i = 0; i < inve.Length; i++)
        {
            if (inve[i] == 0)
            {
                inve[i] = num;
                //intems[i] = item;
                Debug.Log("Inventario++");
            }
            else
                Debug.Log("Inventario lotado");
        }
    }
}