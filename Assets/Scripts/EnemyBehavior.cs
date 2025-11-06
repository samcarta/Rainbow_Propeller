using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject sightline;
    [SerializeField] GameObject enemy;
    [SerializeField] float flipTime = 5f;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Time.time - timer >= flipTime)
        {
            enemy.transform.Rotate(0f, 180f, 0f);
            sightline.transform.Rotate(0f, 180f, 0f);
            timer = Time.time;
        }
    }
}

