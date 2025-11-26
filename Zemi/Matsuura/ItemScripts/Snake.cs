using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 蛇自身のクラス
/// 追尾など蛇の動きはここで実装する
/// 未完成　デバッグしてないです
/// </summary>
public class Snake : MonoBehaviour
{
    /// <summary>
    /// １フレーム内での回転を求める際の、
    /// Directionの上限値（x, y, zで共通）
    /// </summary>
    private const float MAX_DIRECTION_VALUE = 0.5f;
    private const float SPEED = 0.5f;

    /// <summary>
    /// スキルを使ってから蛇が無効化されるまでの秒数
    /// </summary>
    private const float SNAKE_LIVE_TIME = 5f;

    /// <summary>
    /// 何秒おきにプレイヤーとの距離を比較し、ターゲット変更を行うか
    /// </summary>
    private const float TARGET_CHANGE_TIME = 0.5f;

    private PlayerController[] _players = default;
    private Vector3 _targetPos = default;
    private float _elapsedTime = 0f;

    /// <summary>
    /// FindNearestPlayerを呼んだ回数（SNAKE_LIVE_TIMEが過ぎたら0に戻る）
    /// </summary>
    private int _targetChangeNum = 0;

    /// <summary>
    /// PlayerControllerが付いているオブジェクトを収集する
    /// </summary>
    /// 
    private void Start()
    {
        _players = GameObject.FindObjectsByType<PlayerController>(FindObjectsSortMode.None);
    }

    private void Update()
    {
        if(gameObject.activeSelf == false)
        {
            return;
        }

        // スキル無効化
        if (_elapsedTime > SNAKE_LIVE_TIME)
        {
            _elapsedTime = 0f;
            _targetChangeNum = 0;
            gameObject.SetActive(false);
        }

        MoveSnake();
        _elapsedTime += Time.deltaTime;

        // ターゲット更新
        if (_elapsedTime > TARGET_CHANGE_TIME * _targetChangeNum)
        {
            FindNearestPlayer();
        }
    }

    /// <summary>
    /// 収集したプレイヤーの中で、自分に最も近いものの位置をターゲットとする
    /// </summary>
    public void FindNearestPlayer()
    {
        int nearestPlayerIndex = 0;
        float nearestPlayerDistance = 0f;

        for(int i = 0; i < _players.Length; i++)
        {
            // 自分とi番目のプレイヤーとの距離を計算する
            float myDisctance = Vector3.Distance(_players[i].gameObject.transform.position, transform.position);

            // 最初のループだった場合は、比較対象がないのでそのまま格納する
            if (i == 0)
            {
                nearestPlayerIndex = i;
                nearestPlayerDistance = myDisctance;
                continue;
            }

            if(myDisctance < nearestPlayerDistance)
            {
                nearestPlayerIndex = i;
                nearestPlayerDistance = myDisctance;
            }

        }

        // 一番近い位置にいたプレイヤーをターゲットとする
        _targetPos = _players[nearestPlayerIndex].transform.position;

        _targetChangeNum++;
    }

    /// <summary>
    /// targetの位置に向かう
    /// 多少の手加減のため、1フレームで回転する角度は制限する
    /// </summary>
    public void MoveSnake()
    {
        // これから向く予定の方向
        Vector3 direction = _targetPos - transform.position;

        // Xの値を上限値内に補正
        if(direction.x > MAX_DIRECTION_VALUE)
        {
            direction.x = MAX_DIRECTION_VALUE;
        }

        // Yの値を上限値内に補正
        if (direction.y > MAX_DIRECTION_VALUE)
        {
            direction.y = MAX_DIRECTION_VALUE;
        }

        // Zの値を上限値内に補正
        if (direction.z > MAX_DIRECTION_VALUE)
        {
            direction.z = MAX_DIRECTION_VALUE;
        }

        // 回転
        transform.rotation = Quaternion.LookRotation(direction);
        // 移動
        transform.position = transform.forward * SPEED * Time.deltaTime;
    }
}
