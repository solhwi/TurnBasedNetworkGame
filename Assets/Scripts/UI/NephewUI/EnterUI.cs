using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterUI : UIComponent, IPopup
{
    [SerializeField] InputField RoomNameInput;

    public void OnclickEnterBtn()
    {
        if (RoomNameInput.text != "")
        {
            NetworkMgr.Instance.JoinRoom(RoomNameInput.text);
        }
    }

    public void OnClickOk() // NetworkMgr이 JoinRoom에 성공할 시 뜨는 팝업이 사용하는 함수
    {
        FindObjectOfType<Room>().ChangeState(RoomState.NEPHEWREADY);
    }
}
