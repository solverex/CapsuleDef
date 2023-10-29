using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // This code is the backbone of the game itself.

    // creates gamemanager instance
    public static GameManager instance;
    

    // Player Variables

    // values for player lane position
    [SerializeField] int playerposition;
    public Transform player;

    // gets player bullet gameobject
    public GameObject player_bullet;


    // GameObjects

    // shooter gameobjects
    public GameObject shooter_tower1;
    public GameObject shooter_tower2;
    public GameObject shooter_tower3;
    public GameObject shooter_tower4;
    public GameObject shooter_tower5;

    // rapids gameobjects
    public GameObject rapid_tower1;
    public GameObject rapid_tower2;
    public GameObject rapid_tower3;
    public GameObject rapid_tower4;
    public GameObject rapid_tower5;

    // blasters gameobjects
    public GameObject blaster_tower1;
    public GameObject blaster_tower2;
    public GameObject blaster_tower3;
    public GameObject blaster_tower4;
    public GameObject blaster_tower5;

    // Game Over Screen object
    public GameObject gameoverscreen;


    // towers variables

    // checks how many towers are active
    [SerializeField] int towers_active;

    // sets tower position for instantiation
    [SerializeField] Vector3 towerpos;

    // lane tower checks
    [SerializeField] int lane1towers;
    [SerializeField] int lane2towers;
    [SerializeField] int lane3towers;
    [SerializeField] int lane4towers;
    [SerializeField] int lane5towers;


    // the rest

    // stats during game
    [SerializeField] int money;
    [SerializeField] int score;
    [SerializeField] int health;

    // allows to change text
    public Text health_txt;
    public Text score_txt;
    public Text money_txt;
    public Text towername;
    public Text towerdesc;
    public Text gameovertext;

    // checks selected tower in UI
    [SerializeField] int selected_tower;

    

    // sets instance to this script
    void Start()
    {
        instance = this;
        gameoverscreen.SetActive(false);
    }


    // goes on continuously
    void Update()
    {
        playerpos();
        playermovement();
        towerselect();

        health_txt.text = "Health: " + health;
        score_txt.text = "Score: " + score;
        money_txt.text = "Cash: " + money;
    }

    // sets player position
    void playerpos()
    {
        if(playerposition == 0)
        {
            player.position = new Vector3(-7, 3, (float)0.5);
        }

        if(playerposition == 1)
        {
            player.position = new Vector3(-7, 3, (float)2.25);
        }

        if(playerposition == 2)
        {
            player.position = new Vector3(-7, 3, 4);
        }

        if(playerposition == -1)
        {
            player.position = new Vector3(-7, 3, (float)-1.25);
        }

        if(playerposition == -2)
        {
            player.position = new Vector3(-7, 3, -3);
        }
    }

    // player input
    void playermovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (playerposition != 2)
            {
                playerposition++;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (playerposition != -2)
            {
                playerposition--;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playershooting();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(selected_tower == 0)
            {
                spawnshoottower();
            }
            if(selected_tower == 1)
            {
                spawnrapidtower();
            }
            if(selected_tower == 2)
            {
                spawnblastertower();
            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selected_tower--;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selected_tower++;
        }
    }

    // player shooting instantiation
    void playershooting()
    {
        Instantiate(player_bullet, player.position, Quaternion.identity);
    }

    // checks preresiquites of tower
    void spawnshoottower()
    {
        if (money >= 15)
        {
            if (towers_active <= 11)
            {
                towershootcheck();
            }
        }
    }

    // instantiates tower (all below)
    void towershootcheck()
    {
        if (playerposition == 0)
        {
            if (lane1towers <= 4)
            {
                towerpos = new Vector3(((lane1towers+1) *2) -6, player.position.y, player.position.z);
                Instantiate(shooter_tower1, towerpos, Quaternion.identity);
                lane1towers++;
                towers_active++;
                money = money - 15;
            }
        }

        if (playerposition == 1)
        {
            if (lane2towers <= 4)
            {
                towerpos = new Vector3(((lane2towers+1) *2) -6, player.position.y, player.position.z);
                Instantiate(shooter_tower2, towerpos, Quaternion.identity);
                lane2towers++;
                towers_active++;
                money = money - 15;
            }
        }

        if (playerposition == 2)
        {
            if (lane3towers <= 4)
            {
                towerpos = new Vector3(((lane3towers+1) *2) -6, player.position.y, player.position.z);
                Instantiate(shooter_tower3, towerpos, Quaternion.identity);
                lane3towers++;
                towers_active++;
                money = money - 15;
            }
        }

        if (playerposition == -1)
        {
            if (lane4towers <= 4)
            {
                towerpos = new Vector3(((lane4towers+1) *2) -6, player.position.y, player.position.z);
                Instantiate(shooter_tower4, towerpos, Quaternion.identity);
                lane4towers++;
                towers_active++;
                money = money - 15;
            }
        }

        if (playerposition == -2)
        {
            if (lane5towers <= 4)
            {
                towerpos = new Vector3(((lane5towers+1) *2) -6, player.position.y, player.position.z);
                Instantiate(shooter_tower5, towerpos, Quaternion.identity);
                lane5towers++;
                towers_active++;
                money = money - 15;
            }
        }
    }

    void spawnrapidtower()
    {
        if (money >= 30)
        {
            if (towers_active <= 11)
            {
                towerrapidcheck();
            }
        }
    }

    void towerrapidcheck()
    {
        if (playerposition == 0)
        {
            if (lane1towers <= 4)
            {
                towerpos = new Vector3(((lane1towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(rapid_tower1, towerpos, Quaternion.identity);
                lane1towers++;
                towers_active++;
                money = money - 30;
            }
        }

        if (playerposition == 1)
        {
            if (lane2towers <= 4)
            {
                towerpos = new Vector3(((lane2towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(rapid_tower2, towerpos, Quaternion.identity);
                lane2towers++;
                towers_active++;
                money = money - 30;
            }
        }

        if (playerposition == 2)
        {
            if (lane3towers <= 4)
            {
                towerpos = new Vector3(((lane3towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(rapid_tower3, towerpos, Quaternion.identity);
                lane3towers++;
                towers_active++;
                money = money - 30;
            }
        }

        if (playerposition == -1)
        {
            if (lane4towers <= 4)
            {
                towerpos = new Vector3(((lane4towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(rapid_tower4, towerpos, Quaternion.identity);
                lane4towers++;
                towers_active++;
                money = money - 30;
            }
        }

        if (playerposition == -2)
        {
            if (lane5towers <= 4)
            {
                towerpos = new Vector3(((lane5towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(rapid_tower5, towerpos, Quaternion.identity);
                lane5towers++;
                towers_active++;
                money = money - 30;
            }
        }
    }

    void spawnblastertower()
    {
        if (money >= 50)
        {
            if (towers_active <= 11)
            {
                towerblastercheck();
            }
        }
    }

    void towerblastercheck()
    {
        if (playerposition == 0)
        {
            if (lane1towers <= 4)
            {
                towerpos = new Vector3(((lane1towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(blaster_tower1, towerpos, Quaternion.identity);
                lane1towers++;
                towers_active++;
                money = money - 50;
            }
        }

        if (playerposition == 1)
        {
            if (lane2towers <= 4)
            {
                towerpos = new Vector3(((lane2towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(blaster_tower2, towerpos, Quaternion.identity);
                lane2towers++;
                towers_active++;
                money = money - 50;
            }
        }

        if (playerposition == 2)
        {
            if (lane3towers <= 4)
            {
                towerpos = new Vector3(((lane3towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(blaster_tower3, towerpos, Quaternion.identity);
                lane3towers++;
                towers_active++;
                money = money - 50;
            }
        }

        if (playerposition == -1)
        {
            if (lane4towers <= 4)
            {
                towerpos = new Vector3(((lane4towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(blaster_tower4, towerpos, Quaternion.identity);
                lane4towers++;
                towers_active++;
                money = money - 50;
            }
        }

        if (playerposition == -2)
        {
            if (lane5towers <= 4)
            {
                towerpos = new Vector3(((lane5towers + 1) * 2) - 6, player.position.y, player.position.z);
                Instantiate(blaster_tower5, towerpos, Quaternion.identity);
                lane5towers++;
                towers_active++;
                money = money - 50;
            }
        }
    }

    // destroyed towers
    public void towerdestroyed1()
    {
        lane1towers--;
        towers_active--;
    }

    public void towerdestroyed2()
    {
        lane2towers--;
        towers_active--;
    }

    public void towerdestroyed3()
    {
        lane3towers--;
        towers_active--;
    }

    public void towerdestroyed4()
    {
        lane4towers--;
        towers_active--;
    }

    public void towerdestroyed5()
    {
        lane5towers--;
        towers_active--;
    }

    // when enemy is killed
    public void enemydead()
    {
        score = score + 100;
        money = money + 10;
    }

    // selecter for towers
    void towerselect()
    {
        if (selected_tower <=-1)
        {
            selected_tower = 3;
        }
        if (selected_tower == 0)
        {
            towername.text = "Shooter";
            towerdesc.text = "Fires moderate bullets at a moderate rate of fire.      Cost: 15    Decay time: 10 seconds";
        }
        if (selected_tower == 1)
        {
            towername.text = "Rapid";
            towerdesc.text = "High fire rate, but low damaging bullets.                        Cost: 30    Decay time: 20 seconds";
        }
        if (selected_tower == 2)
        {
            towername.text = "Blaster";
            towerdesc.text = "Huge, damaging shots that take a while to shoot.               Cost: 50     Decay time: 30 seconds";
        }
        if (selected_tower >=3)
        {
            selected_tower = 0;
        }
    }

    // lose condition
    public void healthloss()
    {
        health--;
        if(health<=0)
        {
            int finalscore = score;
            gameoverscreen.SetActive(true);
            gameovertext.text = "GAME OVER! FINAL SCORE: " + finalscore;
        }
    }
}
