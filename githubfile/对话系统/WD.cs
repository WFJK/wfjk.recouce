using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
[CreateAssetMenu(fileName = "对话", menuName = "对话/小对话")]
public class WD :ScriptableObject
{
    public int enterIndex;
    public string speakerName;
    public string content;
    public int quitIndex;


    public bool haveOption;
    public List<string> OptionName;
}
