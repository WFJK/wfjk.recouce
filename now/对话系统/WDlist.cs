using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEngine.UI;
using System;

[CreateAssetMenu(fileName ="对话" ,menuName = "对话/对话列表")]
public class WDlist : ScriptableObject
{
    public List<WD> WDList;

}
