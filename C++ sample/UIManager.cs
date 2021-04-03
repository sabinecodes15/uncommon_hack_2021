using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Image _LivesImg;

    [SerializeField]
    private Sprite[] _liveSprites;

    [SerializeField]
    private Text _gameOverText;

    [SerializeField]
    private Text _restartText;

    private GameManager _gameManager;

    void Start()
    {
        //_liveSprites[CurrentPlayerLives = 3];
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.Log("Game Manager = null");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite=_liveSprites[currentLives];
        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());

       

    }

    IEnumerator GameOverFlickerRoutine(){
        while (true)
        {
            _gameOverText.text="GAME OVER";
            yield return new WaitForSeconds(0.2f);
            _gameOverText.text = " AME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "  NE O ER";
            yield return new WaitForSeconds(0.1f);
            _gameOverText.text = "  NE O E ";
            yield return new WaitForSeconds(0.4f);
            _gameOverText.text = "  NE  O   ";
            yield return new WaitForSeconds(0.3f);
            _gameOverText.text = "  N   O   ";
            yield return new WaitForSeconds(1.0f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(2.0f);

        }
    }
}
