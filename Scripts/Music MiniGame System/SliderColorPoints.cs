using UnityEngine;
using UnityEngine.UI;

public class SliderColorPoints : MonoBehaviour
{
    public Color bad, noGood, good, veryGood, perfect; //red, yellow, orange, green, purple

    private Slider bar;
    public Image Fill;

    private void Start()
    {
        bar = GameObject.Find("BarPontuation").GetComponent<Slider>();
        Fill = this.GetComponent<Image>();
    }

    void Update()
    {
        if (bar.value / bar.maxValue * 100 > 80 * bar.maxValue / bar.maxValue) // > 80%
            Fill.color = perfect;
        else if (bar.value / bar.maxValue * 100 > 60 * bar.maxValue / bar.maxValue) // > 60%
            Fill.color = veryGood;
        else if (bar.value / bar.maxValue * 100 > 40 * bar.maxValue / bar.maxValue) // > 40%
            Fill.color = good;
        else if (bar.value / bar.maxValue * 100 > 20 * bar.maxValue / bar.maxValue) // > 20%
            Fill.color = noGood;
        else if (bar.value / bar.maxValue * 100 < 20 * bar.maxValue / bar.maxValue) // < 20%
            Fill.color = bad;
    }
}