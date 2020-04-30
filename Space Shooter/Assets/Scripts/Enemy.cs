using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -3.8f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7f,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Player pl = other.gameObject.GetComponent<Player>();
            Destroy(gameObject);

            if (pl != null)
            {
                pl.LifeSistem();
            }
        }
    }
}
