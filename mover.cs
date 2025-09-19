using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public float velocidad = 50f;
    private bool esAndroid;

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        esAndroid = true;
        Input.gyro.enabled = true;
#else
        esAndroid = false;
#endif
    }

    void Update()
    {
        if (esAndroid)
        {
            // Control por giroscopio
            Quaternion rotacionGiro = Input.gyro.attitude;
            rotacionGiro = new Quaternion(-rotacionGiro.x, -rotacionGiro.y, rotacionGiro.z, rotacionGiro.w);
            transform.localRotation = rotacionGiro;
        }
        else
        {
            // Control por teclado (flechas)
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 rotacion = new Vector3(-vertical, horizontal, 0f);
            transform.Rotate(rotacion * velocidad * Time.deltaTime, Space.Self);
        }
    }
}


