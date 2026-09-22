using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray raycast = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitpoint;
            if (Physics.Raycast(raycast, out hitpoint))
            {
                GameObject RCollider = hitpoint.collider.gameObject;

                Debug.Log("Raycast hit: " + RCollider.name);

                EnemyBase enemy = RCollider.GetComponent<EnemyBase>();
                if (enemy != null)
                {
                    enemy.OnClicked();
                }
            }


        }
    }
}
