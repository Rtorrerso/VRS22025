using UnityEngine;

public class HotspotGazeTrigger : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(50f, 0f, 0f);
    public float gazeTime = 3f;

    private float gazeTimer = 0f;
    private bool isGazedAt = false;

    void Update()
    {
        if (isGazedAt)
        {
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

    public void SetGaze(bool gazed)
    {
        isGazedAt = gazed;
    }
}

