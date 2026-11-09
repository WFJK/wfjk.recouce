using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class WDUI : MonoBehaviour
{
    public WDlist wdList;
    [Header("csv")]
    public TextAsset textAsset;

    public Text word;
    public Text speaker;
    public Image leftImage;
    public Image rightImage;

    public GameObject gridObj;


    public int WDIndex = 0;
    private void Start()
    {

    }
    private void Update()
    {

    }

    public void goOn()
    {
        inDialog();
    }
    public void skip(WDlist nextwdList) 
    {
        WDIndex = 0;
        wdList = nextwdList;
    }
    public void changeImagePosition() 
    {

    }
    public void inDialog()
    {

        for (int i = 0; i < wdList.WDList.Count; i++)
        {
            if (wdList.WDList[i] != null)
            {
                if (!wdList.WDList[i].haveOption)
                {
                    word.text = wdList.WDList[WDIndex].content;
                    speaker.text = wdList.WDList[WDIndex].speakerName;
                    WDIndex += 1;
                    break;
                }
                if (wdList.WDList[i].haveOption)
                {
                    option(i);

                }
            }
            else 
            {
                Debug.LogWarning($"第{i}段对话为空");
            }
        }
    }
    public void option(int x) 
    {
        for (int i = 0; i < wdList.WDList[i].OptionName.Count; i++)
        {
            GameObject gameObject = Instantiate(gridObj, gridObj.transform.position, Quaternion.identity);
        }
    }
    /*
    public void readtextAsset()
    {
        textAsset = Resources.Load<TextAsset>("CSV");
        if (textAsset == null)
        {
            Debug.LogError($"未找到Resources下的{"CSV"}.csv文件！");
            return;
        }
        string[] lines = textAsset.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);//RemoveEmptyEntries —— 过滤空行 / 空字符串
        for (int i = 0; i < lines.Length; i++)
        {
            Debug.Log(lines[i]);
            string[] columns = lines[i].Split(',');
            if (columns.Length < 4) // 确保列数匹配
            {
                Debug.LogWarning($"第{i}行数据不完整：{lines[i]}");
                continue;
            }
            for (int x = 0; x < columns.Length; x++)
            {
                Debug.Log(columns[x]);
                var b = columns[0];
            }
        }
    }
    */
}
