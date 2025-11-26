using UnityEngine;

/// <summary>
/// ロケット自体の動きを実装する
/// プレハブにアタッチする
/// </summary>
public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    private Renderer _renderer = default;

    /// <summary>
    /// 画面外判定をするためのRendererを取得
    /// </summary>
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// 位置更新・画面外判定
    /// </summary>
    private void Update()
    {
        if(gameObject.activeSelf == true)
        {
            MoveRocket();
            CheckVisible();
        }
    }

    /// <summary>
    /// 自分が向いている方向（プレイヤーが打った瞬間に合わせる予定）に進む
    /// </summary>
    private void MoveRocket()
    {
        gameObject.transform.position += transform.forward * _speed * Time.deltaTime;
    }

    /// <summary>
    /// 画面外に行った場合は無効化
    /// </summary>
    private void CheckVisible()
    {
        if (!_renderer.isVisible)
        {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 何かにぶつかった場合は無効化
    /// </summary>
    /// <param name="collision">衝突相手の情報</param>
    private void OnCollisionEnter(Collision collision)
    {
       gameObject.SetActive(false); 
    }
}
