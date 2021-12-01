using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame1_Animating : State<InGame1>
{
    ShotSlider[] shotSliders = new ShotSlider[2];
    ShotSlider currSilder;
    Turn currTurn;

    public InGame1_Animating(InGame1 owner, Turn turn) : base(owner)
    {
        currTurn = turn;
    }

    public override void Enter()
    {
        shotSliders = MonoBehaviour.FindObjectsOfType<ShotSlider>();

        if (currTurn == Turn.UNCLEWAIT)
        {
            currSilder = shotSliders[1];
        }
        else if (currTurn == Turn.NEPHEWWAIT)
        {
            currSilder = shotSliders[0];
        }

        float goal = InGame1.GetTotalScore(currTurn); // 현재 턴에 계산해야하는 스코어를 가져옵니다.

        currSilder.Shot(goal); // 스코어에 따른 Shot 애니메이팅
    }

    public override void Execute()
    {
        if (currSilder.isEnd) // 애니메이팅이 끝나자마자 실행되므로, 조금 딜레이를 둘 필요는 있어 보임
        {

            if (currTurn == Turn.UNCLEWAIT)
            {
                owner.ChangeStateWithEveryOne(Turn.NEPHEWANGLE);
            }
            else if (currTurn == Turn.NEPHEWWAIT)
            {
                owner.ChangeStateWithEveryOne(Turn.GAMESET);
            }
        }
    }

    public override void Exit()
    {

    }
    

    
}
