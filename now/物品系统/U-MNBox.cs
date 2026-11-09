using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MNBox : MonoBehaviour
{
    public MNlist havemnlist;

    public GameObject Gridobj;
    public GameObject mnslot;


    private void Awake()
    {
        havemnlist = FindFirstObjectByType<MNlist>();
        
    }
    private void Start()
    {
        RefreshAllSlots();
    }
    private void addSlot()
    {
        if (havemnlist.MONOlist!=null)
        {
            for (int i = 0; i < havemnlist.MONOlist.Count; i++) 
            {
                if (Gridobj.transform.childCount < havemnlist.MONOlist.Count) 
                {
                    createSlot(havemnlist.MONOlist[i]).SetActive(true);
                }
            }
        }
    }
    public void RefreshAllSlots()
    {
        RemoveItem();
        addSlot();
        changeSlot();
    }
    private GameObject createSlot(MNclass mNclass)
    {
        GameObject obj = Instantiate(mnslot, Gridobj.transform.position, Quaternion.identity);
        obj.transform.SetParent(Gridobj.transform);
        obj.SetActive(false);
        obj.GetComponent<MNclone>().give(mNclass);
        return obj;
    }
    private void RemoveItem()
    {
        for (int i = 0; i < havemnlist.MONOlist.Count; i++)
        {
            if (havemnlist.MONOlist[i].currentNum == 0)
            {
                havemnlist.removeToList(havemnlist.MONOlist[i]);
                i -= 1;
            }
        }
    }
    private void changeSlot()
    {
        for (int i = 0; i < havemnlist.MaxcloneNum; i++)
        {
            if (i<havemnlist.MONOlist.Count) 
            {
                Gridobj.transform.GetChild(i).GetComponent<MNclone>().give(havemnlist.MONOlist[i]);
                Gridobj.transform.GetChild(i).gameObject.SetActive(true);
            }
            if (i >= havemnlist.MONOlist.Count && i< Gridobj.transform.childCount)
            {
                Gridobj.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }



}









