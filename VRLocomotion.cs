using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class VRLocomotion : MonoBehaviour
{
    [Header("Refs")]
    public CharacterController controller;
    public Transform headOrCamera; // arrastra la Main Camera (hija de Camera Offset)

    [Header("Movimiento")]
    public float moveSpeed = 1.6f;      // m/s
    public float gravity = -9.81f;
    public float snapTurnDegrees = 5f; // giro por pasos en PC

    private float _yVel; // para gravedad acumulada

    void Reset()
    {
        controller = GetComponent<CharacterController>();
        if (Camera.main != null) headOrCamera = Camera.main.transform;
    }

    void Update()
    {
        if (controller == null || headOrCamera == null) return;

        Vector3 move = Vector3.zero;

        // ===== PC / Editor: flechas =====
        #if UNITY_STANDALONE || UNITY_EDITOR
        float forward = 0f, turn = 0f;

        // Adelante/atrás con ↑/↓
        if (Input.GetKey(KeyCode.UpArrow)) forward += 1f;
        if (Input.GetKey(KeyCode.DownArrow)) forward -= 1f;

        // Giro por pasos con ←/→ (discreto cuando se pulsa)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Rotate(0f, -snapTurnDegrees, 0f);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.Rotate(0f, +snapTurnDegrees, 0f);

        // Mover en la dirección a la que mira la cabeza (plano XZ)
        Vector3 fwd = headOrCamera.forward; fwd.y = 0f; fwd.Normalize();
        move += fwd * forward;

        #endif

        // ===== Android (Cardboard): mantener tocado para avanzar =====
        #if UNITY_ANDROID && !UNITY_EDITOR
        bool isTouch = false;
        #if ENABLE_INPUT_SYSTEM
        if (Touchscreen.current != null)
            isTouch = Touchscreen.current.primaryTouch.press.isPressed;
        #else
        if (Input.touchCount > 0)
            isTouch = (Input.GetTouch(0).phase == TouchPhase.Began || 
                       Input.GetTouch(0).phase == TouchPhase.Moved || 
                       Input.GetTouch(0).phase == TouchPhase.Stationary);
        #endif

        if (isTouch)
        {
            Vector3 fwd = headOrCamera.forward; fwd.y = 0f; fwd.Normalize();
            move += fwd * 1f; // avanzar constante mientras se toca
        }
        #endif

        // Normaliza y aplica velocidad
        if (move.sqrMagnitude > 1e-4f) move = move.normalized * moveSpeed;

        // Gravedad simple
        if (controller.isGrounded && _yVel < 0f) _yVel = -1f;
        _yVel += gravity * Time.deltaTime;
        move.y = _yVel;

        controller.Move(move * Time.deltaTime);
    }
}
