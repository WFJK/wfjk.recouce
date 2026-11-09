using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWclass : MonoBehaviour
{
    public RWSO rWSO;

    public List<int> completeNumList;

    public rwState rwState;


    public void givecompleteNumList ()
    {
        for (int i = 0; i < rWSO.needMNAndNum.Count; i++) 
        {
            completeNumList.Add(0);
        }
    
    }
    public bool isFinish()
    {
        if (rWSO.needEnemyAndNums!=null) 
        {
            for (int i = 0; i < completeNumList.Count; i++) 
            {
                if (completeNumList[i]!=0) 
                { 
                    return false;
                }
            }
        }
        return true;
    }
    public void giveUpRW() 
    {
        for (int i = 0; i < completeNumList.Count; i++)
        {
            completeNumList[i] = 0;
        }
    }


}
