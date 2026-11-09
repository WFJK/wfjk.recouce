using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;



[Serializable]
public class MNclass 
{
    public MNSO mnSO;
    public equipMNSO equipSO;
    public int currentNum;
    public aliveHpBase aliveHpBase; 
    public List<fixEquipValue> fixEquipValues;
    public MNclass(MNSO mnso) 
    { 
        mnSO = mnso;
        isEquipment(mnSO);
    }
    public equipMNSO isEquipment(MNSO mnso) 
    {
        if (mnso is equipMNSO equipMNSO ) 
        {
            equipMNSO equip = mnso as equipMNSO;
            addToFixEquipList(equip.equipValue, equip.valueType);
            return equipMNSO;
        }
        return null;
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
    public void addToFixEquipList(int fixValue, ValueType valueType)
    {
        if (equipSO!=null) 
        {
            fixEquipValue fixEquipValue = new fixEquipValue(fixValue, valueType);
            fixEquipValues.Add(fixEquipValue);
            //addToFixValueList(fixEquipValue);
        }

    }
    public void removeToFixEquipList(ValueType valueType)
    {
        fixEquipValues.Remove(fixEquipValues.Find(fixer => fixer.valueType == valueType));
        //removeToFixValueList(valueType);
    }
    public void addToFixValueList(fixEquipValue fixEquipValue) 
    {
        SetGetClass setGetClass = aliveHpBase.enumToSetGetClass(fixEquipValue.valueType);
        setGetClass.addToFixValueList(fixEquipValue.changeValue, mnSO.mnName); 
    }
    public void removeToFixValueList(ValueType valueType) 
    {
        SetGetClass setGetClass = aliveHpBase.enumToSetGetClass(valueType);
        setGetClass.removeToFixValueList(mnSO.mnName);
    }




}
[Serializable]
public class fixEquipValue
{
    public int changeValue;
    public ValueType valueType;
    public fixEquipValue(int fixValue, ValueType Type) { changeValue = fixValue;valueType=Type; }

}










