using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Level2
{
    public class ElevatorButton : MonoBehaviour
    {
        [SerializeField]
        private Elevator m_Elevator;
        [SerializeField]
        private GameObject m_InteractTextParent;
        [SerializeField]
        private GameObject m_TipTextParentObject;
        [SerializeField]
        private Text m_TipText;
        [SerializeField]
        private Text m_InteractText;

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "Trigger")
            {
                m_InteractTextParent.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    m_Elevator.CallElevator();
                    m_TipText.text = "Hold of the zombies until the elevator arrives";
                    m_TipTextParentObject.SetActive(true);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Trigger")
            {
                m_InteractTextParent.SetActive(false);
            }
        }
    }
}
