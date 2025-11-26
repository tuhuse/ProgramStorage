using System.Collections.Generic;
using UnityEngine;

public class StageMover : MonoBehaviour
{
    [SerializeField,Header("生成するステージのプレハブ")] private List<GameObject> _stagePrehubs= new List<GameObject>();

    private  StagePool _stagePool = new StagePool();

    private void Update()
    {
        #region デバッグ用（後で必ず消す）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateStage();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InvokeDeleteStage();
        }
        #endregion
    }

    private void CreateStage()
    {
        //生成するステージをランダムで決めるため、乱数を出す
        //乱数の範囲は0～ステージのプレハブの数まで
        int randomStageNumber = Random.Range(0, _stagePrehubs.Count);

        StageData stagePool = _stagePool.SerchActiveStage(randomStageNumber);
        //再使用可能なものがなければ
        if (stagePool==null)
        {
            //新しくステージのパーツを生成する
           GameObject cleateStageObject=Instantiate(_stagePrehubs[randomStageNumber]);

            //上の乱数をステージのIDとしたステージデータのインスタンスを生成
            StageData stageData = new StageData(randomStageNumber, cleateStageObject);

            //ステージのデータを保管する
            _stagePool.SetStageData(stageData);
            return;
        }

        //もしステージIDと一致したオブジェクトで再使用可能なものがあれば
        //ステージの移動処理
        stagePool.ChangePosition(new Vector3(0,-1,0));

        stagePool.SwitchActive(true);

 
    }
    private void InvokeDeleteStage() 
    {
        _stagePool.DeleteStage();
    }
}
