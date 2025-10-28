using UnityEngine;

public class StickOutTongue : MonoBehaviour
{
    private const float RATE_MULTIPLY_IN_POSITION = 0.5f;

    [SerializeField]
    private float _maxLength = 10.0f;

    [SerializeField]
    private float _minLength = 1.0f;

    [SerializeField]
    private float _timeToMaxLength = 1.0f;

    [SerializeField]
    private float _velocityWidth = 1.5f;

    // 舌を出すときのスピード（初期値は最高スピード）
    private float _addScaleToXPerSeconds = default;
    private float _addPosXPerSeconds = default;
    private Vector3 _addScaleVector = new Vector3();
    private Vector3 _addPosVector = new Vector3();

    // スピードを変動させるために一フレームで足し引きする値
    private float _addSpeed = default;

    private TongueHitJudger _tongueHitJudger;

    private TongueStateController _tongueStateController= new TongueStateController();
    public TongueStateController TongueState => _tongueStateController;

    /// <summary>
    /// 一秒で動かすPositionとSizeを計算し、格納する
    /// </summary>
    void Start()
    {
        // 計算（初期値なので、最高スピードに補正する）
        _addScaleToXPerSeconds = _maxLength / _timeToMaxLength + (_velocityWidth / 2f * _timeToMaxLength);
        _addPosXPerSeconds = _addScaleToXPerSeconds * RATE_MULTIPLY_IN_POSITION;

        // 格納
        _addScaleVector.x = _addScaleToXPerSeconds;
        _addPosVector.x = _addPosXPerSeconds;

        // 一フレームで足し引きする値を計算する
        _addSpeed = _velocityWidth / _timeToMaxLength;

        _tongueHitJudger = new TongueHitJudger(this.transform,GetComponent<SpriteRenderer>().sprite,_tongueStateController);

    }

    /// <summary>
    /// 入力受付と舌を動かす
    /// </summary>
    void Update()
    {
        MoveTongue();

        // 舌が動いていないとき、入力を受け付ける
        //if(_tongueStateController.NowTongueState == TongueStateController.TongueState.Idle)
        //{
        //    ReceiveInputToTongue();

        //}
    }

    private void ChangeSpeed(float addValue)
    {
        // 計算
        _addScaleToXPerSeconds += addValue;
        _addPosXPerSeconds = _addScaleToXPerSeconds * RATE_MULTIPLY_IN_POSITION;

        // 格納
        _addScaleVector.x = _addScaleToXPerSeconds;
        _addPosVector.x = _addPosXPerSeconds;
    }

    /// <summary>
    /// 舌を出す入力を受け取る。入力を受け取りたくないタイミングでは呼び出さない。
    /// </summary>
    public void ReceiveInputToTongue()
    {     
        _tongueStateController.ChangeTongueState(TongueStateController.TongueState.ScaleUp);
    }

    /// <summary>
    /// 舌の状態に合わせて舌を動かす
    /// </summary>
    private void MoveTongue()
    {
        switch (_tongueStateController.NowTongueState)
        {
            case TongueStateController.TongueState.ScaleUp:

                ScaleUp();

                _tongueHitJudger.hitJudge();

                break;

            case TongueStateController.TongueState.ScaleDown:

                ScaleDown();

                _tongueHitJudger.hitJudge();
                break;

            default:

                break;
        }


    }

    /// <summary>
    /// StateがScaleUpのときに呼び出す
    /// </summary>
    private void ScaleUp()
    {
        // 舌を伸ばす処理
        if (gameObject.transform.localScale.x < _maxLength)
        {
            gameObject.transform.localScale += _addScaleVector * Time.deltaTime;
            _tongueHitJudger.ChangeCollisionSize();
            ChangeSpeed(-_addSpeed * Time.deltaTime);
        }
        else
        {
            _tongueStateController.ChangeTongueState(TongueStateController.TongueState.ScaleDown);
        }
    }

    /// <summary>
    /// StateがScaleDownのときに呼び出す
    /// </summary>
    private void ScaleDown()
    {
        // 舌をひっこめる処理
        if (gameObject.transform.localScale.x > _minLength)
        {
            gameObject.transform.localScale -= _addScaleVector * Time.deltaTime;
            _tongueHitJudger.ChangeCollisionSize();
            ChangeSpeed(_addSpeed * Time.deltaTime);
        }
        else
        {
            _tongueStateController.ChangeTongueState(TongueStateController.TongueState.Idle);
            _tongueStateController.IsTouch = false;
        }

        
    }
}
