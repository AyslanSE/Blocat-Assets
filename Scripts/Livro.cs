using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Livro : MonoBehaviour
{
    public int itemum;
    public Image image;
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        //itemum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addNoInventario(int num)
    {
        itemum = num;

        if (itemum == 1)
        {
            image.sprite = sprite;
        }
    }
}
