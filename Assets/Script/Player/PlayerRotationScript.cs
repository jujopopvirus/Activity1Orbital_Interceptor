using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerRotationScript : MonoBehaviour
{
    float detectionRadius = 8f;
    public float rotation_speed = 6.5f;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        Transform target = OnDetectEnemies();
        if (target != null)
        {
            Vector3 dirtoTarget = (target.position - transform.position).normalized;
            Quaternion lookRot = Quaternion.LookRotation(dirtoTarget);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * rotation_speed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    
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
                Debug.Log("Enemy Detected");
            }
        }


        return current_enemy;
    }
}
