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
    //private static string zombieDataPath = default;
    //public ZombieData zombieData_default = default;
    //public ZombieData ZombieData_Fast = default;
    //public ZombieData ZombieData_Heavy = default;
    public ZombieData[] csvZombieDatas = default;


    private void Awake()
    {
        //dataPath = Application.dataPath;
        //ZombieData zombieData_ = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);

        //zombieDataPath = "Assets/01.Project/Scripables";
        //zombieDataPath = "Scriptables";
        //zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Data Default");

        //zombieData_default = Resources.Load<ZombieData>(zombieDataPath);
        //zombieDataPath = new ZombieData();
        //Debug.Log(CSVReader.instance.dataDictionary["ZOMBIE_TYPE"]);
        //ZombieData zombieData_ = Resources.Load<ZombieData>(zombieDataPath);


        //Debug.LogFormat("Zombie data path: {0}", zombieDataPath);
        //Debug.LogFormat("Zombie data path: {0}, {1}, {2}", 
        //    zombieData_.health, zombieData_.damage, zombieData_.speed);

        Debug.LogFormat("���� Save data�� ���⿡�ٰ� �����ϴ� ���� ����̴�. -> {0}", Application.persistentDataPath);

        // AES-256 ��ȣ��� ��õ

        // csv ������ �ҷ��ͼ� ��ȯ�Ѵ�.
        CSVReader.instance.ReadCSVFile("Assets/Resources/ZombieDatas", "ZombieSurvivalDatas.csv");

        // csv ������ �޾Ƽ� ZombieData Ŭ������ ��ü�� ����
        int size = CSVReader.instance.dataDictionary["ZOMBIE_TYPE"].Count;
        csvZombieDatas = new ZombieData[size];
        for (int i = 0; i < size; i++)
        {
            float health = float.Parse(CSVReader.instance.dataDictionary["HEALTH"][i]);
            float damage = float.Parse(CSVReader.instance.dataDictionary["DAMAGE"][i]);
            float speed = float.Parse(CSVReader.instance.dataDictionary["SPEED"][i]);
            Color skinColor = default;
            ColorUtility.TryParseHtmlString(CSVReader.instance.dataDictionary["SKIN_COLOR"][i], out skinColor);
            csvZombieDatas[i] = new ZombieData(health, damage, speed, skinColor);
        }
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
