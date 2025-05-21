using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractuable
{
   bool on = false;

   [SerializeField] List<GameObject> lightGOs;
   public void Interact()
   {
        on = !on;

        foreach (GameObject go in lightGOs)

            go.SetActive(on);
   }
}
