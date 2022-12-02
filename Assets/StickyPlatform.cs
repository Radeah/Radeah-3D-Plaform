using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Player")
      {
          collision.transform.parent = transform;
      }

   }

   private void OnCollisionExist(Collision collision)
   {
  
     if (collision.gameObject.tag == "Player")
     {
        collision.transform.parent = null;
   } }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
