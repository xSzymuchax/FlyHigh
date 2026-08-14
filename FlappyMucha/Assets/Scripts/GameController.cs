using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    enum GameMode
    {
        Classic, TimeAttack, Crazy, CrazyTimeAttack
    }

    // player characters
    private GameObject ChoosenCharacter;
    public GameObject FlyCharacter;
    public GameObject BeeCharacter;
    public GameObject MosquitoCharacter;
    public GameObject RockCharacter;
    public GameObject FlarCharacter;
    public GameObject GirlCharacter;

    //backgrounds container
    public GameObject Backgrounds;

    // game variables
    public Transform flySpawn;
    public SpawnerController spawner;
    public GameObject obstaclesContainer;

    public float GameSpeed = 0.02f;
    public float StartGameSpeed = 0.02f;

    public int points=0;
    public int highscoreClassic=0;
    public int highscoreTimeAttack=0;
    public int highscoreCrazy=0;
    public int highscoreCrazyTimeAttack=0;

    public float timeAttackBaseTime = 20f;
    public float timeAttackLeftTime = 20f;

    private GameMode currentMode;

    // canvas
    public GameObject endGameMenu;
    public TextMeshProUGUI pointsCounter;
    public TextMeshProUGUI timeCounter;
    public TextMeshProUGUI finalPointsOutput;
    public TextMeshProUGUI recordPointsOutput;

    //sounds
    public AudioClip selectSound;
    private AudioSource audioSource;

    // backgroound variables
    public bool gameActive = true;
    public bool backgroundActive = true;

    private GameObject currentFly;

    public static GameController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        ChoosenCharacter = FlyCharacter;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        audioSource = GetComponent<AudioSource>();
    }

    public Vector3 FlyPosition()
    {
        if (currentFly != null)
            return currentFly.transform.position;

        return new Vector3(0, 0, 0);
    }

    public void PlaySelectSound()
    {
        if(SoundController.instance.effectsActive)
            audioSource.Play();
    }

    public void AddTime(float amount)
    {
        timeAttackLeftTime += amount;
    }

    public void ClearMap()
    {
        if (currentFly != null)
            Destroy(currentFly);

        for (int i = obstaclesContainer.transform.childCount - 1; i >= 0; i--)
            GameObject.Destroy(obstaclesContainer.transform.GetChild(i).gameObject);
    }

    public void PrepareGame()
    {
        // game flags
        gameActive = true;
        backgroundActive = true;
        GameSpeed = StartGameSpeed;

        // respawn fly
        Destroy(currentFly);
        currentFly = Instantiate(ChoosenCharacter);
        currentFly.transform.position = flySpawn.transform.position;

        // turnoffspawner
        spawner.StopAllCoroutines();
        spawner.ResetUnlockedObstacles();

        // points counter
        pointsCounter.text = "0";
        points = 0;

        // remove obstacles
        for (int i = obstaclesContainer.transform.childCount - 1; i >= 0; i--)
            GameObject.Destroy(obstaclesContainer.transform.GetChild(i).gameObject);
    }

    public void StartModeClassic()
    {
        PrepareGame();
        currentMode = GameMode.Classic;
        StartCoroutine(spawner.StartSpawnerClassic());
    }

    public void StartModeTimeAttack()
    {
        PrepareGame();
        currentMode = GameMode.TimeAttack;
        StartCoroutine(StartTimer());
        StartCoroutine(spawner.StartSpawnerTimeAttack());
    }

    public void StartModeCrazy()
    {
        PrepareGame();
        currentMode = GameMode.Crazy;
        CameraController.instance.GoCrazy();
        StartCoroutine(spawner.StartSpawnerClassic());
        StartCoroutine(spawner.SpawnVolumes());
    }

    public void StartModeCrazyTimeAttack()
    {
        PrepareGame();
        currentMode = GameMode.CrazyTimeAttack;
        CameraController.instance.GoCrazy();
        StartCoroutine(StartTimer());
        StartCoroutine(spawner.StartSpawnerTimeAttack());
        StartCoroutine(spawner.SpawnVolumes());
    }

    private IEnumerator StartTimer()
    {
        timeAttackLeftTime = timeAttackBaseTime;

        while (timeAttackLeftTime > 0 && gameActive)
        {
            yield return null; // Zamiast WaitForSeconds, oczekuj na kolejn¹ klatkê

            timeAttackLeftTime -= Time.deltaTime;
            timeCounter.text = System.Math.Round(timeAttackLeftTime, 2).ToString();

            if (timeAttackLeftTime <= 0 || !currentFly.GetComponent<FlyController>().Lives())
            {
                currentFly.GetComponent<FlyController>().Die();
                timeCounter.text = "0,00";
                break;
            }
        }
    }

    public void EndGame()
    {
        gameActive = false;
        backgroundActive = false;
        

        switch (currentMode){
            case GameMode.Classic:
                EndModeClassic();
                break;

            case GameMode.TimeAttack:
                EndModeTimeAttack();
                break;

            case GameMode.Crazy:
                EndModeCrazy();
                break;

            case GameMode.CrazyTimeAttack:
                EndModeCrazyTimeAttack();
                break;

            default:
                break;
        }

        ModeUnlockController.instance.UnlockModes();
        SavingController.instance.SaveData();
    }
    public void EndModeClassic()
    {
        if (points > highscoreClassic)
            highscoreClassic = points;

        
        StartCoroutine(ShowClassicEndMenu());
    }

    public void EndModeTimeAttack()
    {
        if (points > highscoreTimeAttack)
            highscoreTimeAttack = points;


        StartCoroutine(ShowTimeAttackEndMenu());
    }

    public void EndModeCrazy()
    {
        if (points > highscoreCrazy)
            highscoreCrazy = points;

        CameraController.instance.GoNormal();
        CameraController.instance.Repair();
        StartCoroutine(ShowCrazyEndMenu());
    }

    public void EndModeCrazyTimeAttack()
    {
        if (points > highscoreCrazyTimeAttack)
            highscoreCrazyTimeAttack = points;

        CameraController.instance.GoNormal();
        CameraController.instance.Repair();
        StartCoroutine(ShowCrazyTimeAttackEndMenu());
    }

    public void EnableOnlyRestartButtonNamed(string name)
    {
        foreach (Transform t in endGameMenu.transform.GetChild(0).GetChild(0))
        {
            t.gameObject.SetActive(true);
            if (!t.name.Equals(name))
                t.gameObject.SetActive(false);
        }
            
    }

    public IEnumerator ShowClassicEndMenu()
    {
        yield return new WaitForSeconds(2f);
        endGameMenu.SetActive(true);
        EnableOnlyRestartButtonNamed("RestartClassic");
        finalPointsOutput.text = points.ToString();
        recordPointsOutput.text = highscoreClassic.ToString();
    }

    public IEnumerator ShowTimeAttackEndMenu()
    {
        yield return new WaitForSeconds(2f);
        endGameMenu.SetActive(true);
        EnableOnlyRestartButtonNamed("RestartTimeAttack");
        finalPointsOutput.text = points.ToString();
        recordPointsOutput.text = highscoreTimeAttack.ToString();
    }

    public IEnumerator ShowCrazyEndMenu()
    {
        yield return new WaitForSeconds(2f);
        endGameMenu.SetActive(true);
        EnableOnlyRestartButtonNamed("RestartCrazy");
        finalPointsOutput.text = points.ToString();
        recordPointsOutput.text = highscoreCrazy.ToString();
    }

    public IEnumerator ShowCrazyTimeAttackEndMenu()
    {
        yield return new WaitForSeconds(2f);
        endGameMenu.SetActive(true);
        EnableOnlyRestartButtonNamed("RestartCrazyTimeAttack");
        finalPointsOutput.text = points.ToString();
        recordPointsOutput.text = highscoreCrazyTimeAttack.ToString();
    }

    public void ActivateBackground()
    {
        backgroundActive = true;
    }

    public void AddPoint()
    {
        points += 1;
        pointsCounter.text = points.ToString();
        UpdateObstacleProgress();
        UpdateGameSpeed();
    }

    public void UpdateGameSpeed()
    {
        if (points < 100)
        {
            GameSpeed += 0.0004f;
            spawner.SpeedUpSpawner(0.008f);
        }
            
    }

    public void UpdateObstacleProgress()
    {
        if (points % 10 == 0)
            spawner.UnlockNextObstacle();
    }

    public void ChooseBeeCharacter()
    {
        ChoosenCharacter = BeeCharacter;
    }

    public void ChooseFlyCharacter()
    {
        ChoosenCharacter = FlyCharacter;
    }

    public void ChooseMosquitoCharacter()
    {
        ChoosenCharacter = MosquitoCharacter;
    }

    public void ChooseRockCharacter()
    {
        ChoosenCharacter = RockCharacter;
    }

    public void ChooseFlarCharacter()
    {
        ChoosenCharacter = FlarCharacter;
    }

    public void ChooseGirlCharacter()
    {
        ChoosenCharacter = GirlCharacter;
    }

    public void ChooseBackground(GameObject chosenBackground)
    {
        foreach (Transform t in Backgrounds.transform)
            t.gameObject.SetActive(false);
        
        chosenBackground.gameObject.SetActive(true);
        spawner.obstacles = chosenBackground.GetComponent<ObstaclesHolder>().obstacles;
    }

    public void ExitGame()
    {
        SavingController.instance.SaveData();
        Application.Quit();
    }
}
