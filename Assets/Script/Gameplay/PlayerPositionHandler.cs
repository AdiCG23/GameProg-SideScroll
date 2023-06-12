using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    [SerializeField] Vector2 playerCurrentPosition;
    [SerializeField] Vector2 currentCheckpointPosition;
    public TransformData PlayerPosition;
    private TriggerEvent playerTriggerEvent;

    void Start()
    {
       playerTriggerEvent = GetComponent<TriggerEvent>();
    }

    private void LoadPosition()
    {
        playerCurrentPosition = PlayerPosition.position;
    }

    private void SavePosition(Vector2 newPosition)
    {
        PlayerPosition.position = newPosition;
    }

    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
        CheckpointWallActive(col);
    }

    //menyalakan Dinding disamping Checkpoint
    public void CheckpointWallActive(GameObject wall)
    {
        //Debug.Log("name="+ wall.gameObject.transform.GetChild(0).gameObject.name);
        wall.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    //berguna untuk ketika Player Menabrak Checkpoint
    public void OnTrap()
    {
        ChangePlayerPosition(currentCheckpointPosition);
    }

    //berguna ketika Player menabrak garis Finish
    public void OnFinish(int Level_Difficulty)
    {
        GameManager.Instance.ChangeLevel(Level_Difficulty); 
    }

    //berguna untuk mengubah posisi player
    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

}