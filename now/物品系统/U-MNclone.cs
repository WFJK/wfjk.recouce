using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MNclone : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    [Header("sp")]
    public MNclass mnclass;
    public MNBox box; 
    [Header("obj")]
    public GameObject slotUI;

    [Header("ui")]
    public Sprite mnSprite;
    public Text mnNum;

    private void Awake()
    {
        box = FindFirstObjectByType<MNBox>();
    }
    public void removeInList() 
    {
        box.havemnlist.removeToList(mnclass);
        box.RefreshAllSlots();
    }

    public void give(MNclass mNclass)
    {
        if (mNclass == null ){ return; }

        mnclass = mNclass;
        mnNum.text = mnclass.currentNum.ToString();
        mnSprite = mnclass.mnSO.mnSprite;
        
    }
    public void clear() 
    {
        mnSprite=null;
        mnNum=null;
    }
    public void giveInfo() 
    { 
        MNinfo mNinfo = GetComponentInParent<MNinfo>();
        mNinfo.give(mnclass);
        mNinfo.show();
    }

    public void OnMouseEnter()
    {
        giveInfo();
    }
    public void OnPointerEnter(PointerEventData pointerEventData) {  }
    public void OnPointerDown(PointerEventData pointerEventData) { }
    public void OnPointerExit(PointerEventData pointerEventData) {  }
}
