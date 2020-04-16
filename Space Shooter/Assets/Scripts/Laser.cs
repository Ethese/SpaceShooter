using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(0,1,0) * 5f *Time.deltaTime);

        if (transform.position.y > 9f)
        {
            Destroy(gameObject);
        }
    }
}
