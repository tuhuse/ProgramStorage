using UnityEngine;

/// <summary>
/// カメラの移動処理を管理するクラス
/// </summary>
public class CameraMover
{
    //カメラのトランスフォームコンポーネント
    private Transform _cameraTransform = default;

    //カメラの移動先
    private Vector3 _moveDestination = default;

    //カメラの移動する速さ
    private float _moveSpeed = 5;

    /// <summary>
    /// カメラのトランスフォームコンポーネントを受け取り、保管する
    /// </summary>
    /// <param name="cameraTransform">カメラのトランスフォームコンポーネント</param>
    public CameraMover(Transform cameraTransform)
    {
        _cameraTransform = cameraTransform;
    }

    /// <summary>
    /// カメラを移動させる
    /// </summary>
    public void MoveCamera()
    {
        //カメラの移動処理
        _cameraTransform.position += _moveDestination*(Time.deltaTime*_moveSpeed);

    }
    /// <summary>
    /// 移動先を変更する
    /// </summary>
    /// <param name="changeValue">変更したい移動先（方向）</param>
    public void SetMoveDestination(Vector3 changeValue)
    {
        //カメラの移動先を変更する
        _moveDestination = changeValue;
    }

}
