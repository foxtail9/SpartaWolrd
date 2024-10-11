using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamControl : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;
    public Text countText;
    public string targetTag = "Player";
    private float updateInterval = 10f; 
    private float timer;

    private void Start()
    {
        UpdateEnemyCount();
    }
    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);

        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            UpdateEnemyCount();
            timer = 0f;
        }
    }

    void UpdateEnemyCount()
    {
        int count = GameObject.FindGameObjectsWithTag(targetTag).Length;
        countText.text = count.ToString();
    }
}
