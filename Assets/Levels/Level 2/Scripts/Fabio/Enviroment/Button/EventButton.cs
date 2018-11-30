using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace Level2
{
    public class EventButton : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent m_Interaction;
        private AudioSource m_Press;

        private void Start()
        {
            m_Press = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger")
            {
                GameManager.m_Instance.GetUIController().EnableInteractionText();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "Trigger")
            {
                GameManager.m_Instance.GetUIController().EnableInteractionText();
                if (Input.GetKeyDown(KeyCode.F))
                {
                    m_Press.Play();
                    m_Interaction.Invoke();
                    GameManager.m_Instance.GetUIController().DisableInteractionText();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Trigger")
            {
                GameManager.m_Instance.GetUIController().DisableInteractionText();
            }
        }
    }
}
