using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerGenerator : MonoBehaviour
{
    public Image image;
    public Text infoText;
    public CustomerData[] alienDataArr;
    int idx = -1;

    public void GenerateCustormer()
    {
        int temp = -1;
        //�ߺ� ���� ����
        do
        {
            temp = Random.Range(0, alienDataArr.Length);
        }
        while (temp == idx);
        idx = temp;
        Debug.Log(idx);
        CustomerData alienData = alienDataArr[idx];
        
        image.sprite = alienData.characterImg;
        infoText.text = $"��� �༺ : {alienData.planet}\n" +
            $"���� �̸� : {alienData.raceName}\n" +
            $"���� : {alienData.accent}\n" +
            $"���� : {alienData.nature}";
    }
}
