using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 巻き戻しスキル処理クラス
/// </summary>
public class PlayerRewind : MonoBehaviour
{
    private List<RewindData> _history = new();
    [SerializeField] private float _recordDuration = 15f;   // 記録保持時間
    [SerializeField] private int _recordFps = 1000;           // 記録レート
    [SerializeField] private float _rewindTargetTime = 10f;  // 何秒前に戻すか
    [SerializeField] private float _rewindSpeed = 1000f;       // 戻る速さ（1秒で5秒分戻す）
    
    private int MaxHistory => Mathf.RoundToInt(_recordDuration * _recordFps);

    private bool _isRewinding = false;
    private Rigidbody _rb;

    public bool IsRewinding => _isRewinding;
   

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// 座標の記録、更新、削除処理
    /// </summary>
    private void Update()
    {
        if (_isRewinding) return;
        // 古いデータ削除
        if (_history.Count > MaxHistory)
            _history.RemoveAt(0);

        // 記録
        _history.Add(new RewindData
        {
            Position = transform.position,
            Rotation = transform.rotation,
            Velocity = _rb.velocity,
            Time = Time.time
        });
    }
    /// <summary>
    /// 巻き戻し実行処理
    /// </summary>
    public void StartRewind()
    {
        if (_isRewinding || _history.Count < 2)
        {
            return;
        }
        _isRewinding = true;
        if (_rb != null)
        {
            _rb.velocity = Vector3.zero;
            _rb.isKinematic = true;
        }

        // 敵や環境を止める
        Time.timeScale = 0f;

        float targetTime = Time.time - _rewindTargetTime;
        if (targetTime < _history[0].Time)
            targetTime = _history[0].Time;

        RewindData rewindPoint = _history[0];
        for (int i = _history.Count - 1; i >= 0; i--)
        {
            if (_history[i].Time <= targetTime)
            {
                rewindPoint = _history[i];
                break;
            }
        }

        StartCoroutine(RewindCoroutine(rewindPoint));
    }


    /// <summary>
    /// プレイヤー座標巻き戻し処理
    /// </summary>
    /// <param name="targetData"></param>
    /// <returns></returns>
    private IEnumerator RewindCoroutine(RewindData targetData)
    {
        float rewindedTime = 0f;
        float targetDuration = Time.time - targetData.Time;

        while (rewindedTime < targetDuration && _history.Count > 1)
        {
            // スケール無視の時間で進める
            rewindedTime += Time.unscaledDeltaTime * _rewindSpeed;

            float desiredTime = Time.time - rewindedTime;

            for (int i = _history.Count - 1; i >= 0; i--)
            {
                if (_history[i].Time <= desiredTime)
                {
                    transform.position = _history[i].Position;
                    transform.rotation = _history[i].Rotation;
                    break;
                }
            }

            yield return null;
        }

        StopRewind();
    }


    /// <summary>
    /// 巻き戻し終了処理
    /// </summary>
    private void StopRewind()
    {
        _isRewinding = false;

        if (_rb != null)
            _rb.isKinematic = false;

        // 時間を元に戻す
        Time.timeScale = 1f;

        _history.Clear();
       
    }


   
}
