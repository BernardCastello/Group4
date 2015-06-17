using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class test : MonoBehaviour
{
    void OnTriggerStay(Collider c)
    {
        if (c.tag == "Enemy")
            print(c.gameObject.name + "is in me");
    }
}
