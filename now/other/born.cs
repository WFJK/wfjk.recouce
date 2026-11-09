using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class born : MonoBehaviour
{

    public GameObject drop;
    private void Start()
    {
        InvokeRepeating("createGameObject", 2,2);
    }


    public void createGameObject() 
    {
        GameObject dropObject = Instantiate(drop,transform.position, Quaternion.identity);
        dropObject.SetActive(true);
    }



}
