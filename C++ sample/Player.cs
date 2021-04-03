using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed=3.0f;

    private float _speedup = 2.0f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

   

    [SerializeField]
    private float _fireRate = 3.5f;
    private float _canFireRate = -1f;

    [SerializeField]
    private int _lives = 3;

    private Spawn_Manager _spawnManager;


    private bool _isTriple = false;
    private bool _isSpeedup = false;
    private bool _isShieldsActive = false;

    [SerializeField]
    private GameObject _shieldVisualizer;

    [SerializeField]
    private GameObject _RightEngineVisualizer, _LeftEngineVisualizer;

   

    [SerializeField]
    private int _score;

    private UIManager _uiManager;

    public float triplePlace;

    [SerializeField]
    private AudioClip _laserSoundClip;
    [SerializeField]
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {

        _shieldVisualizer.SetActive(false);

        //take the current possition = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
        if (_spawnManager == null)
        {
            Debug.LogError("Spawn_Manager is null");
        }

        if (_uiManager == null)
        {
            Debug.LogError("uiManager is null");
        }

        if (_audioSource == null)
        {
            Debug.LogError("Audio Source on this player is null");
        }
        else
        {
            _audioSource.clip = _laserSoundClip;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_lives);
        CalculateMovement();
        if ((Input.GetKeyDown(KeyCode.Space)|| CrossPlatformInputManager.GetButtonDown("Fire") )&& Time.time > _canFireRate)
        {
            FireLaser();
        }
        
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //CrossPlatformInputManager.GetAxis("Horizontal");// 
        float verticalInput = Input.GetAxis("Vertical");
        //CrossPlatformInputManager.GetAxis("Vertical"); //Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * (_speed * 2.0f) * Time.deltaTime);
        
        //Bound
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.0f, 8f), Mathf.Clamp(transform.position.y, -5f, 5f), 0);
        
    }

    void FireLaser()
    {
        _canFireRate = Time.time + _fireRate;
        
        if (_isTriple == true)
        {
           
            Instantiate(_tripleShotPrefab, new Vector3(transform.position.x+triplePlace,transform.position.y,transform.position.z), Quaternion.identity);
           // Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
           Instantiate(_laserPrefab, transform.position + new Vector3(0f, 1.05f, 0f), Quaternion.identity);
        }
        _audioSource.Play();
    }

    public void Damage()
    {
        if (_isShieldsActive == true)
        {
            _isShieldsActive = false;
            _shieldVisualizer.SetActive(false);
            return;
        }
        _lives -= 1;
        if (_lives == 2)
        {
            _RightEngineVisualizer.SetActive(true);
        }else if (_lives==1)
        {
            _LeftEngineVisualizer.SetActive(true);
        }

        _uiManager.UpdateLives(_lives);
        if (_lives <1)
        {
           
            Destroy(this.gameObject);
            _spawnManager.OnPlayerDeath();
        }

    }

    public void TripleShotActive() {
       
        _isTriple = true;
        
        StartCoroutine("TripleShotPowerDownRoutine");
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTriple = false;
       
    }

    public void SpeedupActive()
    {
        _isSpeedup = true;
        _speed *= _speedup;
        StartCoroutine("SpeedDownRoutine");
    }

    IEnumerator SpeedDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedup = false;
        _speed /= _speedup;
    }

    public void ShieldsActive()
    {
        _isShieldsActive = true;
        _shieldVisualizer.SetActive(true);
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}
