using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y <= -6.5f)
        {
            transform.position = new Vector3(Random.Range(-9.22f, 9.22f), 6.5f, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        Player_sc player = other.GetComponent<Player_sc>();

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            transform.position = new Vector3(Random.Range(-9.22f, 9.22f), 6.5f, 0);
        }
        else if (other.tag == "Player")
        {
            player.damage();
            transform.position = new Vector3(Random.Range(-9.22f, 9.22f), 6.5f, 0);

        }
    }
}
