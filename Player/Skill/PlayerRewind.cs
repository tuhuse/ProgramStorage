using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// �����߂��X�L�������N���X
/// </summary>
public class PlayerRewind : MonoBehaviour
{
    private List<RewindData> _history = new();
    [SerializeField] private float _recordDuration = 15f;   // �L�^�ێ�����
    [SerializeField] private int _recordFps = 1000;           // �L�^���[�g
    [SerializeField] private float _rewindTargetTime = 10f;  // ���b�O�ɖ߂���
    [SerializeField] private float _rewindSpeed = 1000f;       // �߂鑬���i1�b��5�b���߂��j
    
    private int MaxHistory => Mathf.RoundToInt(_recordDuration * _recordFps);

    private bool _isRewinding = false;
    private Rigidbody _rb;

    public bool IsRewinding => _isRewinding;
   

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// ���W�̋L�^�A�X�V�A�폜����
    /// </summary>
    private void Update()
    {
        if (_isRewinding) return;
        // �Â��f�[�^�폜
        if (_history.Count > MaxHistory)
            _history.RemoveAt(0);

        // �L�^
        _history.Add(new RewindData
        {
            Position = transform.position,
            Rotation = transform.rotation,
            Velocity = _rb.velocity,
            Time = Time.time
        });
    }
    /// <summary>
    /// �����߂����s����
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

        // �G������~�߂�
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
    /// �v���C���[���W�����߂�����
    /// </summary>
    /// <param name="targetData"></param>
    /// <returns></returns>
    private IEnumerator RewindCoroutine(RewindData targetData)
    {
        float rewindedTime = 0f;
        float targetDuration = Time.time - targetData.Time;

        while (rewindedTime < targetDuration && _history.Count > 1)
        {
            // �X�P�[�������̎��ԂŐi�߂�
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
    /// �����߂��I������
    /// </summary>
    private void StopRewind()
    {
        _isRewinding = false;

        if (_rb != null)
            _rb.isKinematic = false;

        // ���Ԃ����ɖ߂�
        Time.timeScale = 1f;

        _history.Clear();
       
    }


   
}
