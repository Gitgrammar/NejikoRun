﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 30;

    int currentChipIndex;

    public Transform character;
    public GameObject[]stageChips;
    public int startChipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();


    void Start()
    {
        currentChipIndex = startChipIndex - 1;
        UpdateStage(preInstantiate);
    }

    
    void Update()
    {
        //きゃらくたーの位置から現在のステージチップインデクスを計算
        int charaPositionIndex = (int)(character.position.z / StageChipSize);

        //次のステージチップに入ったらステージの更新処理を行う。
        if (charaPositionIndex + preInstantiate > currentChipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
        
    }
    //指定のindexまでのステージチップを生成して管理課に置く
    void UpdateStage(int toChipIndex)
    {
        if (toChipIndex <= currentChipIndex) return;
        //指定のステージチップまでを生成
        for (int i = currentChipIndex + 1 ;i<= toChipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);

            //生成したステージチップを管理リストに追加
            generatedStageList.Add(stageObject);
        }

        //ステージ保持上限ないになるまで古いステージを削除
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

        currentChipIndex = toChipIndex;
    }
    //指定のインデクス位置にステージオブジェクトをランダムに生成
    GameObject GenerateStage(int chipIndex)
    {
        int nextStageChip = Random.Range(0, stageChips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageChips[nextStageChip],
            new Vector3(0, 0, chipIndex * StageChipSize),
            Quaternion.identity
            );
        return stageObject;
    }
    //１番古いステージを削除
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
