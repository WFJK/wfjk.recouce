using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static Unity.Collections.Unicode;

public class DTManage : MonoBehaviour
{
    public DTSO dtSO;

    public List<needSave> needSaves;

    public ToFile DTfile;

    public string outPath= "gameSave/dtSO.json";
    void  Start()
    {
        DTfile = new ToFile(outPath);
        needSaves = needSaveObj();
    }


    public void newPathToSave(string outpath) { DTfile.outPath = outpath; save(); }
    public void save() 
    {
        foreach (var needSave in needSaves) 
        {
            needSave.saveData(ref dtSO);
        }
        DTfile.SaveGame(dtSO);
        Debug.Log($"文件已保存至{DTfile.getFullPath()}");
    }

    public void load(DTSO dTSO)
    {
        foreach (var needSave in needSaves)
        {
            needSave.loadData(dTSO);
        }
        DTfile.LoadGame(dTSO);
    }

    public bool IsflieExist( ) { return File.Exists(DTfile.getFullPath()); }
    public void deleteFile(string path)
    {
        DTfile.deleteFile(path);
    }
    public List<needSave> needSaveObj() 
    { 
        return FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include,FindObjectsSortMode.None).OfType<needSave>().ToList();
    }


}
