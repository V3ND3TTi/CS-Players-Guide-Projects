Console.OutputEncoding = System.Text.Encoding.UTF8;

int time = 4;
int cream = 3;
int r = 75 + 30 * cream;
int g = 54 + 23 * cream;
int b = 33 + 19 * cream;

string italicsOn = "\e[3m";
string italicsOff = "\e[23m";
string setForeground = "\e[38;2;240;227;144m";
string resetForeground = "\e[39m";
string setBackground = $"\e[48;2;{r};{g};{b}m";
string resetBackground = "\e[49m";

Thread.Sleep(time * 1000);
Console.WriteLine($"The {italicsOn}{setForeground}{setBackground}☕coffee{italicsOff}{resetForeground}{resetBackground} is ready!");