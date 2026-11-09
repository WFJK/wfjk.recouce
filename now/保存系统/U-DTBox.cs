using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTBox : MonoBehaviour
{

    public int MaxslotNum;

    public DTManage dTManage;
    [Tooltip("GameObject")]
    public  GameObject SaveSlot;
    public GameObject gridGameObject;

    public void createallslot() 
    {
        for (int i = 0; i < MaxslotNum; i++) { createSlot(i); }
    }

    public GameObject createSlot(int num) 
    {
        GameObject gameObject = Instantiate(SaveSlot, gridGameObject.transform.position, Quaternion.identity);
        gameObject.transform.SetParent(gridGameObject.transform);
        gameObject.SetActive(true);
        gameObject.GetComponent<DTSaveSlot>().give(num);
        return gameObject;
    }
    public DTSO GetSlotDTSO(int slot)// 获取存档槽位信息
    {
        try
        {
            DTSO dTSO = gridGameObject.transform.GetChild(slot).GetComponent<DTSaveSlot>().saveData;
            return dTSO;
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveManager] 读取槽位信息失败: {e.Message}");
            return null;
        }


    }
    public void DeleteSave(int slot)// 删除指定槽位的存档
    {
        try
        {
            string outpath=gridGameObject.transform.GetChild(slot).GetComponent<DTSaveSlot>().path;
            dTManage.deleteFile(outpath);
            gridGameObject.transform.GetChild(slot).GetComponent<DTSaveSlot>().saveData = null;

            Debug.Log($"[SaveManager] 删除存档: Slot {slot}");
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveManager] 删除存档失败: {e.Message}");
        }
    }

}
