using UnityEngine;
using System.Collections;

public class RampMovement : MonoBehaviour
{
    private float speed = 2f;
    private float currentHeight;
    private float range = 5;

    public bool isActive = true;
    public float Timer;

    public float rotate;
    public float delay;

	// Use this for initialization
	void Start () {
        delay = Random.Range(10, 30);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Timer += Time.deltaTime;

        if (Timer > delay && isActive == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            currentHeight -= Time.deltaTime * speed;
            print("Going Up");

            if (currentHeight <= 0)
            {
                isActive = false;
                Timer = 0;
            }
        }

        if (Timer > delay && isActive == false)
        {
            transform.Translate((Vector3.up * Time.deltaTime * speed) * -1);
            currentHeight += Time.deltaTime * speed;
            print("Going Down");

            if (currentHeight >= range)
            {
                isActive = true;
                Timer = 0;
            }
        }
	}
}
