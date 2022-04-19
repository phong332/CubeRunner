using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;
    GameController m_gc;
    bool isIncre;

    // Start is called before the first frame update
    private void Start()
    {
        isIncre = false;
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame

    void Update()
    {
        changeSpeed();
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        Debug.Log(speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limit"))
        {
            m_gc.incrementScore();

         //   Debug.Log("cham vao limit");
            Destroy(gameObject);
        }

    }
    public void changeSpeed()
    {
        if (m_gc.getScore() % 5 == 0 && m_gc.getScore() > 0 && !isIncre)
        {
            speed += 0.05f;
            isIncre = true;
        }
    }
}
