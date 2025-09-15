/// <summary>
/// スキルインターフェース
/// </summary>
public interface ISkill
{
    /// <summary>
    /// 実行処理
    /// </summary>
    void Activate();
    /// <summary>
    /// 発動中の更新処理
    /// </summary>
    /// <param name="deltaTime">deltaTime</param>
    void Update(float deltaTime);
    /// <summary>
    /// スキルが終了したか
    /// </summary>
    bool IsFinished { get; }  
}
