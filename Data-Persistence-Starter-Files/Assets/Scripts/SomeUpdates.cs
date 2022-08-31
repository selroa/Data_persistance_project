using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SomeUpdates : MonoBehaviour
{
    public Text bestScore;

    // Start is called before the first frame update
    void Start()
    {
        bestScore.text = "Best Score : " + DataPersistance.Instance.bestPlayer + " : " + DataPersistance.Instance.highScore;
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
