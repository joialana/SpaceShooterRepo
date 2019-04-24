using System.Collections;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
   void OnTriggerExit(Collider Other)
    {
        Destroy(Other.gameObject);
    }

}
