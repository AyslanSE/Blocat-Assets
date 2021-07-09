using UnityEngine;
using UnityEngine.UI;
public class MusicMiniGame : MonoBehaviour
{
    // =========== Variaveis Serializaveis ===========
    [SerializeField] protected GameObject[] botao;
    [SerializeField] public float[] minTimer;

    [SerializeField] protected Text acerts, startButton;
    [SerializeField] protected Slider barProgress;
    [SerializeField] protected Slider punctuation;

    // ============== Variaveis privadas =============
    private Animator animText;
   // private AudioSource audio;

    protected float timer, timeSec = 0, acertos;
    protected bool inMusic = false, correct = true;
    public int nota;

    // ============== Fim das Variaveis ===============

    private void Start() //Configurar componentes iniciais
    {
        startButton = GameObject.Find("StartText").GetComponent<Text>();
        animText = GetComponent<Animator>();
 //       audio = GetComponent<AudioSource>();
    }
    private void AddButton() //Adiciona Botão
    {
        if (nota < botao.Length)
            botao[nota].SetActive(true);
        else
            inMusic = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            inMusic = true;
            startButton.gameObject.SetActive(false);
        }
        if (inMusic == true)
        {            
            //======== Timer para aparecer Botão =========
            timer++;
            if (timer >= 60)
            {
                timeSec++;
                timer = 0;
            }
            else if (timeSec > minTimer[nota]) //adiciona novo butão
            {
                nota++;
                timeSec = 0;
                AddButton();
            }

            // ================== Controle de Audio ==================

 //           if (!audio.isPlaying) //Começa a tocar a musica
 //               audio.Play();

            if (correct == false) //errou a nota
            {
                // timer para o audio voltar ao normal
                timer++;
                if (timer >= 60)
                {
                    timeSec++;
                    timer = 0;
                }
                //===============================

                if (timeSec > 0.25f)
                {
  //                  audio.volume = 1; //aumenta audio
                    correct = true;
                }
   //             else
   //                 audio.volume = 0.25f; //diminui audio
            }
            //========================================================

            // numero de acertos concecutivos 
            acerts.text = acertos.ToString();
            if (acertos > 25)
                acerts.gameObject.SetActive(true);
            else
                acerts.gameObject.SetActive(false);
            // ========================================================
        }
        else
        {
            timeSec = 0;
            timer = 0;
            nota = 0;
  //          audio.Stop();
        }
    }

    public void ButtonPressed(bool IsCorrect, float Points) //Botão pressionado
    {
        correct = IsCorrect;
        if (IsCorrect == true)
        {
            punctuation.value += Points;
            acertos++;
        }
        else
        {
            punctuation.value -= Points;
            acertos = 0;
        }
    }
}
    /*  private void Start()
      {
          GameObject.Find("UI").GetComponent<GameObject>().SetActive(true);

          //Configurar componentes iniciais
          animText = GetComponent<Animator>();
          audio = GetComponent<AudioSource>();
          //=====================

          //configurar barra de pontuação
          punctuation.maxValue = 100;
          punctuation.minValue = 0;
          punctuation.value = 50;

          //configurar barra de progressão
          barProgress.maxValue = 100;
          barProgress.minValue = 0;
          barProgress.value = 0;

          //configurar acertos
          acerts.gameObject.SetActive(false);
      }

      // ================== Inicio do Sript ================== //


      private void Update()
      {
          // =-=-=-=-=-=-=-=-=-= Script de Musica =-=-=-=-=-=-=-=-=-= //
          if (inMusic == true)
          {
              // ================== Controle de Audio ==================

              if (!audio.isPlaying) //Começa a tocar a musica
                  audio.Play();

              if (correct == false) //errou a nota
              {
                  //======timer para o audio voltar ao normal======
                  timer++;
                  if (timer >= 60)
                  {
                      timeSec++;
                      timer = 0;
                  }
                  //===============================================

                  if (timeSec > 0.25f)
                  {
                      audio.volume = 1; //aumenta audio
                      correct = true;
                  }
                  else
                      audio.volume = 0.25f; //diminui audio
              }

              //========================================================

              //======== Timer para aparecer Botão =========
              timer++;
              if (timer >= 60)
              {
                  timeSec++;
                  timer = 0;
              }
              else if (timeSec > minTimer[nota]) //adiciona novo butão
              {
                  nota++;
                  timeSec = 0;
                  AddButton();
              }
              //============================================


              if (punctuation.value < 10) //errou muito e perdeu
                  inMusic = false;

              // ============ numero de acertos concecutivos ============
              acerts.text = acertos.ToString();
              if (acertos > 25)
                  acerts.gameObject.SetActive(true);
              else
                  acerts.gameObject.SetActive(false);
              // ========================================================
          }
          else
          {
              //deixa as variaveis como estavam antes da musica acontecer//
              GameObject.Find("UI").GetComponent<GameObject>().SetActive(false);
              punctuation.value = 50;
              timeSec = 0;
              timer = 0;
              nota = 0;
              //==========================================================//

              if (Input.GetKey(KeyCode.P))
                  inMusic = true;

              audio.Stop();
          }

          barProgress.value = nota / 50 * 100; //configurar valor da progreção em porcentagem
          if (nota > botao.Length - 1 || punctuation.value < 40) //ultima nota
              inMusic = false; //finaliza a musica
          //else
              //botao[nota].GetComponent<destroyButtonMusic>().timerToDestroy = maxTime[nota]; //desaparece botao com tempo

          // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= //
      }

      private void AddButton() //Adiciona Botão
      {
          if (nota < botao.Length)
          {
              botao[nota].SetActive(true);
          }
      }

      public void ButtonPressed(bool IsCorrect, float Points) //Botão pressionado
      {
          correct = IsCorrect;
          if (IsCorrect == true)
          {
              punctuation.value += Points;
              acertos++;
          }
          else
          {
              punctuation.value -= Points;
              acertos = 0;
          }
      }
}
  */