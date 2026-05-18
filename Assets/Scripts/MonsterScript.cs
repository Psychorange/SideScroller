using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] List<Transform> map;
    [SerializeField] Transform myMonster;
    [SerializeField] int i;
    [SerializeField] int rotationDirection = 1;
    [SerializeField] float time;
    [SerializeField] int timeUntilMoving;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeUntilMoving)
        {
            time = 0;
            var mapWithComputerDoor = map[i].gameObject.GetComponent<MonsterDoor>();
            if (mapWithComputerDoor != null && !mapWithComputerDoor.computerDoor.doorOpen)
            {
                rotationDirection *= -1;
            }
            myMonster.position = map[i].position;
            print($"je bouge en {map[i]}");
            i += rotationDirection;
            if (i == 8)
            {
                i = 0; 
            } else if (i < 0)
            {
                i = 7;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<playerController>();
        if (player != null)
        {
            print("tu es mort >:p");
        }
    }
}
