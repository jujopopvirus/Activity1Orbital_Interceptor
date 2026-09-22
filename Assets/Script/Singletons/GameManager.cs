using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TMP_Text scoreLabel;
    public int Scores = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void SetScores(int value)
    {
        Scores += value;
        Debug.Log("Scores : " + Scores);
        scoreLabel.text = "Scores : " + Scores;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
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
