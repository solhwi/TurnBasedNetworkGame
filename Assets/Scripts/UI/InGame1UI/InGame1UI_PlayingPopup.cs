using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame1UI_PlayingPopup : UIComponent
{
    public void SetDescription(string s)
    {
        Text description = transform.Find("Description").Find("Text").GetComponent<Text>();
        description.text = s;
    }

    public void SetTime(int t)
    {
        Text timer = transform.Find("Timer").GetComponent<Text>();
        timer.text = t.ToString();
    }

    public PopupAngle GetPopupAngle()
    {
        return FindObjectOfType<PopupAngle>();
    }

    public PopupPower GetPopupPower()
    {
        return FindObjectOfType<PopupPower>();
    }
}
