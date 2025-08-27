using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturaHotSpot : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(50f, 0f, 0f);
    public float gazeTime = 3f;
    private float gazeTimer = 0f;
    private bool isGazedAt = false;

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
                isGazedAt = true;
                Debug.Log("Vamos al patio1");
                gazeTimer += Time.deltaTime;
                if (gazeTimer >= gazeTime)
                    {
                    // Mover la cámara principal a la nueva posición
                    Camera.main.transform.position = targetPosition;
                    // Reiniciar para evitar múltiples disparos
                    gazeTimer = 0f;
                    isGazedAt = false;
                    }
            }
            else
            {
                gazeTimer = 0f;
            }

            
        }
        else
        {
            Debug.DrawRay(transform.position, fwd * 5, Color.red);
        }
    }
}
