using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame1_Turn_GameSet : State<InGame1>
{
    bool isClicked = false;

    public InGame1_Turn_GameSet(InGame1 owner, Turn turn) : base(owner)
    {

    }

    public override void Enter() // ResultPopup을 띄웁니다.
    {
        InGame1Canvas canvas = UIMgr.Instance.GetCurrentCanvas<UIState_Wait>() as InGame1Canvas;
        canvas.SetUIPanel<InGame1UI_ResultPopup>(new ResultUIParam("삼촌", null));
    }

    public override void Execute()
    {
        if (!isClicked && Input.GetMouseButtonDown(0))
        {
            Debug.Log("경기 끝!"); // 사후 처리를 합니다.
        }
    }

    public override void Exit()
    {

    }
}

