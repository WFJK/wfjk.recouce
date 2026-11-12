using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MNinfo : MonoBehaviour
{
    [Header("sp")]
    public MNclass mNclass;

    [Header("ui")]
    public Text mnName;
    public Text mnInfo;
    public Text sellPrice;
    public Text buyPrice;

    public void give(MNclass mnclass) 
    {
        if (mnclass == null) { return; }

        mNclass = mnclass;
        mnName.text = mNclass.mnSO.mnName;
        mnInfo.text = mNclass.mnSO.mnInfo;
        sellPrice.text = mNclass.mnSO.sellPrice.ToString();
        buyPrice.text = mNclass.mnSO.buyPrice.ToString();
    }
    public void show() { gameObject.SetActive(true); }
}
