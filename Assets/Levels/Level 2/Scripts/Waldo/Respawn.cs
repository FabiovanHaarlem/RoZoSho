using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

namespace Level2
{
    

    public class Respawn : MonoBehaviour
    {
        [SerializeField]
        private IDamageableObject m_DamageableObject;
        public IDamageableObject DamageableObject
        {
            get { return m_DamageableObject; }
        }

        [SerializeField] private GameObject m_Ship;
        [SerializeField] private GameObject m_Elevator;
        [SerializeField] private GameObject m_Bridge;

        [SerializeField] private AudioSource m_AudioSource;

        [SerializeField] private List<GameObject> m_Objects;

        public int m_SpawnPoint;

        private Save m_Save = new Save();

        public List<float> m_PosX = new List<float>();
        public List<float> m_PosY = new List<float>();
        public List<float> m_PosZ = new List<float>();

        public bool m_Reload;

        /*
        private List<float> m_RotX = new List<float>();
        private List<float> m_RotY = new List<float>();
        private List<float> m_RotZ = new List<float>();
        private List<float> m_RotW = new List<float>();
        */
        Vector3 m_Pos;
        //Quaternion m_Rot;
        //Quaternion ;

        private void Start()
        {
            if (File.Exists(Application.persistentDataPath + "/SaveData.json"))
            {
                LoadData();
                if (m_Reload)
                    Load();
            }
        }
        private void Update()
        {
            /*
            if (Input.GetKeyDown(KeyCode.O))
                Load();

            if (Input.GetKeyDown(KeyCode.L))
                Save();

            if (Input.GetKeyDown(KeyCode.K))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                */
            if (m_DamageableObject.Health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
        public void Save()
        {
            m_PosX.Clear();
            m_PosY.Clear();
            m_PosZ.Clear();

            for (int i = 0; i < m_Objects.Count; i++)
            {

                m_PosX.Add(m_Objects[i].transform.position.x);
                m_PosY.Add(m_Objects[i].transform.position.y);
                m_PosZ.Add(m_Objects[i].transform.position.z);

                //m_RotX.Add(m_Objects[i].transform.rotation.x);
                //m_RotY.Add(m_Objects[i].transform.rotation.y);
                //m_RotZ.Add(m_Objects[i].transform.rotation.z);


            }
            m_Reload = true;

            SaveData();

            
        }
        public void Load()
        {


            LoadData();

            if (m_SpawnPoint == 1)
            {
                GameManager.m_Instance.GetEventHandler().CallShipCrashEvent();
                m_Ship.GetComponent<Ship>().m_Time = 2f;

            }
            if(m_SpawnPoint == 2)
            {
                GameManager.m_Instance.GetEventHandler().CallShipCrashEvent();
                GameManager.m_Instance.GetEventHandler().CallBridgeBreakingEvent();

                m_Bridge.GetComponent<BreakingBridge>().m_BreakTime = 0f;
                m_Bridge.GetComponent<BreakingBridge>().m_Breaking = true;
                m_Ship.GetComponent<Ship>().m_Time = 2f;
            }
            if(m_SpawnPoint == 3)
            {
                GameManager.m_Instance.GetEventHandler().CallShipCrashEvent();
                GameManager.m_Instance.GetEventHandler().CallBridgeBreakingEvent();
                GameManager.m_Instance.GetEventHandler().CallBrokenElevatorEvent();

                m_Bridge.GetComponent<BreakingBridge>().m_BreakTime = 0f;
                m_Bridge.GetComponent<BreakingBridge>().m_Breaking = true;
                m_Ship.GetComponent<Ship>().m_Time = 2f;
            }
            for (int i = 0; i < m_Objects.Count; i++)
            {
                m_Pos = new Vector3(m_PosX[i], m_PosY[i], m_PosZ[i]);
                m_Objects[i].transform.position = m_Pos;

                //m_Rot = new Quaternion(m_RotX[i], m_RotY[i], m_RotZ[i], m_RotW[i]);
                // m_Objects[i].transform.rotation = m_Rot;

            }
        }



        public void SaveData()
        { 
            m_Save.m_PosX = m_PosX;
            m_Save.m_PosY = m_PosY;
            m_Save.m_PosZ = m_PosZ;
            m_Save.m_SpawnPoint = m_SpawnPoint;
            m_Save.m_Reload = m_Reload;


            string json = JsonUtility.ToJson(m_Save);
            File.WriteAllText(Application.persistentDataPath + "/SaveData.json", json);

            Debug.Log("Saved");
            
        }
        public void LoadData()
        {

            string json = File.ReadAllText(Application.persistentDataPath + "/SaveData.json");
            m_Save = JsonUtility.FromJson<Save>(json);
            m_AudioSource.Play();
            m_PosX = m_Save.m_PosX;
            m_PosY = m_Save.m_PosY;
            m_PosZ = m_Save.m_PosZ;
            m_SpawnPoint = m_Save.m_SpawnPoint;
            m_Reload = m_Save.m_Reload;
        }



    }
     
}

