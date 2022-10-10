using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button addButton, showButton;
    [SerializeField] InputField newWordInputField, meanWordInputField;
    [SerializeField] Text newWordText, meanWordText, newWordListText, meanWordListText;

    List<string> newWordList = new List<string>();
    List<string> meanWordList = new List<string>();

    string inputNewWord, inputMeanWord;

    // Start is called before the first frame update
    void Start()
    {  
        LoadWords();
        ShowList();
    }
    // Update is called once per frame
    void Update()
    { 
    }
    public void ShowList()
    {
        newWordListText.text = "";
        meanWordListText.text = "";

        foreach (string newword in newWordList)
        {
            newWordListText.text += $"\n{newword}";
        }
        foreach (string meanword in meanWordList)
        {
            meanWordListText.text += $"\n{meanword}";
        }    
    }
    public void AddNewWordField()
    {
        inputNewWord = newWordInputField.text;
    }
    public void AddNewMeanField()
    {
        inputMeanWord = meanWordInputField.text;
    }
    public void AddingNewWordButton()
    {
        AddingNewWord();
    }
    public void ShowListButton()
    {
        ShowList();
    }
    public void AddingNewWord()
    {
        if(newWordInputField.text != "" && meanWordInputField.text != "")
        {
            ShowNewwordText();
            AddListNewWord();
        }
        else
        {
            BlankWarning();
        }
        
        ClearInputField();
        SaveWords();
    }
    public void AddListNewWord()
    {
        newWordList.Add(inputNewWord);
        meanWordList.Add(inputMeanWord);

    }
    public void ShowNewwordText()
    {
        newWordText.text = inputNewWord;
        meanWordText.text = inputMeanWord;
    }
    public void ClearInputField()
    {
        newWordInputField.text = "";
        meanWordInputField.text = "";
    }
    public void BlankWarning()
    {
        newWordText.text = "Please enter new word...";
        meanWordText.text = "Please enter mean...";
    }
    //data save sytem Json format
    [System.Serializable]
    class SaveData
    {
        public List<string> newWordDataList;
        public List<string> meanWordDataList;
    }
    public void SaveWords()
    {
        SaveData data = new SaveData();
        data.newWordDataList = newWordList;
        data.meanWordDataList = meanWordList;

        string jsone = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsone);
    }
    public void LoadWords()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            newWordList = data.newWordDataList;
            meanWordList = data.meanWordDataList;
        }
    }
}
