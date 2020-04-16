using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _laser;
    private float _fireRate = 0.5f;
    private float _canFire = -1;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Movimiento();
        Limites();
        Disparo();
    }

    void Movimiento()
    {
        //Direccion
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontal, Vertical, 0);

        transform.Translate(movimiento *  _speed * Time.deltaTime);
    }

    void Limites()
    {
        if (transform.position.y > 5.7f)
        {
            transform.position = new Vector3(transform.position.x, 5.7f, 0);
        }else if(transform.position.y < -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.x > 9.7f)
        {
            transform.position = new Vector3(-9.7f, transform.position.y, 0);
        }else if (transform.position.x < -9.7f)
        {
            transform.position = new Vector3(9.7f, transform.position.y, 0);
        }
    }

    void Disparo()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laser, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
    }
}
