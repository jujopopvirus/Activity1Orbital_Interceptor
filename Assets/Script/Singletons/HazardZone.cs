using UnityEngine;

public class HazardZone : MonoBehaviour
{
    [SerializeField] private Vector3 HazardArea = new Vector3(3f, 3f, 12f);
    public LayerMask enemyLayer;

    private void OnEnable()
    {
        ChangeBoxSize();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.lightGreen;
        Gizmos.DrawCube(transform.position, HazardArea);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & enemyLayer) != 0)
        {
            GameManager.Instance.SetScores(-1);
        }
    }

    private void ChangeBoxSize() 
    {
        BoxCollider box = GetComponent<BoxCollider>();

        box.size = HazardArea;
    }
}
