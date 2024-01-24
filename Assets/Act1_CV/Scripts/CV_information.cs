using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class CV_information : MonoBehaviour
{
    [SerializeField] private RectTransform panelRectTransform;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {
        //para el movil
        foreach (Touch t in Touch.activeTouches)
        {
            // Para obtener la posición del toque en coordenadas de pantalla
            Vector2 touchPosition = t.screenPosition;

            // Verifica si la posición del toque está dentro del panel
            if (RectTransformUtility.RectangleContainsScreenPoint(panelRectTransform, touchPosition))
            {
                Debug.Log("Has tocado el panel");
                OpenMailTo("valeriarodriguezgracia42@gmail.com", "Quiero Contratarte", "Tu formato de CV ha gustado bastante!!!!!");
            }
        }
        //lo mismo pero para ordenador
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            if (RectTransformUtility.RectangleContainsScreenPoint(panelRectTransform, mousePosition))
            {
                Debug.Log("Has hecho clic en el panel");
                OpenMailTo("valeriarodriguezgracia42@gmail.com", "Quiero Contratarte", "Tu formato de CV ha gustado bastante!!!!!");
            }
        }
    }

    void OpenMailTo(string email, string subject, string body)
    {
        string uri = "mailto:" + email + "?subject=" + subject + "&body=" + body;
        Application.OpenURL(uri);
    }
}
