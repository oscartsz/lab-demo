using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    RaycastHit hit;
    Transform item;
    Transform player;
    public float range;
    bool pick=false;
    void Start()
    {
        player = GetComponent<Transform>();
    }
    void Update()
    {

        if (Input.GetKey("s"))
        {
            Ray ray = new Ray(transform.position, transform.right);
            Debug.DrawRay(ray.origin, ray.direction * 2, Color.green);

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Pickable")
            {

                item = hit.transform;
                item.GetComponent<Rigidbody>().isKinematic = true;
                pick = true;
                
            }
          
           
        }
        if (pick == true)
        {
            item.transform.SetParent(player);
            item.transform.position = player.transform.position + new Vector3(range, 0);
            if (Input.GetKeyDown(KeyCode.F))
            {
                item.transform.SetParent(null);
                item.GetComponent<Rigidbody>().isKinematic = false;
                pick = false;
            }
                
        }

        
    }

}
