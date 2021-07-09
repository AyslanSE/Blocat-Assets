using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ativafala : MonoBehaviour
{

    /*public string Fala, Nome;
    public int Personagem;
    public string Decisao1, Decisao2;*/

    public bool temDecisao;

    public Text fala, nome, decisao1, decisao2;

    public GameObject decisao2Obj;

    public TextAsset FalaArquivo,DecisaoArquivo1,DecisaoArquivo2,NomeArquivo;

    public TextAsset[] SemTitulo;

    public int falaatuallid = 1;

    public GameObject falaObj;

    public bool pegouitem;

    public Inventario Inventario;
    // Start is called before the first frame update
    void Start()
    {
        Inventario = GameObject.Find("Inventario").GetComponent<Inventario>();
        falaatuallid = 1;
    }

    // Update is called once per frame
    void Update()
    {

        string[] falaCortada = SemTitulo[0].text.Split(char.Parse(";"));

        if(pegouitem)
        {
            falaCortada = SemTitulo[falaatuallid].text.Split(char.Parse(";"));
        }
        else
        {
            falaCortada = SemTitulo[0].text.Split(char.Parse(";"));
        }

        fala.text = falaCortada[1];
        nome.text = falaCortada[0];
        decisao1.text = falaCortada[2];
        //Debug.Log(falaCortada[2]);

        if(falaCortada.Length > 3)
        {
            decisao2Obj.SetActive(true);
            decisao2.gameObject.SetActive(true);
            decisao2.text = falaCortada[3];
        }
        else
        {
            decisao2Obj.SetActive(false);
            decisao2.gameObject.SetActive(false);
        }
    }

    public void ProximaFala(int op)
    {
        switch (falaatuallid)
        {
            case 0:
               falaObj.SetActive(false);
               break;
               
            case 1:
               if (op == 1)
               {
                   falaatuallid = 3;
               }
               else
               {
                   falaatuallid = 2;
               }
               break;

            case 2:
               if(op == 1)
               {
                   falaatuallid = 3;
               }
               else
               {
                   falaObj.SetActive(false);
               }
               break;

            case 3:
               falaObj.SetActive(false);
               Inventario.addNoInventario(2);
               break;
        }
    }

    public void Ativarfala (bool temItem)
    {
        pegouitem = temItem;
        falaObj.SetActive(true);
    }
}
