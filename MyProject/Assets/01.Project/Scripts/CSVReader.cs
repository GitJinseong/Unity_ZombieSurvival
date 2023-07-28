using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    #region �̱��� ����
    private static CSVReader m_instance; // �̱����� �Ҵ�� static ����
    public static CSVReader instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ CSVReader ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<CSVReader>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }
    #endregion

    public const char DELIMITER = ','; // CSV ���Ͽ��� ����ϴ� ������ (�⺻���� �޸�)

    // csv ������ ������ ��� ���� �����Ͽ� ������ ��ųʸ�
    // ���� Ű ���� �ǰ�, ���� Ű �� ������ ���� �ȴ�.
    public Dictionary<string, List<string>> dataDictionary = default;

    // CSV ������ �д� �Լ�
    // dirPath���� "Assets/Resources/ZombieDatas"�� ���� ���丮 ��θ� �Է��Ѵ�.
    // csvFileName���� "ZombieSurvivalDatas.csv"�� ���� csv ������ �̸��� �Է��Ѵ�.
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

        // csv ���Ͽ� ������ ���� ��� ���� �޽��� ���
        catch (IOException e)
        {
            Debug.LogError("Error reading the CSV file: " + e.Message);
        }
    }

    // ��ȯ�� csv ������ ������ ����� ��ųʸ� ������ ���� ����ϴ� �Լ�.
    // "��:��1,��2,��3"�� ���� ��µȴ�.
    private void PrintData()
    {
        // ��ųʸ��� �� �׸��� ���
        foreach (KeyValuePair<string, List<string>> entry in dataDictionary)
        {
            string category = entry.Key;
            List<string> values = entry.Value;

            Debug.Log(category + ": " + string.Join(", ", values));
        }
    }

}