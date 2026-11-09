using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ToFile 
{

    public string outPath;

    private string FullPath;
    public ToFile(string Path) { outPath = Path; }

    public string getFullPath()
    {
        return @"D:\"  + outPath;
    }
    public void SaveGame(DTSO dtSO)// 保存so文件
    {
        FullPath = getFullPath();
        try
        {
            //Directory.CreateDirectory(Path.GetDirectoryName(FullPath));//创建文件夹
            string json = JsonUtility.ToJson(dtSO, true);    //ture是美化格式
            using (FileStream fileStream = new FileStream(FullPath,FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(json);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveManager] 存档失败: {e.Message}"+ FullPath);
        }

    }
    public void LoadGame(DTSO dtSO)// 加载游戏
    {
        FullPath = getFullPath();
        try
        {
            dtSO = null;
            if (File.Exists(FullPath))
            {
                string json;
                using (FileStream fileStream = new FileStream(FullPath, FileMode.Open)) 
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        json = reader.ReadToEnd();
                    }
                }
                dtSO = JsonUtility.FromJson<DTSO>(json);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveManager] 读档失败: {e.Message}" + FullPath);
        }

    }
    public void deleteFile(string path) 
    {
        outPath = path;
        File.Delete(getFullPath());
    }
}
