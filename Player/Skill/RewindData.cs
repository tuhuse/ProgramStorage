using UnityEngine;
/// <summary>
/// 座標データ
/// </summary>
[System.Serializable]
public struct RewindData
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Velocity;
    public float Time;
}
