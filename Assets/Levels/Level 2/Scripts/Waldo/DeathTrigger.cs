using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level2
{

    public class DeathTrigger : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


    }
}

