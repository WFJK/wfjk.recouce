using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
[Serializable]
public class hpAbout
{
    public SetGetClass maxHp;

    public float nowHp;

    public float hpRate() { return nowHp / maxHp.getValue(); }


}
