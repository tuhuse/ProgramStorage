using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生成したStageDataのインスタンスを管理しする
/// そのステージが再使用可能かを判断するクラス
/// </summary>
public class StagePool
{
    //生成したステージのインスタンスを保管するリスト
    private List<StageData>  _stageDatas=new List<StageData>();

    /// <summary>
    /// 抽選されたステージが再使用可能かを返す
    /// 再使用可能ならtrue、不可ならfalseを返す
    /// </summary>
    /// <param name="stageDataNumber">生成するステージのデータを管理するインスタンス</param>
    public StageData SerchActiveStage(int stageDataNumber)
    {
        //シーン上に出ているステージの数分繰り返す
        foreach (StageData stages in _stageDatas)
        {

            //ステージのIDが一緒のインスタンスを探す
            if (stages.StageID == stageDataNumber)
            {

                //一致したステージのアクティブがtrueだったら
                if (stages.GetStageActive())
                {
                    Debug.Log($"一致したステージがあり、アクティブがtrueなステージあり:{stageDataNumber}番");
                    //次のステージデータを見る
                    continue;
                }

                //一致したステージのアクティブがfalseだったら
                    Debug.Log($"一致したステージがあり、アクティブがFalseなステージあり:{stageDataNumber}番");
                //再使用可能とし、再利用するステージを返す
                return stages;

            }
        }
        //一致するインスタンスがない または 一致したステージのパーツのアクティブがすべてtrueだった場合

        Debug.Log($"一致したステージなし:{stageDataNumber}番");
        return null;
    }

    public void SetStageData(StageData stageData)
    {
        _stageDatas.Add(stageData);
    }

    public void DeleteStage() 
    {
        //_stageDatas[].SwitchActive(false);
    }
}
