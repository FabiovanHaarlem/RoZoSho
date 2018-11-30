using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Level2
{
    public class FinaleDoorButton : MonoBehaviour
    {
        [SerializeField]
        private DoorControle m_DoorControle;
        [SerializeField]
        private lvl2_Spawning m_Spawner;
        [SerializeField]
        private GameObject m_InteractTextParent;
        [SerializeField]
        private GameObject m_TipTextParentObject;
        [SerializeField]
        private Text m_TipText;
        [SerializeField]
        private Text m_InteractText;

        private bool m_Activated;

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "Trigger")
            {
                if (!m_Activated)
                {
                    m_InteractTextParent.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        m_DoorControle.OpenDoors();
                        m_Spawner.SpawnZombies(3);
                        m_Activated = true;
                        m_TipText.text = "A door opens behind you!";
                        m_TipTextParentObject.SetActive(true);
                        m_InteractTextParent.SetActive(false);
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Trigger")
            {
                if (m_Activated)
                {
                    m_TipTextParentObject.SetActive(false);
                }
            }
        }
    }
}
