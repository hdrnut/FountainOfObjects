// See https://aka.ms/new-console-template for more information
RoomType[][] rooms = new RoomType[4][];
rooms[0] = new RoomType [] { RoomType.Entrance, RoomType.Empty, RoomType.Fountain, RoomType.Empty };
for (int i = 1; i < 4; i++)
{
    rooms[i] = new RoomType[] { RoomType.Empty, RoomType.Empty, RoomType.Empty, RoomType.Empty };
}

// Initial fountain status.
bool fountainActivated = false;

// Collection of movements.
move[] moves = new move[4];
moves[0] = new move("east", 0, 1);
moves[1] = new move("west", 0, -1);
moves[2] = new move("north", -1, 0);
moves[3] = new move("south", 1, 0);

// Starting position.
int r = 0;
int c = 0;

// User input goes here.
string resp = "";
string[] respwords;

while (resp != "bye")
{
    if (rooms[r][c] == RoomType.Entrance && fountainActivated)
    {
        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
        Console.WriteLine("You win!");
        break;
    }
    if (rooms[r][c] == RoomType.Empty)
    {
        Console.WriteLine($"You are in the room at (Row={r}, Column ={c}).");
    } else 
    {
        Console.WriteLine($"You are in the {rooms[r][c]} room at (Row={r}, Column ={c}).");
    }
    Console.WriteLine("What do you want to do? ");
    resp = Console.ReadLine();

    respwords = resp.Split(" ");

    if (respwords.Length > 0)
    {
        if (respwords[0] == "move")
        {
            int i;
            for(i = 0; i < moves.Length; i++)
            {
                if (moves[i].Dir == respwords[1])
                {
                    break;
                }
            }
            if (i < moves.Length)
            {
                int newR, newC;
                newR = r + moves[i].R;
                newC = c + moves[i].C;
                if (newR < rooms.Length && newC < rooms[c].Length && newR > -1 && newC > -1)
                {
                    r = newR;
                    c = newC;
                } else
                {
                    Console.WriteLine("Invalid move.");
                }
            } else
            {
                Console.WriteLine("Invalid direction.");
            }
        } else
        {
            if (respwords[0] == "activate")
            {
                if (rooms[r][c] == RoomType.Fountain)
                {
                    fountainActivated = true;
                }
            } else
            {
                if (resp != "bye")
                {
                    Console.WriteLine("Invalid response.");
                }
            }
        }
    }
}
enum RoomType { Empty, Entrance, Fountain };
public class move
{
    private string _dir;
    private int _r;
    private int _c;
    public move(string dir, int r, int c)
    {
        _dir = dir; 
        _r = r;
        _c = c;
    }
    public string Dir
    {
        get => _dir;
    }
    public int R
    {
        get => _r;
    }
    public int C
    {
        get => _c;
    }
}