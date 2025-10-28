
/// <summary>
/// 舌の状態を管理する
/// </summary>
public class TongueStateController
{

    public enum TongueState
    {
        Idle,
        ScaleUp,
        ScaleDown,
    }



    //ベロの状態をenumで管理する変数
    private TongueState _nowTongueState = TongueState.Idle;

    //trueでヒットした判定、falseでヒットしてない判定
    private bool _isHit = false;

    public TongueState NowTongueState
    {
        get { return _nowTongueState; }
        set { _nowTongueState = value; }
    }

    public bool IsTouch
    {
        get { return _isHit; }
        set { _isHit = value; }
    }

    /// <summary>
    /// 舌の状態を指定した状態に変更する
    /// </summary>
    /// <param name="changeTongueState">変更したい状態</param>
    public void ChangeTongueState(TongueState changeTongueState)
    {
        _nowTongueState=changeTongueState;
    }
}
