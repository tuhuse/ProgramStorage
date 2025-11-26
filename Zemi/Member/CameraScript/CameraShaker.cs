using UnityEngine;

/// <summary>
/// カメラを振動させる処理を管理するクラス
/// </summary>
public class CameraShaker
{
    //振動前のカメラのポジションを保管する変数
    private Vector3 _defaultCameraPosition = default;

    //カメラのトランスフォーム情報
    private Transform _mainCameraTransform = default;

    //trueになるとカメラの振動が開始される
    private bool _isCameraShake = false;

    private int _currentFrequency = 0;

    //振動の強さ
    private const float VIBRATION_POWER = 2.5f;

    //振動する回数
    private const int MAX_FREQUENCY = 100;

    /// <summary>
    /// カメラのトランスフォームコンポーネントを受け取り、保管する
    /// </summary>
    /// <param name="cameraTransform">カメラのトランスフォームコンポーネント</param>
    public CameraShaker(Transform cameraTransform)
    {
        //ゲーム上のカメラを取得
        _mainCameraTransform = Camera.main.transform;
    }

    public void CheckVibrationTrigger()
    {
        //振動のトリガーがONになったら
        if (_isCameraShake)
        {
            //VIBRATION_POWERの強さでカメラを振動させる
            ShakeCakmera(VIBRATION_POWER);
            return;
        }

    }

    /// <summary>
    /// カメラを振動させる処理
    /// 振動回数はfrequency分振動する
    /// </summary>
    /// <param name="vibrationPower">揺れる強さ</param>
    private void ShakeCakmera(float vibrationPower)
    {
        //ランダムで動くカメラのポジションXを出す
        float afterVibrationPositionX = Random.Range(-vibrationPower, vibrationPower);

        //ランダムで動くカメラのポジションYを出す
        float afterVibrationPositionY = Random.Range(-vibrationPower, vibrationPower);

        _mainCameraTransform.position = new Vector3(afterVibrationPositionX, afterVibrationPositionY, -10);

        //振動回数に+１する
        _currentFrequency++;

        //現在の振動回数が振動してほしい回数と一致したら
        if (_currentFrequency == MAX_FREQUENCY)
        {
            //振動のトリガーをOFFにする
            _isCameraShake = false;
            //カメラを振動前の位置に戻す
            _mainCameraTransform.position = _defaultCameraPosition;

            //現在の振動回数をリセットする
            _currentFrequency = 0;
        }
    }

    /// <summary>
    /// カメラの振動のトリガーをONにする
    /// </summary>
    public void OnCameraVibration()
    {
        //振動前のカメラの位置を保管しておく
        _defaultCameraPosition = _mainCameraTransform.position;

        //振動のトリガーをONにする
        _isCameraShake = true;
    }

}
