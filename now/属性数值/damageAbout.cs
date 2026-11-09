using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;



[Serializable]
public class damageAbout
{

    public SetGetClass damageValue;

    public SetGetClass criticRate;
    public SetGetClass criticDamageRate;


    public bool isCritic() 
    {
        if(UnityEngine.Random.Range(1, 101) <= criticRate.getValue() * 100) return true;
        return false;
    }
    public float finalDamage() 
    { 
        if (isCritic()) return criticDamageRate.getValue() * damageValue.getValue(); 
        return damageValue.getValue(); 
    }

    
















}
