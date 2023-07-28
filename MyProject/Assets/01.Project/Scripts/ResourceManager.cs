using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager m_instance; // 싱글톤이 할당될 static 변수
    public static ResourceManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // 싱글톤 오브젝트를 반환
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

        Debug.LogFormat("게임 Save data를 여기에다가 저장하는 것이 상식이다. -> {0}", Application.persistentDataPath);

        // AES-256 암호방식 추천

        // csv 파일을 불러와서 변환한다.
        CSVReader.instance.ReadCSVFile("Assets/Resources/ZombieDatas", "ZombieSurvivalDatas.csv");

        // csv 파일을 받아서 ZombieData 클래스의 객체를 생성
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
