using System.Collections.Generic;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{
    [SerializeField]
    private bool playerTyping = false;
    [SerializeField]
    private string currentString = "";

    [SerializeField]
    private List<CheatCodeInstance> cheatCodeList = new List<CheatCodeInstance>();
    [SerializeField]
    private CheatMenu cheatMenu;


    private void Start()
    {
       cheatMenu = GameObject.FindWithTag("CheatUI").GetComponent<CheatMenu>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (playerTyping) CheckCheatCode(currentString);

            playerTyping = !playerTyping;
        }

        if (playerTyping)
        {
            foreach (char c in Input.inputString)
                if (c == '\b')
                {
                    if (currentString.Length > 0)
                        currentString = currentString.Substring(0, currentString.Length - 1);
                }
                else if (c == '\n' || c == '\r') currentString = "";
                else currentString += c;

            if (!cheatMenu.IsActive) cheatMenu.ToggleMenu();
            cheatMenu.SetInputText(currentString);
        }
        else if (cheatMenu.IsActive) cheatMenu.ToggleMenu();
    }

    private bool CheckCheatCode(string _input)
    {
        foreach (CheatCodeInstance c in cheatCodeList)
            if (_input == c.code)
            {
                c.cheatEvent?.Invoke();
                return true;
            }

        return false;
    }


    // Cheats
    public void CheatPlayerFragile()
    {
        IUnit player = GameObject.FindWithTag("Player").GetComponent<Unit>();
        if (player != null) player.TakeDamage(player.GetHealth - 1);
    }

    public void CheatPlayerRobust()
    {
        IUnit player = GameObject.FindWithTag("Player").GetComponent<Unit>();
        if (player != null) player.HealDamage(9999);
    }

    public void CheatPlayerDeath()
    {
        IUnit player = GameObject.FindWithTag("Player").GetComponent<Unit>();

        if (player != null) player.TakeDamage(player.GetHealth);
    }

    public void CheatEnemiesFragile()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies != null)
            foreach (GameObject enemy in enemies)
            {
                IUnit enemyUnit = enemy.GetComponent<Unit>();
                enemyUnit.TakeDamage(enemyUnit.GetHealth - 1);
            }
    }

    public void CheatEnemiesRobust()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies != null)
            foreach (GameObject enemy in enemies)
            {
                IUnit enemyUnit = enemy.GetComponent<Unit>();
                enemyUnit.HealDamage(9999);
            }
    }

    public void CheatEnemiesDeath()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies != null)
            foreach (GameObject enemy in enemies)
            {
                IUnit enemyUnit = enemy.GetComponent<Unit>();
                enemyUnit.TakeDamage(enemyUnit.GetHealth);
            }
    }


    // Location Teleport
    public void CheatPlayerStartingPos()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) player.GetComponent<Transform>().position = player.GetComponent<Unit>().GetStartingPos;
    }

    public void CheatPlayerTPBench()
    {
        Transform player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if (player != null) player.position = new Vector3(18.5f, -18.4f, 0f);
    }
}
