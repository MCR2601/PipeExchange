using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelStorage  {
    /*
     new TileInfo()
                {
                    position = new SimpleCords(1,0),
                    TileType = Type.Concrete,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                }
     */
    public static Level[] levels = new Level[]
    {
        new Level()
        {
          Name = "Introduction",
          OpeningMessage = "Those workers covered the pipes to early without connecting them correclty! Click the Button on the bottom right to " +
            "put water into the network",
          ReadTime = 7,
          height = 3,
          width = 4,
          Information = new TileInfo[]
          {
              new TileInfo()
              {
                    position = new SimpleCords(0,2),
                    TileType = Type.Pump,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
              },
              new TileInfo()
              {
                    position = new SimpleCords(1,2),
                    TileType = Type.Concrete,
                    Connections = new Direction[]
                    {
                        Direction.Right,
                        Direction.Left
                    }
              },
              new TileInfo()
              {
                    position = new SimpleCords(2,2),
                    TileType = Type.Concrete,
                    Connections = new Direction[]
                    {
                        Direction.Right,
                        Direction.Left
                    }
              },
              new TileInfo()
              {
                    position = new SimpleCords(3,2),
                    TileType = Type.Consumer,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
              }
          }
        },
        new Level()
        {
            Name = "Turning",
            OpeningMessage = "Those stupid workers didnt put all pipes in correctly. So you will have to fix it by turning them with one of the tools above",
            ReadTime = 7,
            height = 3,
            width = 4,
            Information = new TileInfo[]
          {
              new TileInfo()
              {
                    position = new SimpleCords(0,2),
                    TileType = Type.Pump,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
              },
              new TileInfo()
              {
                    position = new SimpleCords(1,2),
                    TileType = Type.Concrete,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down
                    }
              },
              new TileInfo()
              {
                    position = new SimpleCords(2,2),
                    TileType = Type.Concrete,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down
                    }
              },
              new TileInfo()
              {
                    position = new SimpleCords(3,2),
                    TileType = Type.Consumer,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
              }
          }
        },
        new Level()
        {
            Name = "The Panic Hammer",
            OpeningMessage = "I cant really score you in this game so you choose your difficulty! Try to use as little tools as possible. " +
            "If you really want to know if a pipe gets water just give it a little hit with the hammer",
            ReadTime = 12,
            height = 4,
            width = 5,
            Information = new TileInfo[]
            {
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(0,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Pump,
                    position = new SimpleCords(0,3),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(1,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(1,3),
                    Connections = new Direction[]
                    {
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,2),
                    Connections = new Direction[]
                    {
                        Direction.Right,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,3),
                    Connections = new Direction[]
                    {
                        Direction.Right,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(3,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Consumer,
                    position = new SimpleCords(3,3),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
            }
        },
        new Level()
        {
            Name = "Regret",
            OpeningMessage = "Smashed floor cant be turned anymore, so you will need to reset with the button on the bottom right",
            ReadTime = 10,
            height = 4,
            width = 4,
            Information = new TileInfo[]
            {
                new TileInfo()
                {
                    TileType = Type.Pump,
                    position = new SimpleCords(0,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(1,2),
                    Connections = new Direction[]
                    {
                        Direction.Right,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Left,
                        Direction.Down
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Consumer,
                    position = new SimpleCords(3,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,3),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,1),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down,
                    }
                },
            }
        },        
        new Level()
        {
            Name = "Dirt",
            OpeningMessage = "At least they 'just' covered up their own work. You will be able to see any water emitted onto the dirt",
            ReadTime = 10,
            height = 4,
            width = 3,
            Information = new TileInfo[]
            {
                new TileInfo()
                {
                    position = new SimpleCords(0,0),
                    TileType = Type.Pump,
                    Connections = new Direction[]
                    {                       
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    position = new SimpleCords(1,0),
                    TileType = Type.Concrete,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    position = new SimpleCords(1,1),
                    TileType = Type.Concrete,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down,
                    }
                },
                new TileInfo()
                {
                    position = new SimpleCords(1,2),
                    TileType = Type.Concrete,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down,
                    }
                },
                new TileInfo()
                {
                    position = new SimpleCords(1,3),
                    TileType = Type.Concrete,
                    Connections = new Direction[]
                    {
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    position = new SimpleCords(2,3),
                    TileType = Type.Consumer,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    position = new SimpleCords(0,3),
                    TileType = Type.Dirt,
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
            }            
        },
        new Level()
        {
            Name = "Options",
            OpeningMessage = "Here you can show what you have learned from the previous workermistakes",
            height = 5,
            ReadTime = 7,
            width = 4,
            Information = new TileInfo[]
            {
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(0,1),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(0,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(0,3),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Pump,
                    position = new SimpleCords(0,4),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Dirt,
                    position = new SimpleCords(1,0),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(1,1),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Dirt,
                    position = new SimpleCords(1,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(1,3),
                    Connections = new Direction[]
                    {
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(1,4),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Consumer,
                    position = new SimpleCords(2,1),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,3),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,4),
                    Connections = new Direction[]
                    {
                        Direction.Down,
                        Direction.Left
                    }
                },

            }
        },
        /*
        new Level()
        {
            Name = "Mother Nature",
            OpeningMessage = "Those workers messed it up so long ago that gras grew over it! You can plant a seed that will grow in contact with water! Dont know if it is usefull though",
            height = 5,
            width = 4,
            Information = new TileInfo[]
            {
                new TileInfo()
                {
                    TileType = Type.Pump,
                    position = new SimpleCords(0,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(1,1),
                    Connections = new Direction[]
                    {
                        Direction.Down,
                        Direction.Right
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(1,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(1,3),
                    Connections = new Direction[]
                    {
                        Direction.Right,
                        Direction.Down,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Dirt,
                    position = new SimpleCords(2,0),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,1),
                    Connections = new Direction[]
                    {
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Gras,
                    position = new SimpleCords(2,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(2,3),
                    Connections = new Direction[]
                    {
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(3,1),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Concrete,
                    position = new SimpleCords(3,2),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Down,
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Consumer,
                    position = new SimpleCords(3,3),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
            }
        },
        */
        new Level()
        {
            Name = "Excuses",
            OpeningMessage = "This GameJame was tough and i was not able to add any more levels thank you for playing anyway! :D (i didnt get the seed working, sorry...)",
            ReadTime = 13,
            height = 2,
            width = 4,
            Information = new TileInfo[]
            {
                new TileInfo()
                {
                    TileType = Type.Pump,
                    position = new SimpleCords(0,1),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Consumer,
                    position = new SimpleCords(1,1),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Consumer,
                    position = new SimpleCords(2,1),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
                new TileInfo()
                {
                    TileType = Type.Consumer,
                    position = new SimpleCords(3,1),
                    Connections = new Direction[]
                    {
                        Direction.Up,
                        Direction.Right,
                        Direction.Down,
                        Direction.Left
                    }
                },
            }
        },

    };

}
