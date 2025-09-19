using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public int vida = 100;
    public int municion = 30;
    public TMP_Text hudText;

    void Update()
    {
        if (hudText != null)
            hudText.text = $"Vida: {vida}\nMunición: {municion}";
    }

    // Métodos de ejemplo
    public void RecibirDaño(int dmg)
    {
        vida = Mathf.Max(0, vida - dmg);
    }
    public void Disparar()
    {
        if (municion > 0) municion--;
    }
}

