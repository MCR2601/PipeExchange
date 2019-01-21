using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethodes  {

    public static Direction RotateInDirection(this Direction dir, Tile.RotationDirection rotation)
    {
        // setup the direction of rotation change
        int change = rotation == Tile.RotationDirection.Clockwise ? 1 : -1;

        return (Direction)(((int)dir + change + 4) % 4);
    }


}
