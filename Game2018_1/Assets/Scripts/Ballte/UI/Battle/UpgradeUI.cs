﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{

    [SerializeField]
    SkillBoardPrefab MySkillPrefab;
    [SerializeField]
    Transform Parent_Trans;
    [SerializeField]
    int SpawnSkillNum;

    List<SkillBoardPrefab> SkillBoardList;


    public void SetSkillBoard()
    {
        if (SkillBoardList==null || SkillBoardList.Count <= 0)
            SpawnNewSkillBoard();
        else
            RefreshSkillBoard();
    }
    public void SpawnNewSkillBoard()
    {
        if (SpawnSkillNum <= 0) return;
        //Spawn
        for (int i = 0; i < SpawnSkillNum;i++ )
        {
            SkillBoardList = new List<SkillBoardPrefab>();
            GameObject skillBoardGo = Instantiate(MySkillPrefab.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
            SkillBoardPrefab sbp = skillBoardGo.GetComponent<SkillBoardPrefab>();
            sbp.Init(SkillData.GetRandomSkill());
            skillBoardGo.transform.SetParent(Parent_Trans);
            SkillBoardList.Add(sbp);
        }
    }
    public void RefreshSkillBoard()
    {
        if (SpawnSkillNum <= 0) return;
        //Spawn
        for (int i = 0; i < SkillBoardList.Count; i++)
        {
            SkillBoardList[i].Init(SkillData.GetRandomSkill());
        }
    }

}
