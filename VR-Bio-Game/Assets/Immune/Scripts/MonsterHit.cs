using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    float health;
    public GameObject collisionPrefabGreen;
    public GameObject collisionPrefabRed;
    public GameObject collisionPrefabGold;
    public GameObject Sword;
    public GameObject score;

    AudioSource swordAudioSource;
    public AudioClip coinClip;

    void Start()
    {
        resetHealth();
        swordAudioSource = Sword.GetComponent<AudioSource>();
    }

    public void reduceHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            // Debug.Log("Monster is hit and health is reduced by: " + amount);
            killMonster(false, false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (this.gameObject.tag == "FatBlob")
        //    Debug.Log("FatBLob Collided with tag: " + collision.gameObject.tag +" and layer"+ collision.gameObject.layer+ " With x:"+ this.transform.position.x+ " and with y:" + transform.position.y  + " and z:"+transform.position.z);
        if (collision.gameObject.layer == 7)
        {
            this.transform.position = new Vector3(-70, -70, -70);
            //score.incrementScore(-5);
            //score.reduceHealth(1);
            GameManager._gameManager.ChangeStatus(2, -1); // if a monster slipped away 
            resetHealth();
            this.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player")
        {
            //score.reduceHealth(10);
            GameManager._gameManager.ChangeStatus(2, -1); // if a monster hits the player 
            resetHealth();
            killMonster(true, false);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            if (tag != "FatBlob" && tag!= "Infected" && tag!="RedCell") // the bullet can kill slime and spike
                reduceHealth(20);
        }
        else if (collision.gameObject.tag == "Sword" && collision.gameObject.GetComponent<Weapons>().isSelected())
        {
            if (tag == "FatBlob" || tag == "RedCell" || tag == "Infected") // the sword can only kill fatblob and redCell and infected cells
            {
                swordAudioSource.Play();
                reduceHealth(150);
            }
        }
    }


    private void playImpact(string s)
    {
        GameObject collision = null;
        //AudioSource.PlayClipAtPoint(coinClip, score.gameObject.transform.position);   
        for (int i = 0; i < 5; i++)
        {
            switch (s)
            {
                case "red":
                    collision = collisionPrefabRed.transform.GetChild(i).gameObject;
                    break;
                case "green":
                    collision = collisionPrefabGreen.transform.GetChild(i).gameObject;
                    break;
                case "gold":
                    collision = collisionPrefabGold.transform.GetChild(i).gameObject;
                    break;
            }
            if (!collision.activeSelf)
            {
                Vector3 position = transform.position;
                Quaternion rotation = transform.rotation;
                collision.SetActive(true);
                collision.transform.position = position;
                collision.transform.rotation = rotation;
                break;
            }
        }
    }
    public void DisplayScore()
    {
        if (score != null)
        {
            GameObject ScoreGameObject = Instantiate(score, transform.position, transform.rotation);
            ScoreGameObject.transform.Find("Canvas").Find("ScoreText").gameObject.GetComponent<TextMesh>().text = "+10";
        }
    }
    public void killMonster(bool isPlayer, bool isPill)
    {
        //if (!isPill)
            AudioSource.PlayClipAtPoint(coinClip, Sword.transform.position + new Vector3(0.5f,0,0));
        switch (this.tag)
        {
            case "Slime":
                if (!isPlayer)
                {
                    GameManager._gameManager.ChangeStatus(2, 2);
                    GameManager._gameManager.InstantiateScore(transform, 2);
                }
                playImpact("green");
                break;
            case "Spike":
                if (!isPlayer)
                {
                    GameManager._gameManager.ChangeStatus(2, 3);
                    GameManager._gameManager.InstantiateScore(transform, 2);
                }
                playImpact("green");
                break;
            case "FatBlob":
                if (!isPlayer)
                {
                    GameManager._gameManager.ChangeStatus(2, 5);
                    GameManager._gameManager.InstantiateScore(transform, 5);
                }
                playImpact("gold");
                break;
            case "RedCell":
                if (!isPlayer)
                {
                    GameManager._gameManager.ChangeStatus(2, -2);
                    GameManager._gameManager.InstantiateScore(transform, -2);
                }
                playImpact("red");
                break;
            case "Infected":
                if (!isPlayer)
                {
                    GameManager._gameManager.ChangeStatus(2, 5);
                    GameManager._gameManager.InstantiateScore(transform, 5);
                }
                playImpact("red");
                break;
        }
        this.transform.position = new Vector3(-70, -70, -70);
        resetHealth();
        this.gameObject.SetActive(false);
    }
    private void resetHealth()
    {
        switch (gameObject.tag)
        {
            case "Slime":
                health = 50;
                break;
            case "Spike":
                health = 70;
                break;
            case "FatBlob":
                health = 110;
                break;
            case "RedCell":
                health = 20;
                break;
            case "Infected":
                health = 40;
                break;
        }
    }

}
