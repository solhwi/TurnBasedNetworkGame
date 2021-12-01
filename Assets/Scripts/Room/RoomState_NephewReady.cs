using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomState_NephewReady : State<Room>
{
    UncleWaitUI waitUI;
    UncleStartUI startUI;
    BaseCanvas uncleCanvas, nephewCanvas;

    public RoomState_NephewReady(Room owner, BaseCanvas uncleCanvas, BaseCanvas nephewCanvas, RoomState state) : base(owner)
    {
        this.uncleCanvas = uncleCanvas;
        this.nephewCanvas = nephewCanvas;
        startUI = uncleCanvas.GetUIPanel<UncleStartUI>() as UncleStartUI;
        waitUI = uncleCanvas.GetUIPanel<UncleWaitUI>() as UncleWaitUI;
    }

    public override void Enter()
    {
        Debug.Log("조카 준비 완료");

        nephewCanvas.TurnOffCanvas();
        uncleCanvas.TurnOnCanvas();

        waitUI.UnsetUI();
        startUI.SetUI();
        startUI.UnsetStartBtn(); // 조카는 게임 시작 버튼을 비활성화합니다.
    }

    public override void Execute()
    {
        if (!NetworkMgr.Instance.IsFullRoom())
        {
            UIMgr.Instance.TurnOnPopup("OtherNetworkPopup", startUI.gameObject);
            owner.ChangeState(RoomState.NEPHEWLOBBY);
        }
    }

    public override void Exit()
    {

    }
}
