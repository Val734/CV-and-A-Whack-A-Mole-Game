using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;
using Touch= UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine.SceneManagement;

public class ForCornersScreenSwap : MonoBehaviour
{
    [Header("logic")]
    [SerializeField] string sceneToLoad;

    [Header("Debug")]
    [SerializeField] bool debugSwapScene;

    float timePressingAllFourCorners;
    private void OnValidate()//para comprobar que funciona 
    {
        if (debugSwapScene)
        {
            debugSwapScene = false;
            Debug.Log("HOLAAAAAAAAAAAAAAAAAAAAAAAAAA");
            LoadNextScene();
        }
    }
    private void OnEnable()//cualquier control que queramos que lea pues hay que habilitarlo! 
    {
        EnhancedTouchSupport.Enable(); 
    }
    private void OnDisable()//cualquier control que queramos que lea pues hay que habilitarlo! 
    {
        EnhancedTouchSupport.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //aquí es lo mismo pero es para cuando queremos saber el índice, o tenemos condiciones de salida temprana
        /*for (int i = 0; i < Touch.activeTouches.Count; i++)
        {
            Touch t= Touch.activeTouches[i];
            Debug.Log(t.screenPosition)
        }*/
        //es como el for y recorrres todo lo dentro del array, lista el contenedor, active touches 

        //queremos leer los touches y cuantos de ellos estan en las esquinas sup izq= 

        int touchesInAnyCorner = 0;
        int touchesInTopLeftCorner = 0;
        int touchesInTopRightCorner = 0;
        int touchesInBottomRightCorner = 0;
        int touchesInBottomLeftCorner = 0;


        foreach (Touch t in Touch.activeTouches)
        {
           
            Debug.Log(t.screenPosition);
            Vector2 position = t.screenPosition;
            Vector2 normalizedPosition = position;
            normalizedPosition.x /= Screen.width; 
            normalizedPosition.y /= Screen.height;//valores que dentro de los rangos estan entre 0 y 1 el porcentaje es respecto a 1, entonces va bien porque así nos da igual el tamaño de la pantalla!!!!

            CheckTopLeftCorner(ref touchesInAnyCorner, ref touchesInTopLeftCorner, normalizedPosition);
            CheckTopRightCorner(ref touchesInAnyCorner, ref touchesInTopRightCorner, normalizedPosition);
            CheckBottomLeftCorner(ref touchesInAnyCorner, ref touchesInBottomLeftCorner, normalizedPosition);
            CheckBottomRightCorner(ref touchesInAnyCorner, ref touchesInBottomRightCorner, normalizedPosition);

        }

        CheckLoadNextScene(touchesInTopLeftCorner, touchesInTopRightCorner, touchesInBottomRightCorner, touchesInBottomLeftCorner);
        //el onvalidate se llama cada vez que cambias el valor
    }

    private static void CheckBottomRightCorner(ref int touchesInAnyCorner, ref int touchesInBottomRightCorner, Vector2 position)
    {
        if (((position.x > 0.8)) && ((position.y < 0.2f)))
        {
            touchesInAnyCorner++;
            touchesInBottomRightCorner++;
        }
    }

    private static void CheckBottomLeftCorner(ref int touchesInAnyCorner, ref int touchesInBottomLeftCorner, Vector2 position)
    {
        if (((position.x < 0.2)) && ((position.y < 0.2f)))
        {
            touchesInAnyCorner++;
            touchesInBottomLeftCorner++;
        }
    }

    private static void CheckTopRightCorner(ref int touchesInAnyCorner, ref int touchesInTopRightCorner, Vector2 position)
    {
        if (((position.x > 0.8f)) && ((position.y > 0.8f)))
        {
            touchesInAnyCorner++;
            touchesInTopRightCorner++;
        }
    }

    private static void CheckTopLeftCorner(ref int touchesInAnyCorner, ref int touchesInTopLeftCorner, Vector2 position)
    {
        if ((/*(position.x > 0f) && */ (position.x < 0.2f)) && ((position.y > 0.8f)/* && (position.y < 1f)*/))
        {
            touchesInAnyCorner++;
            touchesInTopLeftCorner++;
        }
    }

    private void CheckLoadNextScene(int touchesInTopLeftCorner, int touchesInTopRightCorner, int touchesInBottomRightCorner, int touchesInBottomLeftCorner)
    {
        if ((touchesInTopLeftCorner >= 1) && (touchesInTopRightCorner >= 1) && (touchesInBottomRightCorner >= 1) && (touchesInBottomLeftCorner >= 1))
        {
            timePressingAllFourCorners += Time.deltaTime; 
            if(timePressingAllFourCorners>3f)
            {
                LoadNextScene();
            }
           
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    //cntrl r+m--> refactorizar suuuuuuuuuuuuuuu
}