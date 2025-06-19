using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerGenerator : MonoBehaviour
{
    public Image image;
    public Text infoText;
    public CustomerData[] alienDataArr;

    public void GenerateCustormer()
    {
        int idx = Random.Range(0, alienDataArr.Length);
        CustomerData alienData = alienDataArr[idx];
        Debug.Log(idx);
        image.sprite = alienData.characterImg;
        infoText.text = $"출신 행성 : {alienData.planet}\n" +
            $"종족 이름 : {alienData.raceName}\n" +
            $"말투 : {alienData.accent}\n" +
            $"성격 : {alienData.nature}";
    }
}
