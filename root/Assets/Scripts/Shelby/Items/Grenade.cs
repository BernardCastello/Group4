using UnityEngine;
using System.Collections;

public class Grenade : EquipmentStats
{

    protected Rigidbody rb;
    [SerializeField]
    //protected Inventory inventory; //= GameObject.Find("FPSController").GetComponent<PlayerInventory>();

    float timer;
    float impactRadius;
    int damage;

    public void OnTriggerEnter()
    {
        //print("Picked up a grenade");
        //inventory.items.Add(gameObject);


       // gameObject.transform.parent = inventory.transform;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.SetActive(false);
        //inventory.grenades_reg++;
    }


    public void Drop()
    {
        //inventory.items.Remove(gameObject);
        //inventory.grenades_reg--;

        transform.parent = null;
    }

    //public void Drop(bool parent)
    //{

    //    inventory.items.Remove(gameObject);
    //    //inventory.grenades_reg--;

    //    if(parent)
    //    {
    //        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
    //    }

    //}

    void Throw()
    {
        rb.isKinematic = false;
        rb.useGravity = true;

        rb.AddForce(Camera.main.transform.up * 450);
        rb.AddForce(Camera.main.transform.forward * 450);

        gameObject.GetComponent<IPickup>().Drop();
        
    }

    ////throw instantiate
    //void Throw()
    //{
    //    GameObject gre = Instantiate(inventory.items[0]);
    //    Rigidbody r = gre.GetComponent<Rigidbody>();

    //    r.isKinematic = false;

    //    r.AddForce(Camera.main.transform.up * 450);
    //    r.AddForce(Camera.main.transform.forward * 450);
    //}

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        Build();
    }
}
