using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Text scoreText;
    public Slider HealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        ren = GetComponent<Renderer>();
        scoreText.text = "Score: 0/7";

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
            HealthSlider.value = health;
        }
        if (collision.gameObject.tag == "child_2")
        {
            StartCoroutine(stun());
            health--;
            HealthSlider.value = health;

        }
        if (collision.gameObject.tag == "child_3")
        {
            StartCoroutine(stun());
            health--;
            HealthSlider.value = health;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Dinero")
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Score : " + score + "/7";
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
