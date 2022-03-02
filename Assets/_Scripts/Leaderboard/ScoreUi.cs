using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUi : GameElement
{
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private Button _save;
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _header;

    private int _result;
    
    public RowUi rowUi;
    public ScoreManager scoreManager;

    private void Start()
    {
        ShowResult();
        FillTable();
    }

    private void FillTable()
    {
        Instantiate(_header, _content);
            
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, _content).GetComponent<RowUi>();
            row._name.text = scores[i].name;
            row._score.text = scores[i].score.ToString();
        }
    }

    private void ClearTable()
    {
        var row = new List<GameObject>();
        
        foreach (Transform child in _content) 
            row.Add(child.gameObject);
        
        row.ForEach(child => Destroy(child));
    }
    
    private void ShowResult()
    {
        _result = Game.Controller.StepCounter.CurrentStep;
        _resultText.text = "Your result " + _result;
    }
    
    public void SaveResult()
    {
        string name = _name.text;

        if (name != "")
        {
            scoreManager.AddScore(new Score(name, _result));
            scoreManager.SaveScore();
            _save.gameObject.SetActive(false);
            ClearTable();
            FillTable();
        }
            
    }
}
