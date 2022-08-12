using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIHandler : MonoBehaviour
{
    public IntVariableEvent PlayerHealth;
    public IntVariableEvent PlayerScore;
    public List<GameObject> HealthImgs = new List<GameObject>();
    public TMP_Text statsTxt;
    private void OnEnable()
    {
        PlayerHealth.ResetSO();
        PlayerScore.ResetSO();

        PlayerHealth.OnValueChanged += UpdateHealthUI;
        PlayerScore.OnValueChanged += UpdateScoreUI;
    }

    private void UpdateHealthUI(int value)
    {
        Destroy(HealthImgs[value]);
        HealthImgs.RemoveAt(value);
    }

    private void UpdateScoreUI(int value)
    {
        statsTxt.text = value.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDisable()
    {
        PlayerHealth.OnValueChanged -= UpdateHealthUI;
        PlayerScore.OnValueChanged += UpdateScoreUI;
    }
}