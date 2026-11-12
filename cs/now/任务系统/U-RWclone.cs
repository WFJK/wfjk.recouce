using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RWclone : MonoBehaviour
{
    public RWclass rwClass;
    public RWList rwList;

    public Text rwName;
    public Text rwinfo;


    public void give(RWclass rw) 
    {
        rwClass = rw;
        rwName.text = rw.rWSO.rwName;
        rwinfo.text = rw.rWSO.rwinfo;
    }










}
