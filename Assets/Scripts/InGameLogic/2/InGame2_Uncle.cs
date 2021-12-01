using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InGame2_Uncle : State<InGame2>
{
    PhotonView pv;
    InGame2UncleCanvas canvas;
    Timer timer;

    public InGame2_Uncle(InGame2 owner, PhotonView pv, InGame2State state) : base(owner)
    {
        this.pv = pv;
    }

    public override void Enter()
    {
        canvas = UIMgr.Instance.GetBaseCanvasPrefab<InGame2UncleCanvas>() as InGame2UncleCanvas;
        canvas = MonoBehaviour.Instantiate<InGame2UncleCanvas>(canvas);

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
