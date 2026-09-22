using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public bool isInside = false;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }

    public void OnClicked()
    {
        if (isInside)
        {
            Debug.Log("Enemy down!");
            Destroy(gameObject);
            GameManager.Instance.SetScores(1);
        }
    }

 
}
