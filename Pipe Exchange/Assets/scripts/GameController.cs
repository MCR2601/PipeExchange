using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public Sprite Concrete;
    public Sprite ConcreteCracked;
    public Sprite Dirt;
    public Sprite Gras;
    public Sprite Empty;

    public GameObject EmptySprite;

    public GameObject House;  
    public GameObject Pump;
    public GameObject Sapling;
    public GameObject WaterCenter;
    public GameObject WaterSide;

    public GameObject WaterToggle;

    public GameObject Info;
    public GameObject Tools;

    public GameObject Cover;
    public Vector2 CoverTarget = new Vector2(4.228f,12);
    public float CoverSpeed = 5;

    public Sprite CounterClockwise;
    public Sprite Clockwise;
    public Sprite Hammer;
    public Sprite Seed;

    public GameObject MouseFollow;

    public GameObject MessageBox;
    public float MessageBoxShowtime = 0;
    public float MessageBoxMaxShowTime = 10;
    public bool BoxShown = false;
    

    public int lvlNum = 0;
    public string LevelName = "Blank";
    public int SeedsUsed = 0;
    public int HammersUsed = 0;
    public int ResetsUsed = 0;

    Tile[,] Map = new Tile[4, 1];
    List<GameObject> waterSprinkler = new List<GameObject>();

    public bool WaterEnabled = false;

    public Tool ActiveTool
    {
        get
        {
            return _activeTool;
        }
        set
        {
            switch (value)
            {
                case Tool.CounterClockwise:
                    MouseFollow.GetComponent<SpriteRenderer>().sprite = CounterClockwise;
                    break;
                case Tool.Clockwise:
                    MouseFollow.GetComponent<SpriteRenderer>().sprite = Clockwise;
                    break;
                case Tool.Hammer:
                    MouseFollow.GetComponent<SpriteRenderer>().sprite = Hammer;
                    break;
                case Tool.Seed:
                    MouseFollow.GetComponent<SpriteRenderer>().sprite = Seed;
                    break;
                default:
                    break;
            }            
            _activeTool = value;
        }
    }

    private Tool _activeTool;

    public bool levelComplete = false;

    public float donetime = 0;

    public float TimeTillScreen = 3;

    public GameState state = GameState.Game;

    Queue<KeyValuePair<int, GameObject>> WaterQueue = new Queue<KeyValuePair<int, GameObject>>();
    float WaterTime = 0;
    public bool finshedShown = false;

    // Use this for initialization
    void Start()
    {
        lvlNum = -1;
        ProceedToNextLevel();
    }
	
    public GameObject GetGameObjectAtOfType(SimpleCords sc, Type t)
    {
        ChangeTool("Clockwise");
        GameObject go = Instantiate(EmptySprite);
        Sprite s = null;
        string name = "";
        switch (t)
        {
            case Type.Concrete:
                s = Instantiate(Concrete);
                name = "Concrete";
                break;
            case Type.ConcreteCracked:
                break;
            case Type.Consumer:
                go = Instantiate(House);
                name = "Consumer";
                go.transform.position = new Vector2(sc.X, sc.Y);
                go.name = name + "(" + sc.X + "," + sc.Y + ")";
                return go;            
            case Type.Pump:
                go = Instantiate(Pump);
                name = "Pump";
                go.transform.position = new Vector2(sc.X, sc.Y);
                go.name = name + "(" + sc.X + "," + sc.Y + ")";
                return go;
            case Type.Dirt:
                s = Instantiate(Dirt);
                name = "Dirt";
                break;
            case Type.Gras:
                s = Instantiate(Gras);
                name = "Gras";
                break;
            case Type.Sapling:
                break;
            case Type.Empty:
                break;
            default:
                break;
        }
        go.GetComponent<SpriteRenderer>().sprite = s;
        go.transform.position = new Vector2(sc.X, sc.Y);
        go.name = name + "("+sc.X+","+sc.Y+")";
        return go;

    }
	// Update is called once per frame
	void Update () {

        if (BoxShown)
        {
            MessageBoxShowtime += Time.deltaTime;
            if (MessageBoxShowtime>MessageBoxMaxShowTime)
            {
                BoxShown = false;
                MessageBox.GetComponent<Animator>().SetTrigger("Hide");
            }
        }


        // update hover
        Info.GetComponent<Text>().text = GetGameInfo();

        MouseFollow.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)+new Vector3(0.5f,-0.5f,10);

        if (Input.anyKeyDown && !WaterEnabled)
        {
            // user clicked
            Tile t = GetClickedTile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (t!=null)
            {
                switch (ActiveTool)
                {
                    case Tool.CounterClockwise:
                        if (t.tileType == Type.Concrete)
                        {
                            t.RotateDirection(Tile.RotationDirection.CounterClockwise);
                        }
                        break;
                    case Tool.Clockwise:
                        if (t.tileType == Type.Concrete)
                        {
                            t.RotateDirection(Tile.RotationDirection.Clockwise);
                        }
                        break;
                    case Tool.Hammer:
                        if (t.tileType == Type.Concrete)
                        {
                            // destroy make it destroyed
                            t.tileType = Type.ConcreteCracked;
                            t.Base.GetComponent<SpriteRenderer>().sprite = Instantiate(ConcreteCracked);
                            HammersUsed++;
                        }
                        break;
                    case Tool.Seed:
                        if (t.tileType == Type.Gras)
                        {
                            t.tileType = Type.Sapling;
                            GameObject go = Instantiate(Sapling);
                            go.transform.SetParent(t.Base.transform);
                            t.Object = go;
                            SeedsUsed++;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        if (WaterQueue.Count>0)
        {
            WaterTime += Time.deltaTime * 3;

            while (WaterQueue.Count>0&& WaterQueue.Peek().Key<=WaterTime)
            {
                WaterQueue.Dequeue().Value.SetActive(true);
                
            }
        }

        // Cover
        Cover.transform.position = Vector2.Lerp(Cover.transform.position, CoverTarget, Time.deltaTime * CoverSpeed);


        if (levelComplete)
        {

            donetime += Time.deltaTime;
            if (donetime>=TimeTillScreen)
            {
                if (!finshedShown)
                {
                    CoverTarget = CoverTarget + new Vector2(0, -9);
                    finshedShown = true;
                    WaterToggle.GetComponentInChildren<Water>().Toggle();
                    ToggleWater(); 
                }                
                if (donetime>= TimeTillScreen + 2)
                {
                    ProceedToNextLevel();
                    levelComplete = false;
                    donetime = 0;
                    CoverTarget = CoverTarget + new Vector2(0, 9);
                    finshedShown = false;
                }
            }

        }
	}

    public void ToggleWater()
    {
        WaterEnabled = !WaterEnabled;

        if (WaterEnabled)
        {
            // calculate water and stuff

            Dictionary<Tile, bool> wateredTiles = new Dictionary<Tile, bool>();

            List<Tile> houses = new List<Tile>();
            List<Tile> pumps = new List<Tile>();

            Queue<Tile> moveStack = new Queue<Tile>();

            foreach (var item in Map)
            {
                if (item!=null)
                {
                    if (item.tileType== Type.Pump)
                    {
                        pumps.Add(item);
                        moveStack.Enqueue(item);
                    }
                    else
                    {
                        if (item.tileType == Type.Consumer)
                        {
                            houses.Add(item);
                        }            
                    }
                    wateredTiles.Add(item, false);
                }
            }

            int visibleStep = 0;

            while (moveStack.Count>0)
            {
                Tile t = moveStack.Dequeue();
                if (!wateredTiles[t])
                {
                    switch (t.tileType)
                    {
                        case Type.Concrete:
                            foreach (var item in t.Connections)
                            {
                                Tile otherTile = GetTileInDirection(t, item);
                                if (otherTile != null)
                                {
                                    if (otherTile.tileType == Type.Dirt)
                                    {
                                        // spawn water
                                        GameObject go = Instantiate(WaterSide);
                                        go.transform.position = otherTile.Base.transform.position;
                                        go.transform.rotation = Quaternion.Euler(0, 0, -90 * ((int)item+2));
                                        go.SetActive(false);
                                        WaterQueue.Enqueue(new KeyValuePair<int, GameObject>(visibleStep, go));
                                        waterSprinkler.Add(go);
                                    }
                                    else
                                    {
                                        if (!wateredTiles[otherTile])
                                        {
                                            moveStack.Enqueue(otherTile);
                                        }
                                    }
                                }
                            }
                            wateredTiles[t] = true;
                            break;
                        case Type.ConcreteCracked:
                            GameObject fauntain = Instantiate(WaterCenter);
                            fauntain.transform.position = t.Base.transform.position;
                            fauntain.SetActive(false);
                            WaterQueue.Enqueue(new KeyValuePair<int, GameObject>(visibleStep, fauntain));
                            waterSprinkler.Add(fauntain);
                            foreach (var item in t.Connections)
                            {
                                Tile otherTile = GetTileInDirection(t, item);
                                if (otherTile != null)
                                {
                                    if (otherTile.tileType == Type.Dirt)
                                    {
                                        // spawn water
                                        GameObject go = Instantiate(WaterSide);
                                        go.transform.position = otherTile.Base.transform.position;
                                        go.transform.rotation = Quaternion.Euler(0, 0, -90 * ((int)item + 2));
                                        go.SetActive(false);
                                        WaterQueue.Enqueue(new KeyValuePair<int, GameObject>(visibleStep, go));
                                        waterSprinkler.Add(go);
                                    }
                                    else
                                    {
                                        if (!wateredTiles[otherTile])
                                        {
                                            moveStack.Enqueue(otherTile);
                                        }
                                    }
                                }
                            }
                            wateredTiles[t] = true;
                            break;
                        case Type.Consumer:
                            t.Object.GetComponent<Consumer>().SetState(Consumer.ConsumerState.Watered);
                            foreach (var item in t.Connections)
                            {
                                Tile otherTile = GetTileInDirection(t, item);
                                if (otherTile != null)
                                {
                                    if (otherTile.tileType == Type.Dirt)
                                    {
                                        // spawn water
                                        GameObject go = Instantiate(WaterSide);
                                        go.transform.position = otherTile.Base.transform.position;
                                        go.transform.rotation = Quaternion.Euler(0, 0, -90 * ((int)item + 2));
                                        go.SetActive(false);
                                        WaterQueue.Enqueue(new KeyValuePair<int, GameObject>(visibleStep, go));
                                        waterSprinkler.Add(go);
                                    }
                                    else
                                    {
                                        if (!wateredTiles[otherTile])
                                        {
                                            moveStack.Enqueue(otherTile);
                                        }
                                    }
                                }
                            }
                            wateredTiles[t] = true;
                            break;
                        case Type.Pump:
                            t.Object.GetComponent<Pump>().SetState(global::Pump.PumpState.Work);
                            foreach (var item in t.Connections)
                            {                                
                                Tile otherTile = GetTileInDirection(t, item);
                                if (otherTile!=null)
                                {
                                    if (otherTile.tileType == Type.Dirt)
                                    {
                                        // spawn water
                                        GameObject go = Instantiate(WaterSide);
                                        go.transform.position = otherTile.Base.transform.position;
                                        go.transform.rotation = Quaternion.Euler(0, 0, -90 * ((int)item + 2));
                                        go.SetActive(false);
                                        WaterQueue.Enqueue(new KeyValuePair<int, GameObject>(visibleStep, go));
                                        waterSprinkler.Add(go);
                                    }
                                    else
                                    {
                                        if (!wateredTiles[otherTile])
                                        {
                                            moveStack.Enqueue(otherTile);
                                        }
                                    }
                                }
                            }
                            wateredTiles[t] = true;
                            break;
                        case Type.Dirt:
                            break;
                        case Type.Gras:
                            break;
                        case Type.Sapling:
                            t.Object.GetComponent<Plant>().SetState(Plant.PlantState.Grow);
                            foreach (var item in t.Connections)
                            {
                                Tile otherTile = GetTileInDirection(t, item);
                                if (otherTile != null)
                                {
                                    if (otherTile.tileType == Type.Dirt)
                                    {
                                        // spawn water
                                        GameObject go = Instantiate(WaterSide);
                                        go.transform.position = otherTile.Base.transform.position;
                                        go.transform.rotation = Quaternion.Euler(0, 0, -90 * (int)item);
                                        go.SetActive(false);
                                        WaterQueue.Enqueue(new KeyValuePair<int, GameObject>(visibleStep, go));
                                        waterSprinkler.Add(go);
                                    }
                                    else
                                    {
                                        if (!wateredTiles[otherTile])
                                        {
                                            moveStack.Enqueue(otherTile);
                                        }
                                    }
                                }
                            }
                            wateredTiles[t] = true;
                            break;
                        case Type.Empty:
                            break;
                        default:
                            break;
                    }
                }
                visibleStep++;
            }
            Debug.Log("did "+visibleStep+" steps for calculations");
            foreach (var item in wateredTiles)
            {
                Debug.Log(item.Key.position.X + "/" + item.Key.position.Y + ": " + item.Value);
            }
            bool won = true;
            foreach (var item in houses)
            {
                if (!wateredTiles[item])
                {
                    won = false;
                }
            }
            if (won)
            {
                levelComplete = true;
            }

        }
        else
        {
            foreach (var item in Map)
            {
                if (item!=null)
                {
                    switch (item.tileType)
                    {
                        case Type.Concrete:
                            break;
                        case Type.ConcreteCracked:
                            break;
                        case Type.Consumer:
                            item.Object.GetComponent<Consumer>().SetState(Consumer.ConsumerState.Reset);
                            break;
                        case Type.Pump:
                            item.Object.GetComponent<Pump>().SetState(global::Pump.PumpState.Reset);
                            break;
                        case Type.Dirt:
                            break;
                        case Type.Gras:
                            break;
                        case Type.Sapling:
                            item.Object.GetComponent<Plant>().SetState(Plant.PlantState.Reset);
                            break;
                        case Type.Empty:
                            break;
                        default:
                            break;
                    }
                }                
            }
            foreach (var item in waterSprinkler)
            {
                Destroy(item);
            }
        }

        
    }

    public void ProceedToNextLevel()
    {
        foreach (var item in Map)
        {
            if (item != null)
            {
                if (item.Base!=null)
                {
                    Destroy(item.Base);
                }
                if (item.Object != null)
                {
                    Destroy(item.Object);
                }
            }
        }
        Map = null;

        SeedsUsed = 0;
        HammersUsed = 0;
        ResetsUsed = 0;

        

        int levelId = lvlNum + 1;
        lvlNum++;
        try
        {
            Level nextLVL = LevelStorage.levels[levelId];

            Tile[,] newMap = new Tile[nextLVL.width,nextLVL.height];

            MessageBoxMaxShowTime = nextLVL.ReadTime;

            LevelName = nextLVL.Name;
            MessageBox.GetComponentInChildren<Text>().text = nextLVL.OpeningMessage;

            foreach (var item in nextLVL.Information)
            {
                Tile newTile = new Tile(item.position);
                newTile.tileType = item.TileType;
                switch (item.TileType)
                {
                    case Type.Concrete:
                        newTile.Base = GetGameObjectAtOfType(item.position, Type.Concrete);                        
                        break;
                    case Type.ConcreteCracked:
                        break;
                    case Type.Consumer:
                        newTile.Base = GetGameObjectAtOfType(item.position, Type.Concrete);
                        newTile.Object = GetGameObjectAtOfType(item.position, Type.Consumer);
                        break;
                    case Type.Pump:
                        newTile.Base = GetGameObjectAtOfType(item.position, Type.Concrete);
                        newTile.Object = GetGameObjectAtOfType(item.position, Type.Pump);
                        break;
                    case Type.Dirt:
                        newTile.Base = GetGameObjectAtOfType(item.position, Type.Dirt);
                        break;
                    case Type.Gras:
                        newTile.Base = GetGameObjectAtOfType(item.position, Type.Gras);
                        break;
                    case Type.Sapling:
                        break;
                    case Type.Empty:
                        break;
                    default:
                        break;
                }
                List<Direction> dir = new List<Direction>();
                foreach (var d in item.Connections)
                {
                    dir.Add(d);
                }
                newTile.Connections = dir.ToArray();
                newMap[item.position.X,item.position.Y] = newTile;
            }

            Map = newMap;

            BoxShown = true;
            MessageBoxShowtime = 0;
            MessageBox.GetComponent<Animator>().SetTrigger("Show");
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("You won the game");
            MessageBox.GetComponentInChildren<Text>().text = "Congratulations! \n\rYou successfully helped fix the pipenetwork!";
            MessageBox.GetComponent<Animator>().SetTrigger("Show");
            MessageBoxMaxShowTime = 60;
            MessageBoxShowtime = 0;
            BoxShown = true;
        }

    }


    public Tile GetTileInDirection(Tile t, Direction d)
    {

        try
        {
            Debug.Log(t.position);
            Debug.Log(d);
            Tile Other = null;
            switch (d)
            {
                case Direction.Up:
                    Other = Map[t.position.X, t.position.Y+1];
                    break;
                case Direction.Right:
                    Other = Map[t.position.X+1, t.position.Y];
                    break;
                case Direction.Down:
                    Other = Map[t.position.X, t.position.Y-1];
                    break;
                case Direction.Left:
                    Other = Map[t.position.X-1, t.position.Y];
                    break;
                default:
                    return null;
            }
            foreach (var item in Other.Connections)
            {
                if ((int)item == ((((int)d) + 2) % 4))
                {
                    Debug.Log("There was a connection");
                    return Other;
                }
            }
        }
        catch (System.Exception e )
        {
            Debug.Log(e.Message);
            Debug.Log("There was no connection with exception");
            return null;
        }
        Debug.Log("There was no connection");
        return null;
        
    }

    public void ChangeTool(string tool)
    {
        switch (tool)
        {
            case "CounterClockwise":
                ActiveTool = Tool.CounterClockwise;
                break;
            case "Clockwise":
                ActiveTool = Tool.Clockwise;
                break;
            case "Hammer":
                ActiveTool = Tool.Hammer;
                break;
            case "Seed":
                ActiveTool = Tool.Seed;
                break;
            default:
                break;
        }
    }

    public void Reset()
    {
        foreach (var item in Map)
        {
            if (item!=null)
            {
                switch (item.tileType)
                {
                    case Type.Concrete:
                        while (item.TurnsClockwise!=0)
                        {
                            if (item.TurnsClockwise>0)
                            {
                                item.RotateDirection(Tile.RotationDirection.CounterClockwise);
                            }
                            else
                            {
                                item.RotateDirection(Tile.RotationDirection.Clockwise);
                            }
                        }
                        break;
                    case Type.ConcreteCracked:
                        item.tileType = Type.Concrete;
                        item.Base.GetComponent<SpriteRenderer>().sprite = Instantiate(Concrete);
                        break;
                    case Type.Consumer:
                        item.Object.GetComponent<Consumer>().SetState(Consumer.ConsumerState.Reset);
                        break;
                    case Type.Pump:
                        item.Object.GetComponent<Pump>().SetState(global::Pump.PumpState.Reset);
                        break;
                    case Type.Dirt:
                        break;
                    case Type.Gras:
                        break;
                    case Type.Sapling:
                        item.tileType = Type.Gras;
                        Destroy(item.Object);
                        break;
                    case Type.Empty:
                        break;
                    default:
                        break;
                }



            }
        }


    }

    public Tile GetClickedTile(Vector2 pos)
    {
        try
        {
            Tile t= Map[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y)];
            return t;
        }
        catch (System.Exception)
        {
            Debug.Log("Clicked into The void");
            return null;
        }
    }

    public string GetGameInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Level: " + lvlNum + " - " + LevelName);
        sb.AppendLine("Seeds: " + SeedsUsed);
        sb.AppendLine("Hammers: "+HammersUsed);
        sb.Append("Resets: "+ResetsUsed);
        return sb.ToString();
    }


}
