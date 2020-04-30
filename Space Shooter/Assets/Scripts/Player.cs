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
    [SerializeField]
    private float _lifes = 3f;
    private Spawn_Manager _spawnManager;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        if (_spawnManager == null)
        {
            Debug.Log("No se encontró SpawnManager");
        }
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
            Instantiate(_laser, transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
        }
    }

    public void LifeSistem()
    {
        _lifes --;
        Debug.Log(_lifes);

        if (_lifes < 1)
        {
            Destroy(gameObject);
            _spawnManager.StopSpawn();
        }
    }
}
