using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Mathematics;
using UnityEngine;






[Serializable]
public class defentAbout
{
    public SetGetClass defentValue;

    public SetGetClass voidRate;


    public bool isVoid() 
    {
        if (UnityEngine.Random.Range(1, 101) <= voidRate.getValue() * 100) return true;
        return false; 
    }

    public float defentDecreace(float damage)
    {
        float afterDamage = damage - defentValue.getValue();
        afterDamage = math.clamp(afterDamage, 0, afterDamage);
        return afterDamage;
    }







}
