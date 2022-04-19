using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip loseSound;

    bool isCollisonWithGround;
    bool ok;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        rb = GetComponent<Rigidbody2D>();
        ok = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isCollisonWithGround)
        {
           if(aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
            rb.AddForce(Vector2.up  * jumpForce);
            isCollisonWithGround = false;   
        //    Debug.Log("nhan space");
        }    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isCollisonWithGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            if(aus && loseSound)
            {
                ok = false;
                aus.Stop();
                Time.timeScale = 0;
            }
            m_gc.setGameOverstate(true);
           // Debug.Log("Game over");
        }
    }
    public void endSound()
    {
        if (!aus.isPlaying && !ok)
        {
            aus.PlayOneShot(loseSound);
            ok = true;
        }
    }
    public void playSound()
    {
        aus.Play();
    }
}
