using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenuAttribute(fileName = "任务", menuName = "任务")]
public class RWSO : ScriptableObject
{
    public string rwID;
    public string rwName;
    public string rwinfo;

    public rwType rwType;

    public int expReward;
    public int goldReward;
    public List<MNclass> RewardMN;

    public List<rwMNAndNum> needMNAndNum;

    public List<rwEnemyAndNum> needEnemyAndNums;



}
public class rwMNAndNum 
{ 
    public int rwNeedNum;
    public MNclass needMN;
}
public class rwEnemyAndNum
{
    public int rwNeedNum;
    public enemyBase enemy;
}