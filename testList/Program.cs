using System.Collections.Generic;

bool done = false;
int length=0;
char alignment;
string longestString = "";
string boxifiedText="";
string topLeft="", topRight="", bottomLeft="", bottomRight="", vertical="";
char horizontal= '▄';
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
			horizontal = '═';
			vertical = "║";
			return;

		case 2: // Border Style -2-
			topLeft = "┌";
			topRight = "┐";
			bottomLeft = "└";
			bottomRight = "┘";
			horizontal = '─';
			vertical = "│";
			return;

		case 3: // Border Style -3-
			topLeft = "█";
			topRight = "█";
			bottomLeft = "█";
			bottomRight = "█";
			horizontal = '■';
			vertical = "█";
			return;

		case 4: // Border Style -4-
			topLeft = "░";
			topRight = "░";
			bottomLeft = "░";
			bottomRight = "░";
			horizontal = '░';
			vertical = "░";
			return;

		case 5: // Border Style -5-
			topLeft = "▓";
			topRight = "▓";
			bottomLeft = "▓";
			bottomRight = "▓";
			horizontal = '▓';
			vertical = "▓";
			return;

		case 6: // Border Style -6-
			topLeft = "♥";
			topRight = "♥";
			bottomLeft = "♥";
			bottomRight = "♥";
			horizontal = '♥';
			vertical = "♥";
			return;

		case 7: // Border Style -7-
			topLeft = "♦";
			topRight = "♦";
			bottomLeft = "♦";
			bottomRight = "♦";
			horizontal = '♦';
			vertical = "♦";
			return;

		default:
			break;
	}
	return;
}

char GetAlignment()
{
	Console.WriteLine("Choose how you want the text aligned");
	Console.WriteLine("[L]eft, [R]ight, or [C]enter");
	alignment = Console.ReadLine().ToUpper().FirstOrDefault();
	return alignment;
}

string Boxify(List<string> yourText, int length, char alignment)
{
	string border = new string(horizontal, length + 4);
	boxifiedText = topLeft + border + topRight;

	switch (alignment)
	{
		case 'L':
			foreach (string s in yourText)
			{
				int padLength = border.Length - s.Length -2;
				string padding = new string(' ', padLength);
				boxifiedText = boxifiedText + "\n" + vertical + " " + s + padding + vertical;
			}
			break;
		case 'C':
			foreach (string s in yourText)
			{
				int padLength = (length - s.Length + 4) / 2;
				string padding = new string(' ', padLength);

				//This is the line of code that almost broke me.
				padLength = s.Length % 2 == 0 ? padLength + 1 : padLength;
				string paddingRight = new string(' ', padLength);

				boxifiedText = boxifiedText + "\n" + vertical + padding + s + paddingRight + vertical;
			}

			break;
		case 'R':
			foreach (string s in yourText)
			{
				int padLength = length - s.Length + 2;
				string padding = new string(' ', padLength);
				boxifiedText = boxifiedText + "\n" + vertical + padding + s + "  " + vertical;
			}
			break;
		default:
			break;
	}

	boxifiedText = boxifiedText + "\n" + bottomLeft + border + bottomRight;
	return boxifiedText;
}

Console.Clear();
Console.WriteLine(Boxify(yourText, length, alignment));
Console.ReadKey();