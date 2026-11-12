using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;



[Serializable]
public class MNclass 
{
    public MNSO mnSO;
    public int currentNum;
    public aliveHpBase aliveHpBase; 
    public List<fixEquipValue> fixEquipValues=new List<fixEquipValue>();//monobehavior×Ô¶¯new
    public MNclass(MNSO mnso) 
    { 
        mnSO = mnso;
        isEquipment(mnSO);
    }
    public void isEquipment(MNSO mnso) 
    {
        if (mnso is equipMNSO equip ) 
        {
            addToFixEquipList(equip.equipValue, equip.smallValueType);
        }
    }
    public int fixEquipValue()
    {
        int fixNum=0;
        for (int i = 0; i < fixEquipValues.Count; i++)
        {
            fixNum += fixEquipValues[i].changeValue; 
        }
        return fixNum;
    }
    public void addToFixEquipList(int fixValue, AllValueType smallValueType)
    {
        if (mnSO != null) 
        {
            fixEquipValue fixEquipValue = new fixEquipValue(fixValue, smallValueType);
            if (fixEquipValue!=null)
            {
                fixEquipValues.Add(fixEquipValue);
            }
            //addToFixValueList(fixEquipValue);
        }

    }
    public void removeToFixEquipList(AllValueType smallValueType)
    {
        fixEquipValues.Remove(fixEquipValues.Find(fixer => fixer.fixValueType == smallValueType));
        //removeToFixValueList(valueType);
    }
    public void addToFixValueList(fixEquipValue fixEquipValue) 
    {
        SetGetClass setGetClass = aliveHpBase.enumToSetGetClass(fixEquipValue.fixValueType);
        setGetClass.addToFixValueList(fixEquipValue.changeValue, mnSO.mnName); 
    }
    public void removeToFixValueList(AllValueType smallValueType) 
    {
        SetGetClass setGetClass = aliveHpBase.enumToSetGetClass(smallValueType);
        setGetClass.removeToFixValueList(mnSO.mnName);
    }




}
[Serializable]
public class fixEquipValue
{
    public int changeValue;
    public AllValueType fixValueType;
    public fixEquipValue(int fixValue, AllValueType Type) { changeValue = fixValue; fixValueType = Type; }

}










