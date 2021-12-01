﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupAngle : MonoBehaviour
{
    RectTransform angle; // -45 ~ 45

    // [SerializeField]
    float angleDelta = 30.0f;

    public void StartAngle()
    {
        angle = GetComponent<RectTransform>();
        angle.rotation = new Quaternion(0, 0, 0, 1);
        StartCoroutine(AngleCoroutine());
    }

    public void EndAngle()
    {
        StopAllCoroutines();
    }

    IEnumerator AngleCoroutine()
    {
        float dir = Time.deltaTime * angleDelta;

        while (true)
        {
            if ((angle.eulerAngles.z > 44f && angle.eulerAngles.z < 46f) || (angle.eulerAngles.z > 314f && angle.eulerAngles.z < 316f))
            {
                dir = -dir;
            }

            angle.Rotate(new Vector3(0, 0, dir));
            yield return null;
        }
    }

    public int GetScore() // 현재 각도를 재서, 좌우 20도 이하라면 1을 리턴합니다.
    {
        if ((angle.eulerAngles.z >= -20f && angle.eulerAngles.z <= 1f)
            || (angle.eulerAngles.z >= -1f && angle.eulerAngles.z <= 20f)
            || (angle.eulerAngles.z <= 361f && angle.eulerAngles.z >= 340f)) return 1;

        return 0;
    }
}
