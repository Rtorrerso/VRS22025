# VRS22025 – Proyecto de Realidad Virtual y Aumentada con Unity

Bienvenido al repositorio **VRS22025**, un proyecto académico y experimental que explora el uso de **realidad virtual (VR)** y **realidad aumentada (AR)** dentro del entorno de **Unity 6.0.1**, utilizando tecnologías como **XR Toolkit**, **AR Foundation**, **Google ARCore**, **retículas interactivas**, **hotspots navegables** y entornos esféricos inmersivos.

Este repositorio ha sido creado como recurso educativo para estudiantes y entusiastas del desarrollo de experiencias inmersivas, es de libre uso desarrollado en la Materia de REALIDAD VIRTUAL Y AUMENTADA para el Instituto Superior Tecnológico Espiritu Santo de la Ciudad de Guayaquil Ecuador a los estudiantes de la carrera de Tecnología Superior Universitaria en Aplicaciones Web

---

## 🎯 Objetivo del Proyecto

Desarrollar un sistema interactivo de navegación entre escenarios esféricos (tipo "360°") a través de:
- Interacciones visuales mediante retícula (sin controladores).
- Hotspots que responden a la mirada del usuario (detección por tiempo de enfoque).
- Navegación suave entre entornos, con transiciones visuales (fade in/out) y mensajes contextuales. (en siguientes branches)
- Soporte para dispositivos moviles, se generan varios branches para actualizar las opciones


---

## 🧰 Tecnologías y Componentes Usados

- Unity 6.0.1 (Built-in Render Pipeline)
- Retícula de interacción basada en `Raycast`
- Control de cámara por giroscopio o teclado
- Transiciones entre escenas con `Lerp` y `Coroutine`  (branch easing)
- UI dinámica con paneles, textos e indicadores visuales (branch paneles)
- Compatibilidad con dispositivos Android vía ADB y `scrcpy` 

---

## 📁 Estructura del Proyecto
Assets/
├── Scripts/
│ ├── ReticleController.cs
│ ├── HotspotTrigger.cs
│ ├── CameraGyroControl.cs
│ ├── SceneTransitionManager.cs
│ └── FadeCanvasController.cs
├── Prefabs/
│ ├── Hotspot.prefab
│ ├── Reticle.prefab
│ └── PanelUI.prefab
├── Textures/
│ └── Esferas_360/
├── Scenes/
│ ├── Intro.unity
│ ├── EscenaPatio.unity
│ └── EscenaLaboratorio.unity


---

## 🚀 Cómo ejecutar el proyecto

1. Clona el repositorio:
   ```bash
   git clone https://github.com/Rtorrerso/VRS22025.git
Abre el proyecto en Unity 6.0.1 (u otra versión compatible con XR Toolkit y AR Foundation).

2. Asegúrate de tener activado:

Soporte para Android (si deseas compilar en APK)

Ejecuta la escena Intro.unity o EscenaPrincipal.unity.
