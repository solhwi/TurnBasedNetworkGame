using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InGame2_Nephew : State<InGame2>
{
    PhotonView pv;
    InGame2NephewCanvas canvas;

    Timer timer;

    public InGame2_Nephew(InGame2 owner, PhotonView pv, InGame2State state) : base(owner)
    {
        this.pv = pv;
    }

    public override void Enter()
    {
        canvas = UIMgr.Instance.GetBaseCanvasPrefab<InGame2NephewCanvas>() as InGame2NephewCanvas;
        canvas = MonoBehaviour.Instantiate<InGame2NephewCanvas>(canvas);

        //canvas = UIMgr.Instance.GetCurrentCanvas<UIState_Normal>() as InGame2Canvas;
        //nephewTrack = canvas.GetUIPanel<InGame2UI_NephewTrack>() as InGame2UI_NephewTrack; // 삼촌 화면을 가져옵니다.
        //nephewTrack.SetUI();

        timer = canvas.GetComponentInChildren<Timer>();
        timer.StartTimer(20.0f);
    }

    public override void Execute()
    {
        timer.TicTokTimer();
    }

    public override void Exit()
    {

    }
}
