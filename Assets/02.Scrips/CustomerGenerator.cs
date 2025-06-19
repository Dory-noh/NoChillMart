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
        infoText.text = $"��� �༺ : {alienData.planet}\n" +
            $"���� �̸� : {alienData.raceName}\n" +
            $"���� : {alienData.accent}\n" +
            $"���� : {alienData.nature}";
    }
}
