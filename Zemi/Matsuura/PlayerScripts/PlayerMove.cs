using UnityEngine;
/// <summary>
/// プレイヤーの移動統括
/// </summary>
public class PlayerMove : MonoBehaviour
{
    private IMoveStrategy _strategy = new WalkMove();
    private MoveStrategyChanger _moveStrategy;
    private Rigidbody2D _rb;
    private float _moveSpeed = default;
    public float MoveSpeed => _moveSpeed;
    public MoveStrategyChanger MoveStrategyChanger => _moveStrategy;
    void Awake()
    {
        _moveStrategy = new MoveStrategyChanger(this);
        _rb = GetComponent<Rigidbody2D>();
       
    }
    /// <summary>
    /// 移動処理設定
    /// </summary>
    /// <param name="newStrategy">新しい移動ストラテジー</param>
    public void SetStrategy(IMoveStrategy newStrategy)
    {
        _strategy = newStrategy;
    }
    /// <summary>
    /// 移動処理のインプット感知
    /// </summary>
    /// <param name="input">インプットシステムの入力値</param>
    public void OnMoveInput(float input)
    {
        if (_strategy == null)
        {
            return;
        }
        _strategy.Move(input, _rb);
    }
    public void SetMoveData(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
