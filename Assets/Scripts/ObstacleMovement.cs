using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed;
    GameController m_gc;
    int tmp;

    // Start is called before the first frame update
    private void Start()
    {
        speed = 5f;
        tmp = 1;
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        if(m_gc.getScore()/10 >= tmp)
        {
            speed += 0.1f;
            tmp += 1;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limit"))
        {
            m_gc.incrementScore();

            Debug.Log("cham vao limit");
            Destroy(gameObject);
        }

    }

}
