using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerRotationScript : MonoBehaviour
{
    public float detectionRadius = 8f;
    public float rotation_speed = 6.5f;
    public float threshold = 0.98f;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        Transform target = OnDetectEnemies();
        if (target != null)
        {
            Vector3 dirtoTarget = (target.position - transform.position).normalized;
            dirtoTarget.y = 0f;
            dirtoTarget.Normalize();

            Quaternion lookRot = Quaternion.LookRotation(dirtoTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotation_speed);

            float al = Vector3.Dot(transform.forward, dirtoTarget);

            if (al > threshold)
            {
                Debug.Log("Target Locked! : " + al);
            }


        }
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

    }

    public Transform OnDetectEnemies()
    {
        Collider[] hitColl = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        Vector3 currPos = transform.position;
        float closePos = Mathf.Infinity;

        Transform current_enemy = null;


        foreach (Collider enemyCol in hitColl)
        {

            Vector3 dirToCol = enemyCol.transform.position - currPos;
            float enemyPos = dirToCol.sqrMagnitude;

            

            if (enemyPos > detectionRadius)
            {
                closePos = enemyPos;
                current_enemy = enemyCol.transform;
                Debug.DrawLine(transform.position, dirToCol, Color.green);
                Debug.Log("Enemy Detected");

                EnemyBase en = enemyCol.GetComponent<EnemyBase>();
                en.isInside = true;
            }
        }


        return current_enemy;
    }
}
