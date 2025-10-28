using UnityEngine;

/// <summary>
/// ジャンプ処理
/// </summary>
public class PlayerJump : MonoBehaviour,IJump
{
    private float _characterRayLength=default;
    private float _jumpForce = default;
    private Rigidbody2D _playerRB = default;
    private const int GROUNDLAYER = 64;

    //trueでジャンプ中、falseでジャンプしていない状態
    private bool _isJump = false;

    //地面判定で使うbool変数
    private bool _isGround = false;
    public float JumpForce => _jumpForce;
    private void Awake()
    {
        //リジッドボディの取得
        if (!TryGetComponent<Rigidbody2D>(out _playerRB) )
        {
            Debug.LogError("リジッドボディがついてません");
            return;
        }
    }

    private void Update()
    {
        //プレイヤーが落下中だったら
        if (_playerRB.velocity.y <= 0)
        {
            CheckGroundedByRay();
        }
    }

    /// <summary>
    /// ジャンプ処理
    /// </summary>
    public void OnjumpInput(float jumpForce)
    {
        //すでにジャンプしていたら
        if (_isJump)
        {
            //処理を終了させ、二段ジャンプしないようにする
            return;
        }

        //ジャンプ処理
        _playerRB.velocity +=new Vector2(_playerRB.velocity.x, 10);
        
        //ジャンプした判定にする
        _isJump = true;

    }

    /// <summary>
    /// ジャンプ後の地面判定処理
    /// </summary>
    public void CheckGroundedByRay()
    {
        //地面に向けてレイを飛ばす
        _isGround　= Physics2D.Raycast(this.transform.position, Vector2.down, _characterRayLength, GROUNDLAYER);
        Debug.DrawRay(this.transform.position,Vector2.down*_characterRayLength, Color.blue);

        //レイが地面に当たったら
        if (_isGround)
        {
            //再度ジャンプをできるようにする
            _isJump = false;

            //地面衝突判定をfalseにする
            _isGround = false;
        }
    }
    public void SetJumpData(float characterRayLengh,float jumpForce)
    {
        _characterRayLength = characterRayLengh;
        _jumpForce = jumpForce;
    }
}
