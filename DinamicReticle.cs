using UnityEngine;
using UnityEngine.UI;

public class DynamicReticle : MonoBehaviour
{
    public Camera vrCam;
    public float range = 50f;
    public LayerMask hitMask;     // asigna Hittable
    public Color idle = Color.white;
    public Color over = Color.green;

    Image _img;

    void Awake() => _img = GetComponent<Image>();

    void Update()
    {
        var ray = new Ray(vrCam.transform.position, vrCam.transform.forward);
        bool hit = Physics.Raycast(ray, range, hitMask);
        _img.color = hit ? over : idle;
        // opcional: tamaño
        float s = hit ? 1.2f : 1.0f;
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * s, Time.deltaTime * 10f);
    }
}

