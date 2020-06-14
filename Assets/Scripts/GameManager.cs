using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{

    public PlayerSettings settings;
    public List<Transform> EnemyTargetList = new List<Transform>();

    public static GameManager GetFromScene()
    {
        return FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        RefreshEnemyTargetList();
    }

    public void RefreshEnemyTargetList()
    {
        EnemyTargetList.Clear();
        var _targets = FindObjectsOfType<EnemyTarget>();
        foreach (var item in _targets)
        {
            EnemyTargetList.Add(item.transform);
        }
    }
}
