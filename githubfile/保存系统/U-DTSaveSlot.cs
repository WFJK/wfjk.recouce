using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTSaveSlot : MonoBehaviour
{
    [Tooltip("该槽位是否为空")]
    public bool isEmpty;

    [Tooltip("完整的存档数据")]
    public DTSO saveData;

    public int slotNum;

    public string slotName;
    public Text slotNameText;

    public string path;


    public void give(int Num)
    {
        slotNum = Num;
        slotNameText.text = slotName;



    }


}
