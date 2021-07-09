using UnityEngine;
using UnityEngine.UI;

public class noteButton : MonoBehaviour
{
    public MusicMiniGame musicController;
    public float points, maxTimer;
    public bool longButton;

    private Slider slider;
    protected float timer, timeSec = 0;
    private bool clicking = false, interact = false;

    private void Start()
    {
        musicController = GameObject.Find("Canvas").GetComponent<MusicMiniGame>();
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(longButton);
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

        if (clicking == false && interact == true)
            this.gameObject.SetActive(false);
    }

    void NoInteration()
    {
        if (timeSec >= maxTimer) //sumir a tecla
        {
            musicController.ButtonPressed(false, points);
            this.gameObject.SetActive(false);
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
        Debug.Log(timeSec - maxTimer);

    }

    public void Click(bool clickState)
    {
        clicking = clickState;
        interact = true;
    }
}