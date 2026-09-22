using UnityEngine;

public class EnemyDroneTransform : MonoBehaviour
{
    public Vector3 startingPoint;
    public Vector3 endPoint;
    public AnimationCurve moveCurve;

    public float LerpTime = 5.0f;
    private float elapsedTime;
    void Start()
    {
        
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        float toa = LerpTime * 100;

        float t = elapsedTime / toa;

        float curveM = moveCurve.Evaluate(t);

        transform.position = Vector3.Lerp(startingPoint, endPoint, Mathf.PingPong(Time.time, curveM));
    }
}
