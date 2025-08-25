using UnityEngine;

public class movimiento : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    private Vector3 keyboardRotation = Vector3.zero;

    void Start()
    {
        gyroEnabled = SystemInfo.supportsGyroscope;

        if (gyroEnabled)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = GyroToUnity(gyro.attitude);
        }
        else
        {
            float speed = 50f;

            // Ejes horizontales y verticales (WASD y Flechas)
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            keyboardRotation.y += horizontal * speed * Time.deltaTime;
            keyboardRotation.x -= vertical * speed * Time.deltaTime;

            // Espaciadora para reset
            if (Input.GetKeyDown(KeyCode.Space))
                keyboardRotation = Vector3.zero;

            transform.rotation = Quaternion.Euler(keyboardRotation);
        }
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}

