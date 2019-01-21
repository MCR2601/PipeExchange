using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile{

    public GameObject Base;
    public GameObject Object;

    public Direction[] Connections;

    public int TurnsClockwise;

    public Type tileType;

    public SimpleCords position;

    public Tile(SimpleCords pos)
    {
        position = pos;
    }

    public void Reset()
    {

    }

    public void RotateDirection(RotationDirection direction)
    {
        TurnsClockwise += (int)direction;
        List<Direction> updatedList = new List<Direction>();
        foreach (var item in Connections)
        {
            updatedList.Add(item.RotateInDirection(direction));
        }
        Base.transform.rotation = Quaternion.Euler(0,0,-90*TurnsClockwise);
        Connections = updatedList.ToArray();
    }

    public enum RotationDirection
    {
        Clockwise = 1,
        CounterClockwise= -1
    }
}
