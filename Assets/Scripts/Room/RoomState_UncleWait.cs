using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomState_UncleWait : State<Room>
{
    UncleWaitUI waitUI;
    UncleStartUI startUI;

    public RoomState_UncleWait(Room owner, RoomState state) : base(owner)
    {
        UncleRoomCanvas canvas = UIMgr.Instance.GetCurrentCanvas<UIState_Wait>() as UncleRoomCanvas;
        startUI = canvas.GetUIPanel<UncleStartUI>() as UncleStartUI;
        waitUI = canvas.GetUIPanel<UncleWaitUI>() as UncleWaitUI;
    }

    public override void Enter()
    {
        Debug.Log("삼촌 대기 중... 방 이름: " + ResourceMgr.GetCurrentRoomName());

        waitUI.SetUI();
        startUI.UnsetUI();
    }

    public override void Execute()
    {
        if (NetworkMgr.Instance.IsFullRoom())
        {
            owner.ChangeState(RoomState.UNCLEREADY);
        }
    }

    public override void Exit()
    {

    }
}
