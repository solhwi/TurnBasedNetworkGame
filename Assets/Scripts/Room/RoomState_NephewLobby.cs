using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// State 넘어가는 조건이 EnterUI에 있음

public class RoomState_NephewLobby : State<Room>
{
    EnterUI nephewEnterUI;

    public RoomState_NephewLobby(Room owner, RoomState state) : base(owner)
    {
        NephewRoomCanvas canvas = UIMgr.Instance.GetCurrentCanvas<UIState_Wait>() as NephewRoomCanvas;
        nephewEnterUI = canvas.GetUIPanel<EnterUI>() as EnterUI;
    }

    public override void Enter()
    {
        Debug.Log("조카 방 찾는 중");

        nephewEnterUI.SetUI();
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}
