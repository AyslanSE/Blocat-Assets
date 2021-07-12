using UnityEngine;
using UnityEngine.UI;

public class noteButton : MonoBehaviour
{
    //Variaveis gerais
    public MusicMiniGame musicController; //controle da musica
    public float points, maxTimer; // pontos da nota e tempo para destruir ela
    public bool longButton; // slider ativo

    private Slider slider; //slider do botao
    protected float timer, timeSec = 0; //contador
    private bool clicking = false, interact = false; //interação com a tecla

    //Inicio do Script
    private void Start()
    {
        musicController = GameObject.Find("Canvas").GetComponent<MusicMiniGame>();
        slider = GetComponentInChildren<Slider>();

        slider.gameObject.SetActive(longButton); //define se tem barra ou não
        timeSec = 0; //reseta o timer
    }

    private void Update()
    {
        if (interact == true) //interagiu com o botao
        {
            if (longButton == true) //tem que segurar
            {
                if (clicking == true) //esta segurando
                {
                    slider.value++;

                    if (slider.value >= slider.maxValue) //atingiu o resultado
                    {
                        musicController.ButtonPressed(true, points);
                        clicking = false;
                    }
                }
                else
                {
                    musicController.ButtonPressed(false, points);
                    clicking = false;
                }
            }
            else if (clicking == true) //nao tem que segurar e clicou
            {
                musicController.ButtonPressed(true, points);
                clicking = false;
            }
            else
                NoInteration();
        }
        else
            NoInteration();

        if (clicking == false && interact == true) //desaparece botão
        {
            this.gameObject.SetActive(false);
            timeSec = 0; //reseta o timer
        }
    }

    void NoInteration()
    {
        if (timeSec >= maxTimer) //sumir a tecla
        {
            musicController.ButtonPressed(false, points);
            this.gameObject.SetActive(false);
            timeSec = 0; //reseta o timer
        }
        else
        {
            //timer para sumir a tecla
            timer++;
            if (timer >= 60)
            {
                timeSec++;
                timer = 0;
            }
        }
    }

    public void Click(bool clickState) //Jogador apertou o botão
    {
        clicking = clickState;
        interact = true;
    }
}