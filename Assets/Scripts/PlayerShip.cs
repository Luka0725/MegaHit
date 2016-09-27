using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

    public float speed = 1f;
    public float degrees = 100f;
    

    

    bool onTrack = true;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        float curSpeed = speed;
        if (!onTrack)
        {
            curSpeed /= 2;
        }

        float move = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, -degrees * Time.deltaTime * Input.GetAxis("Horizontal"));

        Vector3 pos = transform.position;
        pos.x += curSpeed * transform.up.x * Time.deltaTime;
        pos.y += curSpeed * transform.up.y * Time.deltaTime;
        transform.position = pos;

        if (pos.x <= -3.45f)
        {
            transform.position = new Vector3(-3.5f, transform.position.y, transform.position.z);
        }

        if (pos.y <= -3.5f)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, transform.position.z);
        }

        if (pos.y >= 3.5f)
        {
            transform.position = new Vector3(transform.position.x, 3.5f, transform.position.z);
        }

        if (pos.x >= 3.45f)
        {
            transform.position = new Vector3(3.5f, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ship")
        {
            return;
        }

        onTrack = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ship")
        {
            return;
        }

        onTrack = true;
    }
}
