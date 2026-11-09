using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tp : MonoBehaviour
{
    public bool canTeleport;
    public bool isActivated;        // 是否已激活

    public Vector3 targetPosition;// 目标世界坐标
    public int targetScene;
    public string targetInfo = "天堂";

    public bool isAutomatic;         // 是否自动传送（靠近即传送）

    public GameObject canvas;
    public Text tpInfo;
    private void Awake()
    {
        isAutomatic = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetDescription();
            if (isAutomatic && isActivated)
            {
                collision.GetComponent<mainControl>().transform.position = TeleportTo();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
    }
    public Vector3 TeleportTo()
    {
        if (CanTeleport())
        {
            //SceneManager.LoadScene(targetScene);
            return targetPosition;
        }
        return transform.position;
    }
    /*
    private void OnDrawGizmos()//画碰撞体
    {
        Vector3 v3 = transform.position;
        Color color = Color.black;
        float size = 1;
        Gizmos.color = color;         //颜色
        Gizmos.DrawSphere(v3, size);//画碰撞体，位置，大小
        bool x = Physics2D.OverlapCircle(v3, size);//layermask为检测图层
    }
    */
    public void SetDescription()// 设置传送描述
    {
        if (tpInfo != null)
        {
            tpInfo.text = targetInfo;
            canvas.SetActive(true);
        }
    }
    public bool CanTeleport()// 检查是否满足传送条件
    {
        canTeleport = true;
        if (string.IsNullOrEmpty(targetInfo) || targetPosition == null || !isActivated)// 验证数据有效性
        {
            canTeleport = false;
        }


        return canTeleport;
    }
    public void ActivateTeleportPoint()// 激活传送点
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isActivated = true;
        }
    }
    public void SetTeleportPermission(bool permission)// 设置传送权限
    {
        canTeleport = permission;
    }

}