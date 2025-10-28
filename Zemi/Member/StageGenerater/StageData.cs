using UnityEngine;

public class StageData
{
    //各ステージの番号
    public int StageID
    {
        get; private set;
    }

    //このインスタンスが持つステージのパーツ
    private GameObject _stageParts = default;

    /// <summary>
    /// ステージの番号を受け取り、保持する
    /// </summary>
    /// <param name="stageID">生成したステージの番号</param>
    public StageData(int stageID,GameObject stageParts)
    {
        StageID = stageID;
        _stageParts = stageParts; 
    }

    /// <summary>
    /// ステージのアクティブ状態を返す
    /// </summary>
    /// <returns>trueで使用中、falseで未使用</returns>
    public bool GetStageActive()
    {
        return _stageParts.activeSelf;
    }

    /// <summary>
    /// このクラスが持つステージのパーツを渡す
    /// </summary>
    /// <returns></returns>
    public GameObject GetStageParts()
    {
        return _stageParts;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="movePosition"></param>
    public void ChangePosition(Vector3 movePosition)
    {
        _stageParts.transform.position += movePosition;
    }

    /// <summary>
    /// ステージのアクティブを切り替える
    /// </summary>
    /// <param name="isActive">trueでアクティブ、falseで非アクティブ</param>
    public void SwitchActive(bool isActive)
    {
        _stageParts.SetActive(isActive);
    }
}
