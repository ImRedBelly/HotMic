using UnityEngine;
using UnityEngine.UI;

public class MoodBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        slider.value = 0;
        fill.color = gradient.Evaluate(0);
        SetPoint(5);
    }

    public void SetPoint(int point)
    {
        slider.value += point;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
