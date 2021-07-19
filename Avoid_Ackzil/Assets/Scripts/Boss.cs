using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region PUBLIC
    public enum People {RALO, CRAYFISH, PAKA, HYUNGDOK, LEEJAESEOK,
                        MONSTERRAT, KANE};
    public Vector2 defaultPos;
    public Vector2 appearancePos;
    public bool isAppeared;
    public bool playingPattern;
    public People people;
    Player player;
    AudioManager am;
    GameManager gm;
    #endregion

    #region PAKA
    float x = 0;
    float pakaSpeed = 5;
    #endregion

    #region HYUNGDOK
    float hyungdokSpeed = 50;
    bool notBack = false;
    #endregion;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        am = FindObjectOfType<AudioManager>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (people)
        {
            case People.RALO:
                {
                    GameObject gun = transform.GetChild(0).gameObject;
                    if (isAppeared)
                    {
                        transform.position = Vector2.Lerp(transform.position, appearancePos, 0.02f);
                        if (!playingPattern)
                        {
                            StartCoroutine(RaloPattern(gun));
                        }  
                    }
                    else
                    {
                        transform.position = Vector2.Lerp(transform.position, defaultPos, 0.02f);
                        gun.GetComponent<SpriteRenderer>().enabled = false;
                    }    
                    break;
                }
            case People.CRAYFISH:
                {
                    Mouse mouse = GetComponentInChildren<Mouse>();
                    if (isAppeared)
                    {
                        transform.position = Vector2.Lerp(transform.position, appearancePos, 0.02f);
                        if (!playingPattern)
                        {
                            StartCoroutine(CrayFishPattern(mouse));
                        }
                    }
                    else
                    {
                        transform.position = Vector2.Lerp(transform.position, defaultPos, 0.02f);
                    }
                    break;
                }
            case People.PAKA:
                {
                    if (isAppeared)
                    {
                        transform.position = new Vector2(defaultPos.x + x, defaultPos.y + Mathf.Abs(Mathf.Sin(x)));
                        x += pakaSpeed * Time.deltaTime;
                        if (!playingPattern)
                        {
                            StartCoroutine(PakaPattern());
                        }
                    }
                    else
                    {
                        transform.position = defaultPos;
                    }
                    break;
                }
            case People.HYUNGDOK:
                {
                    Rigidbody2D rb = GetComponent<Rigidbody2D>();
                    if (isAppeared)
                    {
                        if (!notBack)
                        {
                            transform.position = Vector2.Lerp(transform.position, appearancePos, 0.02f);
                        }
                        if (!playingPattern)
                        {
                            StartCoroutine(HyungDokPattern(rb));
                        }
                    }
                    else
                    {
                        transform.position = defaultPos;
                    }
                    break;
                }
            case People.LEEJAESEOK:
                {
                    Dropper dropper = GetComponentInChildren<Dropper>();
                    if (isAppeared)
                    {
                        transform.position = Vector2.Lerp(transform.position, appearancePos, 0.02f);
                        if (!playingPattern)
                        {               
                            StartCoroutine(LeeJaeSeokPattern(dropper));
                        }
                    }
                    else
                    {
                        transform.position = Vector2.Lerp(transform.position, defaultPos, 0.02f);
                    }
                    break;
                }
            case People.MONSTERRAT:
                {
                    if (isAppeared)
                    {
                        transform.position = Vector2.Lerp(transform.position, appearancePos, 0.02f);
                        if (!playingPattern)
                        {
                            StartCoroutine(MonsterRatPattern());
                        }
                    }
                    else
                    {
                        transform.position = Vector2.Lerp(transform.position, defaultPos, 0.02f);
                    }
                    break;
                }
            case People.KANE:
                {
                    WindShooter windShooter = GetComponentInChildren<WindShooter>();
                    if (isAppeared)
                    {
                        transform.position = Vector2.Lerp(transform.position, appearancePos, 0.02f);
                        if (!playingPattern)
                        {
                            StartCoroutine(KanePattern(windShooter));
                        }
                    }
                    else
                    {
                        transform.position = Vector2.Lerp(transform.position, defaultPos, 0.02f);
                    }
                    break;
                }
        }
        
    }

    IEnumerator RaloPattern(GameObject gun)
    {
        playingPattern = true;
        yield return new WaitForSeconds(0.5f);
        am.PlayOneShot("RaloSound1");
        yield return new WaitForSeconds(4);
        gun.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(2);
        am.PlayOneShot("RaloSound2");
        yield return new WaitForSeconds(0.95f);
        gun.GetComponent<Gun>().Shoot();
        yield return new WaitForSeconds(3);
        isAppeared = false;
        playingPattern = false;
        yield return new WaitForSeconds(3);
        gm.spawned = false;
    }

    IEnumerator CrayFishPattern(Mouse mouse)
    {
        playingPattern = true;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 10; i++)
        {
            mouse.Spit();
            am.PlayOneShot("CrayFishSound1");

            yield return new WaitForSeconds(0.5f);
        }
        isAppeared = false;
        playingPattern = false;
        yield return new WaitForSeconds(3);
        gm.spawned = false;
    }

    IEnumerator PakaPattern()
    {
        playingPattern = true;
        am.PlayOneShot("PakaSound");
        yield return new WaitForSeconds(5);
        isAppeared = false;
        playingPattern = false;
        x = 0;
        yield return new WaitForSeconds(3);
        gm.spawned = false;
    }

    IEnumerator HyungDokPattern(Rigidbody2D rb)
    {
        playingPattern = true;
        am.PlayOneShot("HyungDokSound");
        yield return new WaitForSeconds(5.7f);
        notBack = true;
        rb.velocity = Vector2.left * hyungdokSpeed;
        yield return new WaitForSeconds(2);
        isAppeared = false;
        playingPattern = false;
        notBack = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        gm.spawned = false;
    }

    IEnumerator LeeJaeSeokPattern(Dropper dropper)
    {
        playingPattern = true;
        yield return new WaitForSeconds(0.5f);
        am.PlayOneShot("LeeJaeSeokSound");
        for (int i = 0; i < 100; i++)
        {
            dropper.Drop();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2);
        isAppeared = false;
        playingPattern = false;
        yield return new WaitForSeconds(3);
        gm.spawned = false;
    }

    IEnumerator MonsterRatPattern()
    {
        playingPattern = true;
        yield return new WaitForSeconds(2);
        isAppeared = false;
        playingPattern = false;
        yield return new WaitForSeconds(3);
        gm.spawned = false;
    }

    IEnumerator KanePattern(WindShooter windShooter)
    {
        playingPattern = true;
        yield return new WaitForSeconds(1);
        am.PlayOneShot("KaneSound");
        for (int i = 0; i < 10; i++)
        {
            windShooter.Shoot();
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(2);
        isAppeared = false;
        playingPattern = false;
        yield return new WaitForSeconds(3);
        gm.spawned = false;
    }
}
