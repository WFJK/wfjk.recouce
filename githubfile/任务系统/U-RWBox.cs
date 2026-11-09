using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RWUI : MonoBehaviour
{

    public RWList RWList;

    public GameObject Gridobj;
    public GameObject RWDiv;

    public void updateRWUI() 
    {
        addDiv();
        ChangeDiv();
    }
    private void addDiv()
    {
        if (RWList.rwList != null)
        {
            for (int i = 0; i < RWList.rwList.Count; i++)
            {
                createDiv(RWList.rwList[i]);
            }
        }
    }
    private GameObject createDiv(RWclass rw)
    {
        GameObject obj = Instantiate(RWDiv, Gridobj.transform.position, Quaternion.identity);
        obj.transform.SetParent(Gridobj.transform);
        obj.SetActive(false);
        return obj;
    }

    private void ChangeDiv()
    {
        if (RWList.rwList != null )
        {
            for (int i = 0; i < RWList.rwList.Count; i++ )
            {
                if (Gridobj.transform.childCount <= RWList.rwList.Count) 
                {
                    Gridobj.transform.GetChild(i).GetComponent<RWclone>().give(RWList.rwList[i]);
                    Gridobj.transform.GetChild(i).gameObject.SetActive(true);
                }
                if (Gridobj.transform.childCount > RWList.rwList.Count)
                {
                    Gridobj.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }










}
