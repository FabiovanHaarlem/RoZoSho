using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Level2
{
    public class Checkpoint : MonoBehaviour
    {
        private UnityEvent m_Checkpoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger")
            {
                m_Checkpoint.Invoke();
            }
        }
    }
}
