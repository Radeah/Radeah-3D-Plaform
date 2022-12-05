using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public int Respawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   void OnTriggerEnter(Collider other)
 {
     if (other.CompareTag("Player"))
     {
        SceneManager.LoadScene(Respawn);
     }
 }

}
