using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Level2
{
    public class UIController : MonoBehaviour
    {
        private GameObject m_InteractionTextObject;
        private GameObject m_VisualObject;
        private GameObject m_TextObject;

        private void Start()
        {
            GameObject canvas = GameObject.Find("Interaction");
            m_InteractionTextObject = canvas.transform.Find("InteractInfo").gameObject;
            m_VisualObject = m_InteractionTextObject.transform.Find("Visuals").gameObject;
            //m_TextObject = m_VisualObject.transform.Find("Text").gameObject;
            m_VisualObject.SetActive(false);
            //m_TextObject.SetActive(false);
        }

        public void EnableInteractionText()
        {
            m_VisualObject.SetActive(true);
            //m_TextObject.SetActive(true);
        }

        public void DisableInteractionText()
        {
            m_VisualObject.SetActive(false);
            //m_TextObject.SetActive(false);
        }
    }
}
