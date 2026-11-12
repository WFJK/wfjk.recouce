using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class PooledObject<T> : MonoBehaviour where T : Component// 泛型版池化物体类（T为具体的池化物体类型，比如Bullet/Enemy）
{
    [Header("pool")]
    public ObjectPool<T> pool;
    [Header("泛型对象池配置")]
    public T prefab; // 要池化的预制体（必须是PooledObject<T>子类）
    public int initialPoolSize = 10; // 初始池大小
    public bool autoExpand = true; // 自动扩容
    private List<T> prefabs = new List<T>(); // 存储池化物体

    private void Awake()
    {
        // 初始化池：提前创建指定数量的物体
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewObject();
        }
    }
    private T CreateNewObject()// 创建新的池化物体（内部方法）
    {
        T newObj = Instantiate(prefab, transform);
        Initialize(pool); // 关联对象池"this" 指当前的ObjectPool<T>实例（告诉物体“你属于我这个池”）
        newObj.gameObject.SetActive(false);
        prefabs.Add(newObj);
        return newObj;
    }
    public void Initialize(ObjectPool<T> parentPool)    // 初始化：关联对象池 + 重置物体状态
    {
        pool = parentPool;
        ResetObject(); // 回收时重置物体状态（比如清空速度、特效）
    }



    protected virtual void ResetObject()    // 重置物体状态（子类可重写，比如子弹清空速度、敌人重置血量）
    {
        // 基础重置：停止移动、关闭特效等
    }
    public void ReturnToPool()           // 回收物体到对象池（替代Destroy）
    {
        if (pool != null)
        {
            ReturnObject(prefab); // 通知对象池回收
        }
        else
        {
            // 容错：无对象池时直接销毁（避免内存泄漏）
            Destroy(gameObject);
        }
    }
    public void AutoReturnToPool(float delay)// 自动回收
    {
        Invoke(nameof(ReturnToPool), delay);
    }

    private void OnDestroy()    // 防止误删：销毁时强制回池
    {
        if (pool != null)
        {
            ReturnObject(prefab);
        }
    }
    public void ReturnObject(T obj)    // 回收物体到池
    {
        obj.gameObject.SetActive(false);
    }
    public T GetObject(Vector3 position, Quaternion rotation)    // 从池获取物体（指定位置和旋转）
    {
        // 查找闲置物体
        foreach (var obj in prefabs)
        {
            if (!obj.gameObject.activeInHierarchy) //判断最终的激活状态（受父物体影响）,判断物体是否 “真正显示在场景中”
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        // 自动扩容
        if (autoExpand)
        {
            T newObj = CreateNewObject();
            newObj.transform.position = position;
            newObj.transform.rotation = rotation;
            newObj.gameObject.SetActive(true);
            return newObj;
        }

        Debug.LogWarning($"[{typeof(T).Name}] 对象池已满，无法获取新物体！");
        return null;
    }


}
public class Bullet : PooledObject<Bullet>
{
    public float speed = 10f; // 子弹速度

    void Update()
    {
        // 子弹移动逻辑
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // 重写重置逻辑（子弹专属）
    protected override void ResetObject()
    {
        base.ResetObject(); // 调用父类通用重置
        speed = 10f; // 重置子弹速度
    }

    // 碰撞后回收
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            ReturnToPool(); // 回收子弹到池
        }
    }
}