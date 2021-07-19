using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Boss[] bosses;
    Boss.People people;
    public bool spawned;

    // Start is called before the first frame update
    void Start()
    {
        bosses = FindObjectsOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            spawned = true;
            int r = Random.Range(1, 701);
            if (1 <= r && r <= 100)
            {
                people = Boss.People.RALO;    
            }
            else if (101 <= r && r <= 200)
            {
                people = Boss.People.CRAYFISH;
            }
            else if (201 <= r && r <= 300)
            {
                people = Boss.People.PAKA;
            }
            else if (301 <= r && r <= 400)
            {
                people = Boss.People.HYUNGDOK;
            }
            else if (401 <= r && r <= 500)
            {
                people = Boss.People.LEEJAESEOK;
            }
            else if (501 <= r && r <= 600)
            {
                people = Boss.People.MONSTERRAT;
            }
            else if (601 <= r && r <= 700)
            {
                people = Boss.People.KANE;
            }
            Debug.Log(r);
            foreach (Boss boss in bosses)
            {
                if (boss.people == people)
                {
                    boss.isAppeared = true;
                }
            }
        }
    }  
}
