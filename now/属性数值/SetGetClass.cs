using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


[Serializable]
public class SetGetClass 
{
    public float baseValue;
    public float endValue;
    public List<fixValue> fixValues;

    public  float getValue() { return baseValue; }

    public void fixvalue() 
    {
        for (int i = 0; i < fixValues.Count; i++)
        {
            baseValue = baseValue + fixValues[i].changeNum;
        }
    }
    public void addToFixValueList(int changeNum, string why) 
    {
        fixValue fixValue = new fixValue(changeNum,why);
        fixValues.Add(fixValue); 
    }
    public void removeToFixValueList(string why)
    {
        fixValues.Remove(fixValues.Find(fixValue => fixValue.why == why));
    }
}
[Serializable]
public class fixValue 
{
    public int changeNum;
    public string why;
    public fixValue(int changeNum, string why) { }






}