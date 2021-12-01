using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShotSlider : MonoBehaviour
{
    Slider slider;
    BottleCover cover;
    public bool isEnd = false;
    public bool isFail = false;
    public void Shot(float goal)
    {
        slider = GetComponent<Slider>();
        cover = GetComponentInChildren<BottleCover>();

        if (goal == 1) // 파워 맞추기 실패
        {
            goal = 170.0f;
            isFail = true;
        }
        else if (goal == 0) // 각도 맞추기 실패
        {
            goal = 55.0f;
            isFail = true;
        }

        StartCoroutine(ShotCoroutine(goal)); // 병뚜껑 발사 코루틴
    }

    IEnumerator ShotCoroutine(float goal)
    {
        float currTime = 0.0f, travelTime = 2.0f;
        float t = 0.0f;

        while (t < 1)
        {
            currTime += Time.deltaTime;
            t = currTime / travelTime;

            slider.value = Mathf.Lerp(0f, goal, t);
            yield return null;
        }

        slider.value = goal;

        if (!isFail)
        {
            isEnd = true;
        }
        else
        {
            StartCoroutine(FallCoroutine()); // 실패 요인이 있다면 낙하 코루틴을 실행합니다.
        }
    }

    IEnumerator FallCoroutine() // 낙하 코루틴
    {
        float currTime = 0.0f, travelTime = 1.8f;
        float t = 0.0f;

        Vector3 startPos = cover.transform.position;
        Vector3 EndPos = cover.transform.position + new Vector3(6, -12); // 낙하 지점

        while (t < 1)
        {
            currTime += Time.deltaTime;
            t = currTime / travelTime;

            cover.transform.position = Vector3.Lerp(startPos, EndPos, t);
            yield return null;
        }

        isEnd = true;
    }
}
