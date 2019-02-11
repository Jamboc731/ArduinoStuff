using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : MonoBehaviour {

    public int force;
    public Manager man;
    public ArduinoConnect ard;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(new Vector3(1, Random.Range(-0.9f, 0.9f), 0) * force, ForceMode.Impulse);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().velocity *= 1.05f;
        }

        if (collision.gameObject.CompareTag("Left"))
        {
            man.scoreTwo++;
            ard.WriteToArduino("2");
        }
        if (collision.gameObject.CompareTag("Right"))
        {
            man.scoreOne++;
            ard.WriteToArduino("1");
        }
    }

}
