using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //publica o privada
    //int float bool string
    //nombre variable
    //valor
    [SerializeField]
    private float speed;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        //new Vector3(1,0,0)
        //new Vector3(0,1,0)
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        transform.Translate(Vector3.up *Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
}
