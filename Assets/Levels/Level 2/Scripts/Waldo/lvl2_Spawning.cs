using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level2;
using UnityEngine.AI;

namespace Level2
{
    public class lvl2_Spawning : MonoBehaviour
    {
        [SerializeField]
        private IDamageableObject m_DamageableObject;
        public IDamageableObject DamageableObject
        {
            get { return m_DamageableObject; }
        }

        [SerializeField]
        private List<SpawningObject> m_SpawningObject;

        private lvl2_Pooling m_Zombies;

        [SerializeField]
        private GameObject m_PoolManager;

        [SerializeField]
        private Transform m_Player;
        private EnemyWeaponPickupBehaviour m_Patrol;
        private BasicChaseTargetState m_Chase;

        private GameObject m_Behaviour;

        private NavMeshAgent m_Agent;

        private int m_SpawnIndex;

        private float m_NavTimer = 15f;
        

        [SerializeField]
        private bool m_CallOnce = true;

        void Start()
        {
            m_Zombies = m_PoolManager.GetComponent<lvl2_Pooling>();
            m_Agent = new NavMeshAgent();


        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {

                SpawnZombies(0);
            }
            

            for (int z = 0; z < m_Zombies.Zombie.Count; z++)
            {
                if (m_Zombies.Zombie[z].activeInHierarchy)
                {
                    if (m_SpawnIndex == 0 || m_SpawnIndex == 3)
                    {
                        m_Behaviour = m_Zombies.Zombie[z].transform.GetChild(0).gameObject;
                        float Distance = Vector3.Distance(m_Player.transform.position, m_Zombies.Zombie[z].transform.GetChild(0).position);
                        m_Patrol = m_Behaviour.GetComponent<EnemyWeaponPickupBehaviour>();
                        if (m_Patrol.enabled && Distance > 3)
                        {
                            //m_Patrol.NavMeshAgent.destination = m_Player.transform.position;
                            // m_Patrol.NavMeshAgent.speed = 3.5f;

                            m_Behaviour = m_Zombies.Zombie[z].transform.GetChild(0).gameObject;
                            m_Chase = m_Behaviour.GetComponent<BasicChaseTargetState>();
                            m_Chase.SetTarget(m_Player.GetComponent<IDamageableObject>());
                            m_Chase.Enter();
                        }
                    }
                    if(m_SpawnIndex == 2)
                    {
                        m_NavTimer -= Time.deltaTime;
                        Debug.Log(m_NavTimer);
                        m_Behaviour = m_Zombies.Zombie[z].transform.gameObject;

                        if (m_NavTimer > 0f && m_Behaviour.GetComponent<BoxCollider>() == false || m_CallOnce == true)
                        {
                            m_Behaviour.AddComponent<Rigidbody>().freezeRotation = true;
                            m_Behaviour.AddComponent<BoxCollider>().size = new Vector3(1,0.1f,1);
                            m_Behaviour.GetComponent<NavMeshAgent>().enabled = false;
                            m_CallOnce = false;
                        }
                        if (m_NavTimer < 0f)
                        {
                            m_Behaviour.GetComponent<NavMeshAgent>().enabled = true;
                            Destroy(m_Behaviour.GetComponent<Rigidbody>());
                            m_Behaviour.GetComponent<BoxCollider>().enabled = false;

                        }
                    }
                    
                }
            }

        }

        public void DespawnZombie()
        {
            for (int z = 0; z < m_Zombies.Zombie.Count; z++)
            {
                if (m_Zombies.Zombie[z].activeInHierarchy)
                {
                    m_Zombies.Zombie[z].SetActive(false);


                }
            }

        }
        

        public void SpawnZombies(int NumList)
        {
            int numList = NumList;
            for (int s = 0; s < m_SpawningObject[numList].SpawnObject.Count; s++)
            {
                for (int z = 0; z < m_Zombies.Zombie.Count; z++)
                {
                    if (!m_Zombies.Zombie[z].activeInHierarchy)
                    {
                        m_Zombies.Zombie[z].transform.position = m_SpawningObject[numList].SpawnObject[s].transform.position;
                        m_Zombies.Zombie[z].SetActive(true);
                        m_Zombies.Zombie[z].GetComponent<RegularDamageBehaviour>().ChangeHealth(100);

                        m_SpawnIndex = NumList;

                        break;

                    }
                }

            }

        }
    }
}
