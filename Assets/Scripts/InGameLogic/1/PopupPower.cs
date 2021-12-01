using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPower : MonoBehaviour
{
    Slider slider;
    float powerDelta = 60.0f;

    public void StartPower()
    {
        slider = GetComponent<Slider>();
        slider.value = 0f;
        StartCoroutine(PowerCoroutine());
    }

    public void EndPower()
    {
        StopAllCoroutines();
    }

    IEnumerator PowerCoroutine()
    {
        float amount = Time.deltaTime * powerDelta;

        while (true)
        {
            if (slider.value > 199.9f || slider.value < 0.01f)
            {
                amount = -amount;
            }

            slider.value += amount;
            yield return null;
        }
    }

    public int GetScore() // slider가 150 ~ 200이라면 0을 리턴하여 책상 밖으로 넘어가도록 합니다.
    {
        if (slider.value > 150f) return 0;

        return (int)slider.value;
    }
}
