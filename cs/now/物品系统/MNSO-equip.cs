using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
[CreateAssetMenuAttribute(fileName = "物品", menuName = "物品/装备物品")]


[Serializable]
public class equipMNSO : MNSO
{
    [Header("equipment")]
    public equipType equipType;

    public int equipValue;

    public AllValueType smallValueType;


}
