using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class MNlist :MonoBehaviour
{
    public List<MNclass> MONOlist;
    public int MaxcloneNum = 10;








    public bool canAddTolist() => MONOlist.Count < MaxcloneNum;
    public void removeToList(MNclass mNclass) { MONOlist.Remove(mNclass); }
    public bool canStack(MNclass mNclass) => mNclass.currentNum < mNclass.mnSO.maxStack;
    public void addToList(MNclass mNclass) {MONOlist.Add(mNclass);}


}
