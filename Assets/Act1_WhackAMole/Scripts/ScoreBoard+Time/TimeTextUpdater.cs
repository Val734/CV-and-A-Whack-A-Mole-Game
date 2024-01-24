using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTextUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetTimeText(int time)
    {
        GetComponent<TMP_Text>().text = "Time: " + time.ToString();
    }
}
