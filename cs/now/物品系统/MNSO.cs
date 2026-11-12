using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
[CreateAssetMenuAttribute(fileName = "物品", menuName = "物品/小物品")]
public class MNSO : ScriptableObject
{
    [Header("base")]
    public string mnName;
    public string mnID;
    public Sprite mnSprite;
    public string mnInfo;
    [Header("maxnum")]
    public int maxStack = 99;
    [Header("trade")]
    public int sellPrice;
    public int buyPrice;
    [Header("enum")]
    public MNlevel mntype;
    public MNtype MNLevel;
    [Header("size")]
    public int MNlong;
    public int MNwide;
}
