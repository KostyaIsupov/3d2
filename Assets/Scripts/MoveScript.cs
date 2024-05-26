using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    Rigidbody rigidbody;
    public Text coinsCount;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(0, 0, -speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            int coins = Convert.ToInt32(coinsCount.text) + 1;
            coinsCount.text = coins.ToString();
        }
    }
}
