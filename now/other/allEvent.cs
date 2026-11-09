using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allEvent
{

    public RWList rWList;


    public const string eventName = "enemyDie";
    public event Action<string> OnEnemyDie;


    public void callOnEnemyDie(string enemyID) 
    {
        OnEnemyDie?.Invoke(enemyID);
    }






















}
