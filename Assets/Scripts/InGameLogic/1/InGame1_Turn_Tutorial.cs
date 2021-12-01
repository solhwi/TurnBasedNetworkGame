using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InGame1_Turn_Tutorial : State<InGame1>
{
    TutorialCanvas tutorialCanvas;
    TutorialBtn tutorialBtn;
    PhotonView pv;

    int tutorialCount = 3, tutorialProgress = 0;
    float btnDelay = 0.8f, currDelay = 0.0f;

    bool isClicked = false;

    public InGame1_Turn_Tutorial(InGame1 owner, PhotonView pv, Turn turn) : base(owner)
    {
        this.pv = pv;
    }

    public override void Enter() // 튜토리얼에 진입합니다.
    {
        tutorialCanvas = UIMgr.Instance.GetBaseCanvasPrefab<TutorialCanvas>() as TutorialCanvas;
        tutorialCanvas = MonoBehaviour.Instantiate<TutorialCanvas>(tutorialCanvas); // 튜토리얼 캔버스를 생성합니다.
        tutorialBtn = tutorialCanvas.GetComponentInChildren<TutorialBtn>(); // 튜토리얼 버튼을 가져옵니다.
        tutorialBtn.TutorialProgress(ref tutorialCount, ref tutorialProgress);
    }

    public override void Execute()
    {
        currDelay += Time.deltaTime;

        if (currDelay > btnDelay && Input.GetMouseButtonDown(0)) // 딜레이 후 화면을 터치하면 
        {
            currDelay = 0.0f;
            OnClickTutorialBtn(); // 튜토리얼을 진행시킵니다.
        }
    }

    public override void Exit()
    {
        MonoBehaviour.Destroy(tutorialCanvas.gameObject);
    }

    public void OnClickTutorialBtn()
    {
        if (!tutorialBtn.TutorialProgress(ref tutorialCount, ref tutorialProgress)) // 튜토리얼을 넘깁니다.
        {
            if (!isClicked && NetworkMgr.Instance.IsMasterClient() && NetworkMgr.Instance.IsAllReady())
            {
                isClicked = true;
                NetworkMgr.Instance.UnReady();
                owner.ChangeStateWithEveryOne(Turn.UNCLEANGLE); // 삼촌의 병뚜껑 각도 조준 스테이트로 넘어갑니다.
            }
        }

        if (tutorialCount <= tutorialProgress) // 모두 진행이 되었다면 + 상대방도 해당 화면을 터치한 이후여야 합니다.
        {
            NetworkMgr.Instance.Ready();
        }
    }
}
