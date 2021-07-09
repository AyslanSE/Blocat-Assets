using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text textoprincipal;
    public Text speechText;
    public Text speechText2;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textoprincipal.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(textoprincipal.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                textoprincipal.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                textoprincipal.text = "";
                index = 0;
                dialogueObj.SetActive(false);
            }
        }
    }
}
