using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public enum InGame2State
{
    INTRO,     // 인트로
    UNCLE,     // 삼촌 화면
    NEPHEW,    // 조카 화면
    END        // 게임 종료
}

public class InGame2 : MonoBehaviourPunCallbacks
{
    StateMachine<InGame2> stateMachine;
    EventListener el_OnUICompleted = new EventListener();
    PhotonView pv;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        stateMachine = new StateMachine<InGame2>(new InGame2_Intro(this, pv, InGame2State.INTRO));
        
    }

    void Update()
    {
        stateMachine.Run(); // 스테이트 머신 수행
    }

    public void ChangeState(InGame2State nextState)
    {
        switch (nextState)
        {
            // 인트로
            case InGame2State.INTRO:
                stateMachine.ChangeState(new InGame2_Intro(this, pv, InGame2State.INTRO), StateMachine<InGame2>.StateTransitionMethod.JustPush);
                break;

            // 삼촌 게임 시작
            case InGame2State.UNCLE:
                stateMachine.ChangeState(new InGame2_Uncle(this, pv, InGame2State.UNCLE), StateMachine<InGame2>.StateTransitionMethod.PopNPush);
                break;

            // 조카 게임 시작
            case InGame2State.NEPHEW:
                stateMachine.ChangeState(new InGame2_Nephew(this, pv, InGame2State.NEPHEW), StateMachine<InGame2>.StateTransitionMethod.PopNPush);
                break;

            // 게임 끝
            case InGame2State.END:
                stateMachine.ChangeState(new InGame2_End(this, pv, InGame2State.END), StateMachine<InGame2>.StateTransitionMethod.PopNPush);
                break;
        }
    }
}
