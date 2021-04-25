using UnityEngine;

public class PointInTime 
{
    public Vector3 position;
    public Vector3 desiredPos;
    public PointInTime (Vector3 _position, Vector3 _desiredPos)
    {
        position = _position;
        desiredPos = _desiredPos;
    }
}
