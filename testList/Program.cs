using System.Collections.Generic;

bool done = false;
int length=0;
char alignment;
string longestString = "";
string boxifiedText="";
string topLeft, topRight, bottomLeft, bottomRight, vertical , horizontal;
List<string> yourText = new List<string>();

BorderSelect();
GetAlignment();
GetText();
FindLongest();


void GetText()
{
    Console.WriteLine("Type in the text you want me to boxify");
    Console.WriteLine("Type \"end\" to end");

    while (!done)
    {
        string input = Console.ReadLine();
        if (input != "end")
        {
            yourText.Add(input);
        }
        else
        {
            break;
        }
    }
}

int FindLongest()
{
    foreach (string s in yourText)
    {
        //mmmm ternary operator
        longestString = s.Length > longestString.Length ? s : longestString;
    }
    return length = longestString.Length;
}

void BorderSelect()
{
    Console.WriteLine("Please enter the the border style number you want.\n");
    Console.WriteLine("╔═══╗	┌───┐	▀▀▀▀▀	░░░░░	▓▓▓▓▓	♥♥♥♥♥	♦♦♦♦♦");
    Console.WriteLine("║ 1 ║	│ 2 │	█ 3 █	░ 4 ░	▓ 5 ▓	♥ 6 ♥	♦ 7 ♦");
    Console.WriteLine("╚═══╝	└───┘	▄▄▄▄▄	░░░░░	▓▓▓▓▓	♥♥♥♥♥	♦♦♦♦♦\n");

    int borderStyle = int.Parse(Console.ReadLine());
	switch (borderStyle)
	{
		case 1: // Border Style -1-
			topLeft = "╔";
			topRight = "╗";
			bottomLeft = "╚";
			bottomRight = "╝";
			horizontal = "═";
			vertical = "║";
			break;

		case 2: // Border Style -2-
			topLeft = "┌";
			topRight = "┐";
			bottomLeft = "└";
			bottomRight = "┘";
			horizontal = "─";
			vertical = "│";
			break;

		case 3: // Border Style -3-
			topLeft = "█";
			topRight = "█";
			bottomLeft = "█";
			bottomRight = "█";
			horizontal = "■";
			vertical = "█";
			break;

		case 4: // Border Style -4-
			topLeft = "░";
			topRight = "░";
			bottomLeft = "░";
			bottomRight = "░";
			horizontal = "░";
			vertical = "░";
			break;

		case 5: // Border Style -5-
			topLeft = "▓";
			topRight = "▓";
			bottomLeft = "▓";
			bottomRight = "▓";
			horizontal = "▓";
			vertical = "▓";
			break;

		case 6: // Border Style -6-
			topLeft = "♥";
			topRight = "♥";
			bottomLeft = "♥";
			bottomRight = "♥";
			horizontal = "♥";
			vertical = "♥";
			break;

		case 7: // Border Style -7-
			topLeft = "♦";
			topRight = "♦";
			bottomLeft = "♦";
			bottomRight = "♦";
			horizontal = "♦";
			vertical = "♦";
			break;
		
		default:
			break;
	}
	return;
}

char GetAlignment()
{
	Console.WriteLine("Choose how you want the text aligned");
	Console.WriteLine("[L]eft, [R]ight, or [C]enter");
	alignment = Console.ReadLine().FirstOrDefault();
	return alignment;
}


string Boxify(List<string> yourText, int length, char alignment )
{
    return boxifiedText;
}

Console.Clear();

for(int i = 0; i < yourText.Count; i++)
{
    Console.WriteLine(yourText[i]);
}
Console.WriteLine(alignment);