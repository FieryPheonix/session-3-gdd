using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Poor_Man : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tr;
    public Renderer ren;

    public float hori;
    public float verti;

    public float speed = 5f;
    public float jumpspeed = 5f;

    public bool en = true;

    public int score = 0;
    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        ren = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "child_1")
        {
            StartCoroutine(stun());
            health--;
        }
        if (collision.gameObject.tag == "child_2")
        {
            StartCoroutine(stun());
            health--;
        }
        if (collision.gameObject.tag == "child_3")
        {
            StartCoroutine(stun());
            health--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Dinero")
        {
            Destroy(collision.gameObject);
            score++;
        }
       

    }
    IEnumerator stun()
    {
        en = false;
        ren.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        ren.material.color = Color.white;
        en = true;
    }

}
