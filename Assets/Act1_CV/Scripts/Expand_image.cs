using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class Expand_Image : MonoBehaviour
{
    public UnityEvent OnOpenImage; 
    public UnityEvent OnCloseImage; 


    private bool enlargedImage = false;

    private Vector2 originalSize;
    private Vector2 originalPosition;


    private RectTransform panelRectTransform;


    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
    private void Start()
    {
        originalSize = GetComponent<RectTransform>().sizeDelta;
        originalPosition = GetComponent<RectTransform>().position;


        // Obtiene la referencia al RectTransform del panel
        panelRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    private void Update()
    {
        //esto para el movil!!!!!
        foreach (Touch t in Touch.activeTouches)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            Vector2 touchPosition = t.screenPosition;

            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touchPosition))
            {
                if (t.phase == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    if (enlargedImage)
                    {
                        NormalImage();
                        OnCloseImage?.Invoke();
                    }
                    else
                    {
                        ExpandImage();
                        OnOpenImage?.Invoke();
                    }
                }
            }
        }
        //esto para el ordena!!!
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            if (RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), mousePosition))
            {
                if (enlargedImage)
                {
                    NormalImage();
                    OnCloseImage?.Invoke();
                }
                else
                {
                    ExpandImage();
                    OnOpenImage?.Invoke();
                }
            }
        }

    }

    private void ExpandImage()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        GetComponent<RectTransform>().position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        enlargedImage = true;
    }

    private void NormalImage()
    {
        GetComponent<RectTransform>().sizeDelta = originalSize;
        GetComponent<RectTransform>().position = originalPosition;

        enlargedImage = false;
    }
}
