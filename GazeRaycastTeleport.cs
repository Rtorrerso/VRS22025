using UnityEngine;
using UnityEngine.UI; // Usar TMPro si usas TextMeshPro
using TMPro;


public class GazeRaycastTeleport : MonoBehaviour
{
    public Camera cam;
    public Transform targetObject;
    public Transform newPosition;
    public float gazeTimeRequired = 3f;

    public TMP_Text gazeText; // Texto UI
    public string mensaje = "Ir a recepción";
    public float fadeSpeed = 2f;

    private float gazeTimer = 0f;
    private bool isFadingIn = false;
    private bool hasFadedIn = false;

    void Start()
    {
        SetTextAlpha(0f);
        gazeText.text = mensaje;
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == targetObject)
            {
                gazeTimer += Time.deltaTime;

                // Activar fade in
                if (!hasFadedIn)
                {
                    isFadingIn = true;
                    hasFadedIn = true;
                }

                if (gazeTimer >= gazeTimeRequired)
                {
                    cam.transform.position = newPosition.position;
                    gazeTimer = 0f;
                    hasFadedIn = false;
                }
            }
            else
            {
                ResetFade();
            }
        }
        else
        {
            ResetFade();
        }

        // Manejar el efecto visual
        if (isFadingIn)
        {
            float alpha = Mathf.Lerp(GetTextAlpha(), 1f, Time.deltaTime * fadeSpeed);
            SetTextAlpha(alpha);

            if (alpha >= 0.95f)
            {
                isFadingIn = false;
            }
        }
        else if (!hasFadedIn)
        {
            float alpha = Mathf.Lerp(GetTextAlpha(), 0f, Time.deltaTime * fadeSpeed);
            SetTextAlpha(alpha);
        }
    }

    void ResetFade()
    {
        gazeTimer = 0f;
        hasFadedIn = false;
    }

    void SetTextAlpha(float alpha)
    {
        Color c = gazeText.color;
        c.a = alpha;
        gazeText.color = c;
    }

    float GetTextAlpha()
    {
        return gazeText.color.a;
    }
}
