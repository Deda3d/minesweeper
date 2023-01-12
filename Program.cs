int xfield = 9; // розмір поля Х
int yfield = 9; // розмір поля У
int nmines = 10; // кількість мін
int xmine; // координата міни по Х
int ymine; // координата міни по Y
int xplayer = 3;
int yplayer = 1;

//

//


int[,] field = new int[yfield + 2, xfield + 2]; // поле
bool[,] openempty = new bool[yfield + 2, xfield + 2];
bool[,] cellisopen = new bool[yfield + 2, xfield + 2];
bool[,] flag = new bool[yfield + 2, xfield + 2];

for (int i = 0; i < yfield + 2; i++) field[i, 0] = -1;
for (int i = 0; i < yfield + 2; i++) field[i, xfield + 1] = -1;
for (int i = 0; i < xfield + 2; i++) field[0, i] = -1;
for (int i = 0; i < xfield + 2; i++) field[yfield + 1, i] = -1;

Random rnd = new Random();
while (nmines > 0)
{
    xmine = rnd.Next(1, xfield + 1);
    ymine = rnd.Next(1, yfield + 1);
    if (field[ymine, xmine] != 9)
    {
        field[ymine, xmine] = 9;
        nmines--;
    }
}

for (int i = 1; i < yfield + 1; i++)
{
    for (int j = 1; j < xfield + 1; j++)
    {
        if (field[i, j] != 9)
        {
            int c = 0;
            if (field[i + 1, j] == 9) c++;
            if (field[i + -1, j] == 9) c++;
            if (field[i, j + 1] == 9) c++;
            if (field[i, j - 1] == 9) c++;
            if (field[i + 1, j + 1] == 9) c++;
            if (field[i - 1, j - 1] == 9) c++;
            if (field[i + 1, j - 1] == 9) c++;
            if (field[i - 1, j + 1] == 9) c++;
            field[i, j] = c;
        }
    }
}


void Color()
{
    if (field[yplayer, (xplayer - 1) / 2] == -1) Console.ForegroundColor = ConsoleColor.White;
    else if (field[yplayer, (xplayer - 1) / 2] == 0) Console.ForegroundColor = ConsoleColor.Black;
    else if (field[yplayer, (xplayer - 1) / 2] == 1) Console.ForegroundColor = ConsoleColor.Blue;
    else if (field[yplayer, (xplayer - 1) / 2] == 2) Console.ForegroundColor = ConsoleColor.Green;
    else if (field[yplayer, (xplayer - 1) / 2] == 3) Console.ForegroundColor = ConsoleColor.Red;
    else if (field[yplayer, (xplayer - 1) / 2] == 4) Console.ForegroundColor = ConsoleColor.Magenta;
    else if (field[yplayer, (xplayer - 1) / 2] == 5) Console.ForegroundColor = ConsoleColor.DarkYellow;
    else if (field[yplayer, (xplayer - 1) / 2] == 6) Console.ForegroundColor = ConsoleColor.Cyan;
    else if (field[yplayer, (xplayer - 1) / 2] == 7) Console.ForegroundColor = ConsoleColor.DarkMagenta;
    else if (field[yplayer, (xplayer - 1) / 2] == 8) Console.ForegroundColor = ConsoleColor.DarkGray;
}


for (int i = 0; i < yfield + 2; i++)
{
    for (int j = 0; j < xfield + 2; j++)
    {
        if (field[i, j] == -1) Console.ForegroundColor = ConsoleColor.White;
        else if (field[i, j] == 0) Console.ForegroundColor = ConsoleColor.Black;
        else if (field[i, j] == 1) Console.ForegroundColor = ConsoleColor.Blue;
        else if (field[i, j] == 2) Console.ForegroundColor = ConsoleColor.Green;
        else if (field[i, j] == 3) Console.ForegroundColor = ConsoleColor.Red;
        else if (field[i, j] == 4) Console.ForegroundColor = ConsoleColor.Magenta;
        else if (field[i, j] == 5) Console.ForegroundColor = ConsoleColor.DarkYellow;
        else if (field[i, j] == 6) Console.ForegroundColor = ConsoleColor.Cyan;
        else if (field[i, j] == 7) Console.ForegroundColor = ConsoleColor.DarkMagenta;
        else if (field[i, j] == 8) Console.ForegroundColor = ConsoleColor.DarkGray;
        if (cellisopen[i, j] == false && field[i, j] != -1)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("██");
        }

        else
        {
            if (field[i, j] == -1) Console.Write("██");
            else if (field[i, j] == 9) Console.Write("()");
            else Console.Write($" {field[i, j]}");
        }
    }
    Console.WriteLine();
}

Console.SetCursorPosition(xplayer, yplayer);

bool gameactive = true;
bool win = false;
bool loose = false;

while (gameactive == true)
{
    var x = Console.ReadKey(true).Key;
    switch (x)
    {
        case ConsoleKey.D: if (field[yplayer, (xplayer + 2) / 2] != -1) xplayer += 2; break;
        case ConsoleKey.A: if (field[yplayer, (xplayer - 2) / 2] != -1) xplayer -= 2; break;
        case ConsoleKey.S: if (field[yplayer + 1, xplayer / 2] != -1) yplayer++; break;
        case ConsoleKey.W: if (field[yplayer - 1, xplayer / 2] != -1) yplayer--; break;
        case ConsoleKey.F:
            if (flag[yplayer - 1, xplayer / 2] == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                flag[yplayer - 1, xplayer / 2] = true;
            }
            else if (flag[yplayer - 1, xplayer / 2] == true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                flag[yplayer - 1, xplayer / 2] = false;
            }
            Console.SetCursorPosition(xplayer - 1, yplayer);
            Console.Write("██");
            Console.SetCursorPosition(xplayer, yplayer);
            break;
        case ConsoleKey.E:
            if (field[yplayer, (xplayer - 1) / 2] != 9)
            {
                Color();
                Console.SetCursorPosition(xplayer - 1, yplayer);
                Console.Write(" ");
                Console.SetCursorPosition(xplayer, yplayer);
                Console.Write(field[yplayer, (xplayer - 1) / 2]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(xplayer - 1, yplayer);
                Console.Write(" *");
                Console.SetCursorPosition(xplayer, yplayer);
                gameactive = false;
                loose = true;
            }
            //

            //
            break;
    }
    Console.SetCursorPosition(xplayer, yplayer);
    if (gameactive == false)
    {
        Console.SetCursorPosition(0, yfield + 1);
        if (win == true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You win!!!");
        }
        if (loose == true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lose!!!");
        }
    }
}