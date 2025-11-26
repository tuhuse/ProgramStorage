
using UnityEngine;

public class CameraInfo : MonoBehaviour
{
    //カメラのトランスフォーム情報
    private Transform _mainCameraTransform = default;

    private CameraShaker _cameraShaker = default;

    private CameraMover _cameraMover = default;

    //カメラが移動可能かどうかを判断する
    private bool _isCameraMovable = true;

    private void Start()
    {
        //カメラのトランスフォームコンポーネントを取得
        _mainCameraTransform = Camera.main.transform;

        //カメラを振動させる処理を管理するクラスの生成
       _cameraShaker= new CameraShaker(_mainCameraTransform);

        //カメラを移動処理を管理するクラスの生成
        _cameraMover = new CameraMover(_mainCameraTransform);
    }

    private void Update()
    {
        //カメラで繰り返し処理が必要なものを呼び出す
        CameraUpdate();

        #region　デバッグ（あとで必ず消す）

        if (Input.GetKeyDown(KeyCode.Return))
        {
            InvokeCameraVibration();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _cameraMover.SetMoveDestination(new Vector3(-1, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _cameraMover.SetMoveDestination(new Vector3(1, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _cameraMover.SetMoveDestination(new Vector3(0, 1, 0));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _cameraMover.SetMoveDestination(new Vector3(0, -1, 0));
        }

        #endregion
    }

    /// <summary>
    /// カメラで繰り返し処理が必要なものを呼び出す
    /// </summary>
    public void CameraUpdate()
    {
        //カメラの振動トリガーを常に検査する
        _cameraShaker.CheckVibrationTrigger();

        if (_isCameraMovable)
        {
            _cameraMover.MoveCamera();
        }
    }

    /// <summary>
    /// カメラの振動トリガーをONにする処理を呼び出す
    /// </summary>
    public void InvokeCameraVibration()
    {
        //カメラの振動トリガーをONにする
        _cameraShaker.OnCameraVibration();
    }
}
