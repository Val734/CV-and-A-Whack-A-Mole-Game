using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoles : MonoBehaviour
{
    public int HasMole;

    public bool MoleChecker()
    {
        HasMole = transform.childCount;
        if (HasMole == 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void SpawnMole(GameObject prefabMole)
    {
        GameObject mole = Instantiate(prefabMole, transform.position, Quaternion.identity, transform);

    }
}
