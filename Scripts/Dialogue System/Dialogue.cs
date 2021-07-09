using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public DialogueBT dialogo;

    public DialogueShower mostrardialogo;

    public void Awake()
    {
        mostrardialogo = GameObject.FindObjectOfType<DialogueShower>();
    }

    public void Interact()
    {
        if(mostrardialogo.isActive)
        {
            mostrardialogo.EsconderDialogo();
        }
        else
        {
            mostrardialogo.MostraDialogo(dialogo);
        }
    }
}
