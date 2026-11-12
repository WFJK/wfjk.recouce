using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MNConbine : MonoBehaviour
{
    public List<recipe> recipes;
    public MNlist mNlist;

    public void changeRecipe() 
    {
        foreach (var recipe in recipes) 
        {
            recipe.canRecipe = canRecipe(recipe);
        }
    }
    public bool canRecipe(recipe recipe ) 
    {
        foreach (var mn in recipe.needList)
        {
            for (int i = 0; i < mNlist.MONOlist.Count; i++)
            {
                if (mn.mNSO.mnID == mNlist.MONOlist[i].mnSO.mnID && mNlist.MONOlist[i].currentNum >= mn.needNum)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void makeMN() 
    {
        foreach (var recipe in recipes)
        {
            if (recipe.canRecipe) 
            {
                foreach (var mn in recipe.needList)
                {
                    for (int i = 0; i < mNlist.MONOlist.Count; i++)
                    {
                        mNlist.MONOlist[i].currentNum-=mn.needNum;
                    }
                }
            }
            add(new MNclass(recipe.outPutMNSO),recipe.outPutNum);
        }
    }
    public void FailToMake(recipe recipe) 
    {
        foreach (var mn in recipe.needList)
        {
            for (int i = 0; i < mNlist.MONOlist.Count; i++)
            {
                mNlist.MONOlist[i].currentNum += mn.needNum;
            }
        }
    }

    public bool checknew(MNclass mnclass,int num) //如果不是新的加数量
    {
        for (int i = 0; i < mNlist.MONOlist.Count; i++)
        {
            if (mNlist.MONOlist[i].mnSO.mnID == mnclass.mnSO.mnID && mNlist.canStack(mNlist.MONOlist[i]))
            {
                mNlist.MONOlist[i].currentNum += num;
                return false;
            }
        }
        return true;
    }
    public void add(MNclass mnclass,int num) //如果是新的往列表里加
    {
        if (checknew(mnclass, num) && mNlist.canAddTolist())
        {
            mNlist.addToList(mnclass);
        }
    }
}
[Serializable]
public class recipe 
{
    public int outPutNum;
    public MNSO outPutMNSO;
    public List<needdMaterial> needList;
    public bool canRecipe;
}
public class needdMaterial
{
    public MNSO mNSO;
    public int needNum;
}