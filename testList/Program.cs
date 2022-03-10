using System.Collections.Generic;

//variable declartion
bool done = false;
int length=0;
char alignment;
string longestString = "";
string boxifiedText="";
string topLeft="", topRight="", bottomLeft="", bottomRight="", vertical="";

//Needed to assign a value to horizontal beforehand otherwise everything breaks
char horizontal= '▄';

// Setup my list yourText
List<string> yourText = new List<string>();

//call the functions
BorderSelect();
GetAlignment();
GetText();
FindLongest();

void GetText()
{
    Console.WriteLine("Type in the text you want me to boxify");
    Console.WriteLine("Type \"end\" to end");

    //Continue to get additional lines and store them to List yourText until user enters "end"
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
    //Find longest string in List yourText
	foreach (string s in yourText)
    {
        //mmmm ternary operator
        longestString = s.Length > longestString.Length ? s : longestString;
    }
	//return length of longest string
    return length = longestString.Length;
}

void BorderSelect()
{
	//stolen wholesale from Mahmut Fesli
	//Asks for border type, then sets variables for fancy boxes
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
	//almost certainly overkill to put this in a function... but why not
	Console.WriteLine("Choose how you want the text aligned");
	Console.WriteLine("[L]eft, [R]ight, or [C]enter");
	alignment = Console.ReadLine().ToUpper().FirstOrDefault();
	return alignment;
}

string Boxify(List<string> yourText, int length, char alignment)
{
	//setup top border
	string border = new string(horizontal, length + 4);
	boxifiedText = topLeft + border + topRight;

	switch (alignment)
	{
		//All the stuff for Left align
		case 'L':
			//build the text between top and bottom borders.
			foreach (string s in yourText)
			{
				int padLength = border.Length - s.Length -1;
				string padding = new string(' ', padLength);
				boxifiedText = boxifiedText + "\n" + vertical + " " + s + padding + vertical;
			}
			break;
		
		//Center align
		case 'C':
			//formatting broke on odd length inputs, so hacked it to go up to next integer
			length = length % 2 == 0 ? length : length + 1;
			border = new string(horizontal, length + 4);

			//remaking the top border to fit with new length
			boxifiedText = topLeft + border + topRight;
			
			//Building the gooey inards of the box
			foreach (string s in yourText)
			{
				int padLength = (length - s.Length + 4) / 2;
				string padding = new string(' ', padLength);

				//This is the line of code that almost broke me.
				//If the length of the padding is even, then keep it.  If it's odd, make it even
				padLength = s.Length % 2 == 0 ? padLength: padLength + 1;
				string paddingRight = new string(' ', padLength);

				boxifiedText = boxifiedText + "\n" + vertical + padding + s + paddingRight + vertical;
			}
			break;

		//Right align
		case 'R':
			foreach (string s in yourText)
			{
				int padLength = length - s.Length + 2;
				string padding = new string(' ', padLength);
				boxifiedText = boxifiedText + "\n" + vertical + padding + s + "  " + vertical;
			}
			break;

		//Should probably make the default do something...
		default:
			break;
	}

	//stick on the bottom border
	boxifiedText = boxifiedText + "\n" + bottomLeft + border + bottomRight;
	return boxifiedText;
}

Console.Clear();
Console.WriteLine(Boxify(yourText, length, alignment));
Console.ReadKey();