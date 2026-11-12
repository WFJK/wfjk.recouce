using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MNEquip : MonoBehaviour
{
    public MNlist mnlist;


    public equipMNSO equipMNSO;

    public equipType slotType;

    public Sprite sprite;
    private void Awake()
    {
        mnlist = FindFirstObjectByType<MNlist>();
    }
    private void Start()
    {

    }
    public void give(MNclass mNclass)
    {
        if (mNclass == null) { return; }



    }
    public bool canEquip()
    {
        return false;
    }

    public void Equip()
    {
        if (canEquip()) 
        {

        }
    }
    public void unEquip()
    {

    }
}
