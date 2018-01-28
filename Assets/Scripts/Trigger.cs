using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject[] _activateGameObjects;
    public GameObject[] _deactivateGameObjects;


    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _activateGameObjects.Length; ++i)
        {
            _activateGameObjects[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < _deactivateGameObjects.Length; ++i)
        {
            _deactivateGameObjects[i].gameObject.SetActive(false);
        }
    }
}
