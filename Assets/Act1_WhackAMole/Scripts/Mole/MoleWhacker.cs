using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class MoleWhacker : MonoBehaviour
{
    private void OnEnable()//cualquier control que queramos que lea pues hay que habilitarlo! 
    {
        EnhancedTouchSupport.Enable();
    }
    private void OnDisable()//cualquier control que queramos que lea pues hay que habilitarlo! 
    {
        EnhancedTouchSupport.Disable();
    }
    void Update()
    {
        foreach (Touch t in Touch.activeTouches)
        {
            if(t.began)
            {
                DebugDrawTouch(
                    Camera.main.ScreenToWorldPoint(
                        (Vector3)t.screenPosition +
                        Vector3.forward * 10
                        )
                    );
                Ray ray = Camera.main.ScreenPointToRay(t.screenPosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("Mole"))
                    {
                        hit.collider.gameObject.GetComponent<MoleBehaviour>().MoleKilled();
                    }
                }

            }
        }

        if(Mouse.current.leftButton.isPressed)
        {
            DebugDrawTouch(
                Camera.main.ScreenToWorldPoint(
                    (Vector3)Mouse.current.position.value +
                    Vector3.forward * 10
                    )
                );

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Mole"))
                {
                    hit.collider.gameObject.GetComponent<MoleBehaviour>().MoleKilled();
                }
            }
        }
    }

    private void DebugDrawTouch(Vector3 touchWorldPosition)
    {
        Debug.Log("Just touched", this);
        //Debug.LogWarning("Just touched");
        //Debug.LogError("Just touched");
        //t.screenPosition
        //Debug.DrawLine//trabaja con posiciones del mundo
        Vector3 worldPosition = touchWorldPosition;

        Debug.DrawLine(worldPosition + Vector3.up, worldPosition + Vector3.down, Color.red, 10f);
        Debug.DrawLine(worldPosition + Vector3.right, worldPosition + Vector3.left, Color.red, 10f);
    }
}
