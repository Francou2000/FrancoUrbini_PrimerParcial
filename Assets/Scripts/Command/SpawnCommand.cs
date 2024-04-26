using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCommand : ICommand
{
    private Spawner spawner;

    public SpawnCommand(Spawner spawner)
    {
        this.spawner = spawner;
    }

    public void Execute()
    {
        spawner.SpawnEnemy();
    }
}
