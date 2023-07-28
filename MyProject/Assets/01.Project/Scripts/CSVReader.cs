using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    #region 싱글톤 선언
    private static CSVReader m_instance; // 싱글톤이 할당될 static 변수
    public static CSVReader instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 CSVReader 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<CSVReader>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }
    #endregion

    public const char DELIMITER = ','; // CSV 파일에서 사용하는 구분자 (기본값은 콤마)

    // csv 파일의 정보를 행과 열로 구분하여 저장할 딕셔너리
    // 행은 키 값이 되고, 열은 키 값 내부의 값이 된다.
    public Dictionary<string, List<string>> dataDictionary = default;

    // CSV 파일을 읽는 함수
    // dirPath에는 "Assets/Resources/ZombieDatas"과 같이 디렉토리 경로를 입력한다.
    // csvFileName에는 "ZombieSurvivalDatas.csv"과 같이 csv 파일의 이름을 입력한다.
    public void ReadCSVFile(string dirPath, string csvFileName)
    {
        dataDictionary = new Dictionary<string, List<string>>();
        string filePath = Path.Combine(dirPath, csvFileName);
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] headers = reader.ReadLine().Split(DELIMITER);

                foreach (string header in headers)
                {
                    dataDictionary.Add(header, new List<string>());
                }

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(DELIMITER);

                    for (int i = 0; i < values.Length; i++)
                    {
                        dataDictionary[headers[i]].Add(values[i]);
                    }
                }
            }
        }

        // csv 파일에 문제가 있을 경우 오류 메시지 출력
        catch (IOException e)
        {
            Debug.LogError("Error reading the CSV file: " + e.Message);
        }
    }

    // 변환된 csv 파일의 정보가 저장된 딕셔너리 내부의 값을 출력하는 함수.
    // "행:열1,열2,열3"과 같이 출력된다.
    private void PrintData()
    {
        // 딕셔너리의 각 항목을 출력
        foreach (KeyValuePair<string, List<string>> entry in dataDictionary)
        {
            string category = entry.Key;
            List<string> values = entry.Value;

            Debug.Log(category + ": " + string.Join(", ", values));
        }
    }

}