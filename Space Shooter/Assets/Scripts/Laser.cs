﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    void Update()
    {
        transform.Translate(new Vector3(0,1,0) * _speed * Time.deltaTime);

        if (transform.position.y > 9f)
        {
            Destroy(gameObject);
        }
    }
}
