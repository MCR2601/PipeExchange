using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCords{

    public int X;
    public int Y;

    public SimpleCords(int x, int y)
    {
        X = x;
        Y = y;
    }

    public SimpleCords Offset(int x, int y)
    {
        return new SimpleCords(X + x, Y + y);
    }

    public override string ToString()
    {
        return "{" + X + "/" + Y +"}";
    }

}
