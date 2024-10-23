using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _nextFire = 0.2f;
    [SerializeField]
    private float _fireRate = 0.3f;
    [SerializeField]
    int lives = 3;

    public GameObject laser;




    void Update()
    {
        method();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            atis();

        }

        void atis()
        {
            Instantiate(laser, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            _nextFire = Time.time + _fireRate;
        }
    }


    void method()

    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, VerInput, 0);
        transform.Translate(direction * Time.deltaTime * _speed);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -8.3f, 0), 0);
        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    public void damage()
    {
        lives--;
        if (lives <= 0)
        {
            Destroy(gameObject);
            // end the game
            Time.timeScale = 0f; // Freeze the game

        }
    }
}
