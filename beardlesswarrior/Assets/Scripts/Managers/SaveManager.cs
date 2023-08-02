using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
    const string SETTINGS_FILE_NAME = "Settings";
    [field: SerializeField] public Settings m_settings { get; private set; } = new();
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
        base.Awake();
        SaveSystem.Init();

        LoadSettings();
    }

    public void SaveSettings()
    {
        StartCoroutine(SaveSystem.Save(JsonUtility.ToJson(m_settings), SETTINGS_FILE_NAME));
    }

    public void LoadSettings()
    {
        string load = SaveSystem.Load(SETTINGS_FILE_NAME);
        if (load != null)
        {
            m_settings = JsonUtility.FromJson<Settings>(load);
        }
        SaveSettings();
    }
}

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Save/";
    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static IEnumerator Save(string saveString, string fileName)
    {
        if (!File.Exists(SAVE_FOLDER + $"{fileName}.txt"))
        {
            CreateFile(fileName);
        }
        yield return 0;
        File.WriteAllText(SAVE_FOLDER + $"{fileName}.txt", saveString);

    }

    static void CreateFile(string fileName)
    {
        File.Create(SAVE_FOLDER + $"{fileName}.txt");
    }

    public static string Load(string fileName)
    {
        if (!File.Exists(SAVE_FOLDER + $"{fileName}.txt")) return null;

        return File.ReadAllText(SAVE_FOLDER + $"{fileName}.txt");        
    }
}

[System.Serializable]
public class Settings
{
    public bool m_sound = true;
    public bool m_tutorialDone = false;
}
