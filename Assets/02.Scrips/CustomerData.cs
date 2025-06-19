using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alien Data", menuName = "Alien/Alien Data")]
public class CustomerData : ScriptableObject
{
    public string planet; //��� �༺
    public string raceName; //������
    public string accent; //������ ����
    public string nature; //����
    public Sprite characterImg; //ĳ���� �̹���
}
