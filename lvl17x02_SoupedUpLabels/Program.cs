(Form form, Ingredient ingredient, Seasoning seasoning) soup = (Form.Stew, Ingredient.Mushrooms, Seasoning.Garlic);

Console.WriteLine($"{ConvertSeasoningToString(soup.seasoning)} {ConvertIngredientToString(soup.ingredient)} {ConvertFormToString(soup.form)}");


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