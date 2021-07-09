using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueShower : MonoBehaviour
{
    public Text Name;
    public Image Profile;
    public Text Dialogue;

    public GameObject dialoguecontainer;
    public bool isActive => dialoguecontainer.activeInHierarchy;

    public void MostraDialogo(DialogueBT dialogue)
    {
        dialoguecontainer.SetActive(true);
        Name.text = dialogue.Name;
        Profile.sprite = dialogue.Profile;
        Dialogue.text = dialogue.Dialogue;
    }

    public void EsconderDialogo()
    {
        dialoguecontainer.SetActive(false);
    }
}
