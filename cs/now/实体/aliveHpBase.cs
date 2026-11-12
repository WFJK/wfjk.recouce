using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class aliveHpBase : MonoBehaviour,needSave
{

    public allEvent allEvent;
    [Header("variable")]
    private bool IsDead = false;
    [Header("Component")]
    public Transform Damagetransform;
    [Header("hpCaculate")]
    public defentAbout defentAbout;
    public damageAbout damageAbout;
    public hpAbout hpAbout;

    [Header("ui")]
    public bool showHpUI;
    public Slider hpSlider;
    public Text hpText;
    public Image sliderImage;

    void Start()// 初始化玩家生命值
    {
        hpAbout.nowHp = hpAbout.maxHp.getValue();
        UpdateHealth();// 初始化血条显示
    }
    public void TakeDamage(float amount,Transform who)
    {
        if (IsDead)// 检查死亡状态
        {
            return;
        }
        if (defentAbout.isVoid()) { return; }
        amount = damageAbout.finalDamage();
        hpAbout.nowHp -= amount;               // 应用血量改变
        hpAbout.nowHp = Mathf.Clamp(hpAbout.nowHp, 0, hpAbout.maxHp.getValue());
        UpdateHealth();
        if (hpAbout.nowHp <= 0f)// 检查死亡状态
        {
            Die();
        }
    }

    public virtual void Die()// 死亡处理方法
    {
        IsDead = true;
        allEvent.callOnEnemyDie(GetComponent<enemyBase>().ID);
    }
    private void UpdateHealth()// 更新血条显示
    {
        if (!showHpUI || hpSlider == null) return;
        hpSlider.value = hpAbout.hpRate();// 更新血条长度
        hpText.text = hpAbout.nowHp + "/" + hpAbout.maxHp.getValue(); //更新文本
        // 根据血量改变血条颜色
        if (hpAbout.hpRate() > 0.6f)
        {
            sliderImage.color = Color.green;
        }
        else if (hpAbout.hpRate() > 0.3f)
        {
            sliderImage.color = Color.yellow;
        }
        else
        {
            sliderImage.color = Color.red;
        }

    }
    public void FullHeal()// 完全恢复生命值
    {
        hpAbout.nowHp = hpAbout.maxHp.getValue();
    }

    public void SetMaxHealth(float newMaxHealth)//新的最大生命值
    {
        float healthRatio = hpAbout.hpRate();
        hpAbout.maxHp.baseValue = newMaxHealth;
        hpAbout.maxHp.baseValue = Mathf.Max(hpAbout.maxHp.baseValue, newMaxHealth);
        hpAbout.nowHp = hpAbout.maxHp.baseValue * healthRatio;
    }
    


    public SetGetClass enumToSetGetClass(ValueType valueType) 
    {
        switch (valueType) 
        {
            case AllValueType.防御力:
                return defentAbout.defentValue;




        }



        return null;
    }
    public void saveData(ref DTSO dTSO) 
    {
        dTSO.maxHp = hpAbout.maxHp.getValue();
        dTSO.nowHp = hpAbout.nowHp;
    }
    public void loadData(DTSO dTSO) 
    {
        hpAbout.maxHp.baseValue = dTSO.maxHp;
    }





}


