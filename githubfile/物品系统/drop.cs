using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class drop : MonoBehaviour
{
    [Header("so")]
    public MNSO selfMN;
    [Header("sp")]
    public MNclass MNclass;
    public MNlist mNlist;
    public Sprite mnSprite;

    private void Awake()
    {
        mNlist = FindFirstObjectByType<MNlist>();
        mnSprite = GetComponent<Sprite>();
    }

    public void Start()
    {
        mnSprite = selfMN.mnSprite;
        MNclass=new MNclass(selfMN);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            add(MNclass);
            collision.GetComponent<MNBox>().RefreshAllSlots();
            Destroy(gameObject);
        }
    }
    public bool checknew(MNclass MNclass) //如果不是新的加数量
    {
        for (int i = 0; i < mNlist.MONOlist.Count; i++)
        {
            if (mNlist.MONOlist[i].mnSO.mnID == MNclass.mnSO.mnID && mNlist.canStack(mNlist.MONOlist[i]))
            {
                mNlist.MONOlist[i].currentNum++;
                return false;
            }
        }
        return true;
    }
    public void add(MNclass MNclass) //如果是新的往列表里加
    {
        if (checknew(MNclass) && mNlist.canAddTolist())
        {
            mNlist.addToList(MNclass);
            if (MNclass.currentNum == 0) 
            { 
                MNclass.currentNum += 1; 
            }
            
        }
    }

    public void checkSameItem()
    {
        for (int i = 0; i < mNlist.MONOlist.Count; i++)
        {
            MNclass nowMN = mNlist.MONOlist[i];
            for (int j = i + 1; j < mNlist.MONOlist.Count; j++)
            {

                MNclass otherMN = mNlist.MONOlist[j];

                if (nowMN.mnSO.mnID == otherMN.mnSO.mnID)
                {
                    mNlist.removeToList(otherMN);
                    i--;
                    Debug.Log("发现重复物品：" + nowMN.mnSO.name + " → 第" + i + "个 和 第" + j + "个物品");
                }
            }
        }
    }









}
