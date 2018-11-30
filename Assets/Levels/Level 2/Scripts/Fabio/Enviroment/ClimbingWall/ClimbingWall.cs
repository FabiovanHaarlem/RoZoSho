using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class ClimbingWall : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider m_ClimbFloor;

        private Vector3 m_StartingPosition;

        private AudioSource m_ClimbingSound;

        private float m_ClimbSpeed;

        private bool m_Climbing;

        private void Start()
        {
            m_ClimbSpeed = 2f;
            m_StartingPosition = m_ClimbFloor.gameObject.transform.position;
            m_ClimbFloor.gameObject.SetActive(false);
            m_ClimbingSound = GetComponent<AudioSource>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "Trigger")
            {
                m_ClimbFloor.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.W))
                {
                    if (!m_ClimbingSound.isPlaying)
                    {
                        m_ClimbingSound.Play();
                    }

                    m_ClimbFloor.gameObject.transform.Translate(new Vector3(0f, m_ClimbSpeed * Time.deltaTime, 0f));
                }
                
                if (Input.GetKeyUp(KeyCode.W))
                {
                    m_ClimbingSound.Stop();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Trigger")
            {
                m_ClimbFloor.gameObject.SetActive(false);
                m_ClimbFloor.gameObject.transform.position = m_StartingPosition;
                m_ClimbingSound.Stop();
            }
        }
    }
}
