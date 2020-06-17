using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Rigidbody rb;
    public float velocity = 100.0f;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.AddForce(transform.up * velocity);
        }
            
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(transform.up * velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over"); 
        }
    }
}
