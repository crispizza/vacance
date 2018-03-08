using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour {
    
    private float delay = 0.05f;
    private float baseDelay;
    private bool isClicked = false;
    public string[] fullText;
    public string currentText = "";

    public Text textComp;
    public AudioSource audioSource;


    private void Start()
    {
        fullText[0] = "환영합니다!여기까지 오시느라 고생 많으셨어요.";
        fullText[1] = "처음 뵙겠습니다. 저는 이 군도의 총 매니저인\n레이첼이라고 합니다.";
        fullText[2] = "군도에 관련된 모든 질문사항이나 운영방법은\n저에게 물어보시면 해결해드리겠습니다.";
        fullText[3] = "저희 군도는 현재 총 3개의 섬으로 구성되어 있습니다.";
        fullText[4] = "다양한 종류의 꽃과 식물을 구경할 수 있는 봄섬<체리블로썸>.\n꽃놀이나 피크닉, 트래킹을 즐기기 좋은 곳입니다.";
        fullText[5] = "아름다운 해변이 끝없이 펼쳐진 여름섬<크리스탈비치>.\n해수욕과 수상스포츠를 하기엔 여기만한 곳이 없죠.";
        fullText[6] = "일년 내내 깨끗한 눈으로 덮인 겨울섬 <메리스노우>.\n스키를 타기 좋은 설산과 따뜻한 온천수가 자랑인 곳입니다.";
        fullText[7] = "선대 주인인 할머니께서 섬을 제대로 돌보실 수 없었던 탓에\n섬들이 오랜기간 방치되어 있었어요.";
        fullText[8] = "새로운 주인이 오셔서 정말 기쁩니다.저도 최선을 다해\n섬의 부흥을 위해 힘쓰겠습니다.";
        fullText[9] = "지금부터 섬을 관리하는 방법을 알려드릴게요.";
        fullText[10] = "먼저 메리스노우로 가보실까요?\n특별한 분이 기다리고 있거든요.";
        fullText[11] = "화면의 < 메리스노우 > 섬을 터치하세요.";

        baseDelay = delay;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {

        for (int k = 0; k < fullText.Length; k ++)
        { 
     
            for (int i = 0; i <= fullText[k].Length; i++)
            {
                currentText = fullText[k].Substring(0, i);
                textComp.text = currentText;
                audioSource.Play();
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitUntil(() => isClicked == true);

        }

        yield return new WaitUntil(() => isClicked == true);

        GameManagerLobby.GetGameManager().Fade();

    }


     private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {       
            isClicked = true;
            delay = delay / 5f;
        }

        if (Input.GetMouseButtonUp(0) == true)
        {
            isClicked = false;
            delay = baseDelay;
        }
    }

    

}

