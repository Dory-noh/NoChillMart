 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject IDCardUI;
    public GameObject OutOptionBtns;
    bool isShowIDCard = false;
    bool isShowOutOptionBtn = false;
    public Text ConversationText; //대화 텍스트
    string[] conversation = { "안녕하세요.", "민증 확인하겠습니다.", "계산됐습니다.", "나가주세요.", "외계인 신고합니다." };
    bool[] conversationBoolArr = {false, false, false, false};
    public Text priceText; //판매 금액 텍스트

    void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this) Destroy(gameObject);
        IDCardUI.SetActive(false);
        ResetConversation();
        OutOptionBtns.SetActive(false);
    }

    public void ToggleOutOptionBtns()
    {
        isShowOutOptionBtn = !isShowOutOptionBtn;
        OutOptionBtns.gameObject.SetActive(isShowOutOptionBtn);
    }

    public void ResetConversation()
    {
        for (int i = 0; i < conversationBoolArr.Length; i++) conversationBoolArr[i] = false;
        if (GameManager.Instance.IsGameOver)
        {
            ConversationText.text = "게임 오버";
            return;
        }
        ConversationText.text = $"{conversation[0]}\n";
        gameObject.GetComponent<ShowPerson>().GenerateCustormer();
        gameObject.GetComponent<ItemManager>().ShowRandomItems();
    }

    public void ToggleIDCardUI()
    {
        if (GameManager.Instance.IsGameOver)
        {
            isShowIDCard = false;
            return;
        }
        else isShowIDCard = !isShowIDCard;
        IDCardUI.gameObject.SetActive(isShowIDCard);
    }

    public void ShowPassAction()
    {
        if (GameManager.Instance.IsGameOver) return;
        gameObject.GetComponent<ShowPerson>().CheckAlien(false);
        ShowConversation(2);
        StartCoroutine(WaitReset());
        gameObject.GetComponent<ItemManager>().UpdateSaleText(0);
    }

    public void ShowTroubleMakerOutAction()
    {
        if (GameManager.Instance.IsGameOver) return;
        ShowConversation(3);
        StartCoroutine(WaitReset());
    }

    public void ShowAlienOutAction()
    {
        if (GameManager.Instance.IsGameOver) return;
        ShowConversation(4);
        StartCoroutine(WaitReset());
    }

    public void ShowConversation(int idx)
    {
        if(GameManager.Instance.IsGameOver) return;
        if (conversationBoolArr[idx-1] == false)
        {
            conversationBoolArr[idx-1] = true;
            StartCoroutine(WaitShowConversation(idx));
        }
    }

    IEnumerator WaitShowConversation(int idx)
    {
        yield return new WaitForSeconds(0.1f);
        ConversationText.text += $"{conversation[idx]}\n";
    }

    IEnumerator WaitReset()
    {
        yield return new WaitForSeconds(1f);
        ResetConversation();
        gameObject.GetComponent<ShowPerson>().GenerateCustormer();
    }

}
