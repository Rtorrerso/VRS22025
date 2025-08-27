using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    LayerMask layerMask;
    void Start()
    {
        
    }
    void Awake()
    {
        layerMask = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 5, layerMask))
        {
            Debug.DrawRay(transform.position, fwd * 5, Color.blue);
            if (hit.collider.gameObject.name == "Patio1")
            {
                Debug.Log("Vamos al patio1");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, fwd * 5, Color.red);
        }
    }
}
