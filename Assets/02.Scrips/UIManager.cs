using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject IDCardUI;
    bool isShow = false;
    public Text ConversationText; //대화 텍스트
    string[] conversation = { "안녕하세요.", "민증 확인하겠습니다.", "계산됐습니다.", "나가주세요." };
    bool[] conversationBoolArr = {false, false, false};
    public Text priceText; //판매 금액 텍스트

    void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this) Destroy(gameObject);
        IDCardUI.SetActive(false);
        ResetConversation();
    }

    public void ResetConversation()
    {
        for (int i = 0; i < conversationBoolArr.Length; i++) conversationBoolArr[i] = false;
        ConversationText.text = $"{conversation[0]}\n";
        gameObject.GetComponent<ShowPerson>().GenerateCustormer();
        gameObject.GetComponent<ItemManager>().ShowRandomItems();
    }

    public void ToggleIDCardUI()
    {
        isShow = !isShow;
        IDCardUI.gameObject.SetActive(isShow);
    }

    public void ShowPassAction()
    {
        ShowConversation(2);
        StartCoroutine(WaitReset());
        gameObject.GetComponent<ItemManager>().UpdateSaleText(0);
    }

    public void ShowOutAction()
    {
        ShowConversation(3);
        StartCoroutine(WaitReset());
    }

    public void ShowConversation(int idx)
    {
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
