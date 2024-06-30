using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    //[SerializeField] GameObject battleBG;
    [SerializeField] int battleBG;

    [SerializeField] Transform[] playerPosition, enemiesPosition;

    [SerializeField] BattleCharacter[] playerPref, enemyPref;

    //this will make the battles active in the area
    private bool battleActive;

    [SerializeField] int currentTurn;
    [SerializeField] bool waitingForTurn;
    [SerializeField] GameObject uiHolder;

    [SerializeField] List<BattleCharacter> activeCharacters = new List<BattleCharacter>();

    [SerializeField] BattleMoves[] battleList;
    CinemachineVirtualCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        //cam = GameObject.FindGameObjectWithTag("FollowCamera").GetComponent<CinemachineVirtualCamera>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {

            StartBatttle(new string[] { "Skelet", "Orc" });
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextTurn();
        }

        CheckTurns();
    }

    private void CheckTurns()
    {
        if (battleActive)
        {
            if (waitingForTurn)
            {
                if (activeCharacters[currentTurn].IsPlayer())
                {

                    uiHolder.SetActive(true);

                }

                else
                {
                    uiHolder.SetActive(false);
                    StartCoroutine(EnemyMove());
                }
            }
        }
    }

    public void StartBatttle(string[] enemiesToSpawn)
    {

        Player.instance.transform.position = Vector2.zero;
        //Player.instance.transform.position = transform.position;

        Prepare();
        AddPlayers();

        AddEnemies(enemiesToSpawn);
        waitingForTurn = true;
        currentTurn = 0;


    }

    private void AddEnemies(string[] enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn.Length; i++)
        {
            if (enemiesToSpawn[i] != "")
            {
                for (int j = 0; j < enemyPref.Length; j++)
                {
                    if (enemyPref[i].characterName == enemiesToSpawn[i])
                    {

                        BattleCharacter newEnemy = Instantiate(enemyPref[j], enemiesPosition[i].position, enemiesPosition[i].rotation);
                        activeCharacters.Add(newEnemy);

                    }
                }
            }
        }
    }

    private void AddPlayers()
    {
        /// to get everyone that has the playerstats equipped, if they are active, and get the names of
        // them. When we get the name, we get every prefab we created 
        for (int i = 0; i < GameManager.instance.GetPlayerStats().Length; i++)
        {
            if (GameManager.instance.GetPlayerStats()[i].gameObject.activeInHierarchy)
            {
                for (int j = 0; j < playerPref.Length; j++)
                {
                    if (playerPref[j].characterName == GameManager.instance.GetPlayerStats()[i].playerName)
                    {
                        BattleCharacter newPlayer = Instantiate(playerPref[j], playerPosition[i].position, playerPosition[i].rotation);
                        activeCharacters.Add(newPlayer);
                        ImportPlayerStatuses(i);

                    }
                }

            }
        }
    }

    private void ImportPlayerStatuses(int i)
    {
        // add the stats to the players.
        PlayerStats player = GameManager.instance.GetPlayerStats()[i];
        activeCharacters[i].currentHP = player.currentHP;
        activeCharacters[i].currentMana = player.currentMana;
        activeCharacters[i].maxHp = player.maxHP;
        activeCharacters[i].maxMana = player.maxMana;
        activeCharacters[i].strength = player.physAttack;
        activeCharacters[i].defense = player.defense;
        activeCharacters[i].magicRes = player.magicRES;
        activeCharacters[i].speed = player.speed;
        activeCharacters[i].magicAttack = player.magAttack;
    }

    private void Prepare()
    {// if the battle was not active, then set it to active
     //, set the position to the camera position, and load the scene.

        if (!battleActive)
        {
            battleActive = true;
            GameManager.instance.isBattleActive = true;
            Camera.main.transform.position = new Vector3(0f, 0f, -10f);
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);

            Player.instance.gameObject.SetActive(false);
            SceneManager.LoadScene(battleBG);

        }
        //SceneManager.LoadScene(battleBG);
        //battleBG.SetActive(true);
    }

    private void NextTurn()
    {
        currentTurn++;
        if (currentTurn >= activeCharacters.Count)
        {
            currentTurn = 0;

            waitingForTurn = true;

            UpdateBattle();
        }

    }

    void UpdateBattle()
    {
        bool isPlayerDead = true;
        bool isEnemyDead = true;

        for (int i = 0; i < activeCharacters.Count; i++)
        {
            if (activeCharacters[i].currentHP < 0)
            {
                activeCharacters[i].currentHP = 0;
            }
            if (activeCharacters[i].currentHP < 0)
            {
                // die
            }
            else
            {
                if (activeCharacters[i].IsPlayer())
                {
                    isPlayerDead = false;
                }
                else
                {
                    isEnemyDead = false;
                }
            }
        }
        if ( isPlayerDead || isEnemyDead)
        {
            if (isEnemyDead)
            {
                print("We Won");
            }
            else if (isPlayerDead)
            {
                print("We Lost");
            }

            SceneManager.LoadScene(2);
            GameManager.instance.isBattleActive = false;
            battleActive = false;
            Player.instance.gameObject.SetActive(true);

        }

    }
    public IEnumerator EnemyMove()
    {
        waitingForTurn = false;
        yield return new WaitForSeconds(1f);
        EnemyAttack();
        yield return new WaitForSeconds(1f);
        NextTurn();
    }
    void EnemyAttack()
    {
        List<int> players = new List<int>();

        for (int i = 0; i< activeCharacters.Count; i++)
        {
            if(activeCharacters[i].IsPlayer() && activeCharacters[i].currentHP > 0)
            {
                players.Add(i);
            }
        }
        int selectPlayer = players[Random.Range(0, players.Count)];

        int selectedAttack = Random.Range(0, activeCharacters[currentTurn].AttacksAvailable().Length);

        for(int i= 0; i < battleList.Length; i++)
        {
       
            if (battleList[i].moveName == activeCharacters[currentTurn].AttacksAvailable()[selectedAttack])
            {
              
                Instantiate(battleList[i].effect, activeCharacters[selectPlayer].transform.position, activeCharacters[selectPlayer].transform.rotation);
            }


        }


       


    }

    private void DealDamage(int selectedCharacter, int movePower)
    {
        float attackPower = activeCharacters[currentTurn].dexterity + activeCharacters[currentTurn].weaponPower;
        float defenseAmount = activeCharacters[selectedCharacter ].defense + activeCharacters[selectedCharacter].armorValue;

        float damageAmount = (attackPower / defenseAmount) * movePower * Random.Range(.9f, 1.3f);
        int damageToGive = (int)damageAmount;

      //  damageToGive = CalculateCritical(damageToGive);

        Debug.Log(activeCharacters[currentTurn].characterName + "Just Dealt" + damageAmount + "(" + damageToGive + ") to " + activeCharacters[selectedCharacter]);

        activeCharacters[selectedCharacter].TakeDamage(damageToGive);
    }

    //private int CalculateCritical(int damage)
    //{
        
    //}
}