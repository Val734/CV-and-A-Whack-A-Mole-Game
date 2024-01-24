using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CopyButton : MonoBehaviour
{
    [SerializeField] TMP_Text destination;
    public void CopyText()
    {
        destination.text = GetComponentInChildren<TMP_Text>().text;

    }
}