using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text textTime;
    float time;     // 몇 초짜리 타이머인지
    float timer;    // 현재 카운트 다운된 타이머 시간 (time초부터 0초까지 카운트 다운)

    public float GetTimer() { return timer; }   // 현재 카운트 다운된 타이머 시간을 가져옴

    public void ResetTimer() { timer = time; }  // 타이머 초기화

    public void TicTokTimer() // 타이머 시간 카운트 다운. Execute()함수 마지막 줄에서 실행시켜줘야함.
    {
        if (timer < 0) return;
        if (timer < 4) textTime.color = Color.red;
        textTime.text = ((int)timer).ToString(); 
        timer -= Time.deltaTime; 
    }

    public void StartTimer(float t = 30.0f)
    {
        time = t;
        timer = time;
        textTime = this.GetComponent<Text>();
        textTime.text = timer.ToString();
    }

}
