using UnityEngine;

public class EnemyDroneTransform : MonoBehaviour
{
    public Vector3 startingPoint;
    public Vector3 endPoint;
    public AnimationCurve moveCurve;

    public float LerpTime = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startingPoint, endPoint, Mathf.PingPong(Time.time, LerpTime));
    }
}
