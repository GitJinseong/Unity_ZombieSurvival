using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager m_instance; // �̱����� �Ҵ�� static ����
    public static ResourceManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    //private string dataPath = default;
    private static string zombieDataPath = default;
    public ZombieData zombieData_default = default;

    private void Awake()
    {
        //dataPath = Application.dataPath;
        //ZombieData zombieData_ = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);

        //zombieDataPath = "Assets/01.Project/Scripables";
        zombieDataPath = "Scriptables";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Data Default");

        zombieData_default = Resources.Load<ZombieData>(zombieDataPath);
        //ZombieData zombieData_ = Resources.Load<ZombieData>(zombieDataPath);


        //Debug.LogFormat("Zombie data path: {0}", zombieDataPath);
        //Debug.LogFormat("Zombie data path: {0}, {1}, {2}", 
        //    zombieData_.health, zombieData_.damage, zombieData_.speed);

        Debug.LogFormat("���� Save data�� ���⿡�ٰ� �����ϴ� ���� ����̴�. -> {0}", Application.persistentDataPath);
    
        // AES-256 ��ȣ��� ��õ
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}