using UnityEngine;

public class EnemyDroneTransform : MonoBehaviour
{
    public Vector3 startingPoint;
    public Vector3 endPoint;
    [SerializeField] Transform playerTransform;
    public AnimationCurve moveCurve;

    public float LerpTime = 5.0f;
    private void OnEnable()
    {
        Debug.Log("Drone spawned");
        startingPoint = transform.position;
        endPoint = playerTransform.position;

    }

    private void OnDisable()
    {
        Debug.Log("Drone has been destroyed"); 
    }

    void Update()
    {

        float ppTime = Mathf.PingPong(Time.time / LerpTime, 1f);

        float curveM = moveCurve.Evaluate(ppTime);

        transform.position = Vector3.Lerp(startingPoint, endPoint, curveM);
    }
}
