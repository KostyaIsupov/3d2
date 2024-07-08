using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    Rigidbody rigidbody;
    public Joystick joystick;
    public Text coinsCount;
    public int allCoins;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        allCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        float horisontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
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
        rigidbody.velocity = new Vector3(vertical * speed, rigidbody.velocity.y, -horisontal * speed);
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
