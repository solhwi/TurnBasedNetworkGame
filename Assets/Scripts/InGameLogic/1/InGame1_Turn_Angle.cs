using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InGame1_Turn_Angle : State<InGame1>
{
    InGame1Canvas canvas;
    PhotonView pv;
    InGame1UI_PlayingPopup popup;
    PopupAngle angle;
    Turn currTurn;
    bool isClicked = false;

    public InGame1_Turn_Angle(InGame1 owner, PhotonView pv, Turn turn, InGame1Canvas canvas) : base(owner)
    {
        this.canvas = canvas;
        currTurn = turn;
        this.pv = pv;
    }

    public override void Enter()
    {
        popup = canvas.GetUIPanel<InGame1UI_PlayingPopup>() as InGame1UI_PlayingPopup;
        popup.SetUI(); // 팝업을 켜고, 팝업은 후방을 모두 가려야 한다.

        if (isPlayer()) // 적절한 설명 배치
        {
            popup.SetDescription("알맞은 순간에 터치!");
        }
        else
        {
            popup.SetDescription("구경 중...");
        }

        // 결과창 닫기
        {
            InGame1UI_ResultPopup result = canvas.GetUIPanel<InGame1UI_ResultPopup>() as InGame1UI_ResultPopup;
            result?.UnsetUI();
        }

        angle = popup.GetPopupAngle();
        angle.StartAngle(); // 앵글 코루틴 시작
    }

    public override void Execute()
    {
        if (!isPlayer()) return;

        if (!isClicked && Input.GetMouseButtonDown(0)) // 제한 시간 내 클릭한 경우
        {
            isClicked = true;
            AngleOver(angle.GetScore());
        }

        if (!isClicked && InGame1.GetTime() < 0.0f) // 제한 시간 내 클릭하지 못한 경우
        {
            isClicked = true;
            AngleOver(0);
        }

        popup.SetTime((int)InGame1.GetTime());
        InGame1.TicTokTimer();
    }

    public override void Exit()
    {
        angle.EndAngle(); // 앵글 코루틴을 멈춥니다.
    }

    bool isPlayer()  // 삼촌 턴의 삼촌이거나, 조카 턴의 조카인 경우 player임
    {
        return (NetworkMgr.Instance.IsMasterClient() && currTurn == Turn.UNCLEANGLE)
        || (!NetworkMgr.Instance.IsMasterClient() && currTurn == Turn.NEPHEWANGLE);
    }

    void AngleOver(int score)
    {
        InGame1.Instance.SetScore(currTurn, score); // 클릭한 순간에 스코어를 기록합니다.
        InGame1.ResetTime(); // 타이머를 초기화합니다.

        if (currTurn == Turn.UNCLEANGLE)
        {
            owner.ChangeStateWithEveryOne(Turn.UNCLEPOWER);
        }
        else if (currTurn == Turn.NEPHEWANGLE)
        {
            owner.ChangeStateWithEveryOne(Turn.NEPHEWPOWER);
        }
    }
}
