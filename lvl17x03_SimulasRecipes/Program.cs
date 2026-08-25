Console.Write($"""
                   1 - Garlic Mushrooms Stew
                   2 - Cayenne Carrots Soup
                   3 - Ginger Potatoes Curry
                   4 - Cayenne Chicken Curry
                   5 - Garlic Chicken Soup
                   6 - Ginger Carrots Stew
                   Please enter the number of the recipe you prefer:
                   """);
int choice = int.Parse(Console.ReadLine()!);

(Form form, Ingredient ingredient, Seasoning seasoning) soup = choice switch
{
    1 => (Form.Stew, Ingredient.Mushrooms,Seasoning.Garlic),
    2 => (Form.Soup, Ingredient.Carrots, Seasoning.Cayenne),
    3 => (Form.Curry, Ingredient.Potatoes, Seasoning.Ginger),
    4 => (Form.Curry, Ingredient.Chicken, Seasoning.Cayenne),
    5 => (Form.Soup, Ingredient.Chicken, Seasoning.Garlic),
    6 => (Form.Stew, Ingredient.Carrots, Seasoning.Ginger),
    _ => (Form.Soup, Ingredient.Chicken, Seasoning.Cayenne)
};

if (choice < 1 || choice > 6)
{
    Console.WriteLine(
        $"Invalid choice. You get {ConvertSeasoningToString(soup.seasoning)} {ConvertIngredientToString(soup.ingredient)} {ConvertFormToString(soup.form)}. Enjoy!");
}
else
{
    Console.WriteLine(
        $"You have chosen {ConvertSeasoningToString(soup.seasoning)} {ConvertIngredientToString(soup.ingredient)} {ConvertFormToString(soup.form)}. Enjoy!");
}

string ConvertFormToString(Form f) => f switch
{
    Form.Stew => "stew",
    Form.Curry => "curry",
    Form.Soup => "soup"
};

string ConvertIngredientToString(Ingredient i) => i switch
{
    Ingredient.Mushrooms => "mushrooms",
    Ingredient.Carrots => "carrots",
    Ingredient.Chicken => "chicken",
    Ingredient.Potatoes => "potatoes"
};

string ConvertSeasoningToString(Seasoning s) => s switch
{
    Seasoning.Garlic => "garlic",
    Seasoning.Cayenne => "cayenne",
    Seasoning.Ginger => "ginger"
};

enum Form { Soup, Stew, Curry }
enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes }
enum Seasoning { Garlic, Cayenne, Ginger }