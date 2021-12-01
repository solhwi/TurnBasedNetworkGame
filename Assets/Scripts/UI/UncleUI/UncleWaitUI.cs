using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UncleWaitUI : UIComponent
{

    public void Awake()
    {
        SetRoomName();
    }
    public Text titleText;

    public void SetRoomName()
    {
        titleText.text = ResourceMgr.GetCurrentRoomName();
    }
}
