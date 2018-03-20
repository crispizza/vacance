using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public bool isOn;
    
    public Sprite chirsBalloon;
    public Sprite rachelBalloon;

    private float delayForAutoType = 0.035f;

    public string currentText = "";
    public Text textComponent;

    private bool isClickedOnAnywhere;
    private float baseDelay;
    private bool isWaiting;

    public GameObject rachel;
    public GameObject chris;
    public GameObject mask;
    public GameObject balloon;
    public GameObject arrow;
    public GameObject skipButton;
    public GameObject text;

    public GameObject mark1;
    public GameObject mark2;
    public GameObject mark3;
    public GameObject mark4;
    public GameObject mark5;
    public GameObject mark6;

    public GameObject marketPage;
    public GameObject beds;
    public bool monkeyHotel = false;
    public bool monkeyHotelSet = false;
    public bool fastConst = false;
    public bool hotChocoCafe = false;
    public bool cabinetButtonEnable = false;
    public bool tutorialFinishClosed = false;
    public bool cabinetTouch = false;
    public bool touchCafe = false;
    public bool tutorial_mark6_hotelSelected = false;

    private void Awake()
    {
        isOn = true;
        baseDelay = delayForAutoType = 0.035f;

        StartCoroutine(TutorialSequence());
        StopCoroutine(TutorialSequence());
    }


    private void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            isClickedOnAnywhere = true;
            delayForAutoType = delayForAutoType / 5f;
        }

        if (Input.GetMouseButtonUp(0) == true)
        {
            isClickedOnAnywhere = false;
            delayForAutoType = baseDelay;
        }
    }

    IEnumerator TutorialSequence()
    {
        GameSystem.GetGameSystem().cameraMovable = false;

        AllCutIn();
        
        yield return StartCoroutine(Conversation(rachel, "크리스씨."));

        yield return StartCoroutine(Conversation(chris, "아, 매니저님! 기다리고 있었습니다."));

        yield return StartCoroutine(Conversation(chris, "너 왔구나! 진짜 오랜만이야! 나 기억해?\n너 어렸을 때 나랑 같이 여기서 스키타고 놀았잖아."));

        yield return StartCoroutine(Conversation(chris, "그래! 그 때 여기서 살고 있던 남자애!\n그게 나야. 반갑다 정말!"));
        
        yield return StartCoroutine(Conversation(chris, "계속 여기에 살고 있느냐고? 맞아.\n각 섬마다 관리인이 있는데, 내가 메리스노우의 관리인을\n맡았어."));
        
        yield return StartCoroutine(Conversation(chris, "네가 이제 섬 운영을 맡았다며? 너라면 잘 할수 있을거야.\n앞으로의 모습이 기대되는걸."));

        yield return StartCoroutine(Conversation(rachel, "두 분의 재회가 정말 보기좋지만, 회포는 나중에 푸시고\n관리 방법부터 배워볼까요?"));
        
        yield return StartCoroutine(Conversation(chris, "아참참. 제가 너무 들떴나봐요. 그럼 저는 제설작업 하던 거\n마저 하러 가보겠습니다."));
        
        yield return StartCoroutine(Conversation(chris, "좀 이따가 봐!"));

        FadeOut(chris);



        yield return StartCoroutine(Conversation(rachel, "먼저, 건물 짓는 방법을 알려드릴게요."));
        yield return StartCoroutine(Conversation(rachel, "우측 메뉴에서 상점을 터치하세요."));

        AllFadeOut();
        AllCutOut();

        CutIn(mark1);
        

        //마켓버튼 외에 막기
        yield return new WaitUntil(() => marketPage.activeSelf == true);

        CutOut(mark1);
        yield return new WaitForSeconds(.5f);

        CutIn(rachel);
        CutIn(balloon);
        CutIn(arrow);
        CutIn(mask);  
        yield return StartCoroutine(Conversation(rachel, "섬을 운영하는데 필수 요소인 숙박시설을 지어보도록 할까요?"));
        yield return StartCoroutine(Conversation(rachel, "'숙박'탭을 터치하세요."));        
        CutOut(rachel);
        CutOut(balloon);
        CutOut(arrow);
        CutOut(mask);

        CutIn(mark2);
        yield return new WaitUntil(() => beds.activeSelf == true);
        CutOut(mark2);
        yield return new WaitForSeconds(.5f);

        CutIn(rachel);
        CutIn(balloon);
        CutIn(arrow);
        CutIn(mask);
        yield return StartCoroutine(Conversation(rachel, "메리스노우의 명물인 온천호텔을 지어볼까요?"));
        yield return StartCoroutine(Conversation(rachel, "'원숭이 온천장'을 구매하세요."));
        CutOut(rachel);
        CutOut(balloon);
        CutOut(arrow);
        CutOut(mask);

        CutIn(mark3);
        yield return new WaitUntil(() => monkeyHotel == true);
        CutOut(mark3);
        yield return new WaitForSeconds(.5f);


        CutIn(rachel);
        CutIn(balloon);
        CutIn(arrow);
        CutIn(mask);
        yield return StartCoroutine(Conversation(rachel, "원하는 위치에 건물을 드래그하여 건설을 시작해주세요."));
        CutOut(rachel);
        CutOut(balloon);
        CutOut(arrow);
        CutOut(mask);

        yield return new WaitUntil(() => monkeyHotelSet == true);


        CutIn(rachel);
        CutIn(balloon);
        CutIn(arrow);
        CutIn(mask);
        yield return StartCoroutine(Conversation(rachel, "건물을 구매하면 일정시간의 공사 기간을 거쳐야\n건물사용이 가능합니다."));
        yield return StartCoroutine(Conversation(rachel, "하지만 다이아를 사용하면 즉시완공이 가능해요."));
        yield return StartCoroutine(Conversation(rachel, "한번 해보시겠어요?\n건물을 터치하여 즉시완공을 하세요."));
        CutOut(rachel);
        CutOut(balloon);
        CutOut(arrow);
        CutOut(mask);


        CutIn(mark6);
        mark6.GetComponent<RectTransform>().transform.position = GameSystem.GetGameSystem().hotel.transform.position + new Vector3(0, 10, 0);

        yield return new WaitUntil(() => tutorial_mark6_hotelSelected == true);

        CutOut(mark6);


        yield return new WaitUntil(() => fastConst == true);



        CutIn(rachel);
        CutIn(balloon);
        CutIn(arrow);
        CutIn(mask);
        yield return StartCoroutine(Conversation(rachel, "이번엔 사람들이 휴식할 수 있는 카페를 지어볼까요?"));
        yield return StartCoroutine(Conversation(rachel, "예전에 완공해놓은 카페가 하나 있어요.\n보관함에 들어가서 '핫초코 카페'를 배치하세요."));
        CutOut(rachel);
        CutOut(balloon);
        CutOut(arrow);
        CutOut(mask);

        CutIn(mark4);
        cabinetButtonEnable = true;
        yield return new WaitUntil(() => cabinetTouch == true);
        CutOut(mark4);

        CutIn(mark5);
        yield return new WaitUntil(() => touchCafe == true);
        CutOut(mark5);

        yield return new WaitUntil(() => hotChocoCafe == true);
       
        cabinetButtonEnable = false;
     

        GameSystem.GetGameSystem().tutorialFinish.SetActive(true);

        yield return new WaitUntil(() => tutorialFinishClosed == true);

        Debug.Log("tutorial done");

        isOn = false;
        GameSystem.GetGameSystem().cameraMovable = true;
        yield return null;
    }
    

    IEnumerator Conversation(GameObject character, string fullText)
    {
        //Balloon Name Type
        if(character.name == "Chris")
        {
            balloon.GetComponent<Image>().sprite = chirsBalloon;
            chris.GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 1f);
            rachel.GetComponent<Image>().color = new Vector4(.5f, .5f, .5f, 1f);

        }
        if (character.name == "Rachel")
        {
            balloon.GetComponent<Image>().sprite = rachelBalloon;
            rachel.GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 1f);
            chris.GetComponent<Image>().color = new Vector4(.5f, .5f, .5f, 1f);
        }

        //Auto Typing
        for (int i = 0; i <= fullText.Length ; i ++)
        {
            if (isClickedOnAnywhere == true)
            {
                isWaiting = false;
                currentText = fullText;
                textComponent.text = currentText;
                i = fullText.Length;

                yield return new WaitUntil(() => isClickedOnAnywhere == true);
                yield return new WaitUntil(() => isClickedOnAnywhere == false);
            }

            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delayForAutoType);
        }
        
        yield return new WaitUntil(() => isClickedOnAnywhere == true);
        yield return new WaitUntil(() => isClickedOnAnywhere == false);
    }



    public void AllCutIn()
    {
        rachel.SetActive(true);
        chris.SetActive(true);
        mask.SetActive(true);
        balloon.SetActive(true);
        arrow.SetActive(true);
        skipButton.SetActive(true);
    }

    public void AllFadeOut()
    {
        rachel.GetComponent<Animator>().Play("Fade Out");
        chris.GetComponent<Animator>().Play("Fade Out");
        mask.GetComponent<Animator>().Play("Fade Out");
        balloon.GetComponent<Animator>().Play("Fade Out");
        arrow.GetComponent<Animator>().Play("Fade Out");
        skipButton.GetComponent<Animator>().Play("Fade Out");
        text.GetComponent<Animator>().Play("Fade Out");
    }

    public void FadeOut(GameObject item)
    {
        Animator anim = item.GetComponent<Animator>();
        anim.Play("Fade Out");
    }

    public void FadeIn()
    {

    }

    public void AllCutOut()
    {
        rachel.SetActive(false);
        chris.SetActive(false);
        mask.SetActive(false);
        balloon.SetActive(false);
        arrow.SetActive(false);
        skipButton.SetActive(false);
    }

    public void CutIn(GameObject item)
    {
        item.SetActive(true);
    }

    public void CutOut(GameObject item)
    {
        item.SetActive(false);
    }

    public void Move()
    {
        
    }

    public void MonkeyHotel()
    {
        monkeyHotel = true;
    }
    


}
