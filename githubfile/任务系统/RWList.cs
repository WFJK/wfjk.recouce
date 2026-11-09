using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.U2D.Aseprite;
using UnityEditor.VersionControl;
using UnityEngine;

public class RWList : ScriptableObject
{
    public List<RWclass> rwList;
    public allEvent allEvent;
    public void bindToEnemyDie(string enemyID)
    {
        allEvent.OnEnemyDie += addKillRWEvent;
    }
    // 接取任务
    public void AcceptTask(string taskID)
    {
        for (int i=0; i< rwList.Count; i++) 
        {
            if (rwList[i].rWSO.rwID == taskID) 
            {
                rwList[i].rwState = rwState.进行中;
                addToList(rwList[i]);
                rwList[i].givecompleteNumList();
            }
        }
    }
    public void GiveUpTask(string taskID)
    {
        for (int i = 0; i < rwList.Count; i++)
        {
            if (rwList[i].rWSO.rwID == taskID)
            {
                rwList[i].giveUpRW();
            }
        }

    }
    public void FinishTask(string taskID)
    {
        for (int i = 0; i < rwList.Count; i++)
        {
            if (rwList[i].rWSO.rwID == taskID)
            {
                rwList[i].rwState = rwState.完成;
                removeToList(rwList[i]);
            }
        }
    }
    public void addToList(RWclass rWclass) { rwList.Add(rWclass); }
    public void removeToList(RWclass rWclass) { rwList.Remove(rWclass); }


    public void addKillRWEvent(string enemyID)
    {
        for (int i = 0; i < rwList.Count; i++)
        {
            for (int j = 0; j < rwList[i].rWSO.needEnemyAndNums.Count; j++)
            {
                if (rwList[i].rWSO.needEnemyAndNums[i].enemy.ID == enemyID) 
                {
                    rwList[i].completeNumList[i] += 1;
                }
            }
        }
    }
    public void addFindRWEvent(string mnID)
    {

    }
    public void addGoToRWEvent(string action)
    {

    }

}
