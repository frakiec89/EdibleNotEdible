// подготовка 
string[] edibleObject = ReadList(true);
string[] notEdibleObject = ReadList(false);


int raund = 0;  // каждый ответ  - это  раунд

int pointUser = 0; //для счета 
int pointPK = 0;


// старт 
Console.WriteLine("Игра съедобно/не съедобно!");
Console.WriteLine("Инструкция:");
PrintListCommand();


while (true) // цикл - раунды 
{
    Console.WriteLine("Введите команду:");

	switch (Console.ReadLine())
	{
		case "help": PrintHelp(); break; 
		case "total": PrintTotal(); break; 
		case "go": 
			GoGame(); 
			GoGame();
			break;  // игра за  пк  и за  человка 
		case "list": PrintListCommand(); break; 
		case "clear": Console.Clear(); break; 

		default: Console.WriteLine("Не понятно ( ");
			break;
	}
}

// правила
void PrintHelp()
{

	string message = "игра проста \n" +
		"ведущий  называет предметы каждому  игроку по  очереди \n" +
		"игрок  должен ответить на  вопрос съедобный этот объект или  нет \n" +
		"если предмет съедобный надо  написать  \"yes\" \n" +
		"если предмет не съедобный надо написать  \"no\" \n" +
		"компьютер будет отвечать случайно";

	Console.WriteLine(message);
}

// счет игры
void PrintTotal()
{
	Console.WriteLine($"Общий счет игры: человек: {pointUser} - компьютер: {pointPK}");
}


// раунд 
void GoGame() 
{
	raund++;
	if(raund%2==0)
	{
		RaundUser();
	}
    else
	{
		RaundPK();
    }
}

// игра  за пк 
void RaundPK()
{
    string objName = GetRandomObject();
	Console.WriteLine("Играет компьютер");
    Console.WriteLine($"{objName}: yes/no?");

	bool otvetPK = GetRandomTrue_False();

	Console.WriteLine(GetStringTrueFalse(otvetPK));
	
	bool expected = IsEdibleObject(objName);

    if (otvetPK == expected)
    {
		Console.WriteLine("Это верно ) ");
        pointPK++;
    }
    else
    {
        Console.WriteLine("Это не верно (");
    }
}


// игра  за  человека
void RaundUser()
{
	string objName = GetRandomObject();
	Console.WriteLine("Играет человек");
	Console.WriteLine($"{objName}: yes/no?");
	
	bool otvetUser = IsTrue_Folse(Console.ReadLine());
	
	bool expected = IsEdibleObject(objName);

	if (otvetUser == expected)
    {
        Console.WriteLine("Это верно )");
        pointUser++;
    }
    else
    {
		Console.WriteLine("Это не верно (");
    }
}
// список  команд
void PrintListCommand()
{
    Console.WriteLine("Посмотреть правила: \"help\"");
    Console.WriteLine("Посмотреть счет: \"total\"");
    Console.WriteLine("Играть: \"go\"");
    Console.WriteLine("список команд: \"list\"");
    Console.WriteLine("Очистить  консоль: \"clear\"");
}


// случайный  объект  - съедобный  или  нет 
string GetRandomObject ()
{
	if (GetRandomTrue_False())
	{
		return GetEdibleObject();
	}
	else
	{
		return GetNotEdibleObject();
	}
}

// находит случайный съедобный объект
string GetEdibleObject ()
{
	Random random = new Random();
	return edibleObject[random.Next(edibleObject.Length)];
}


// находит случайный не съедобный предмет 
string GetNotEdibleObject()
{
    Random random = new Random();
	return notEdibleObject[random.Next(notEdibleObject.Length)];
}

//Определяет съедобный ли  объект - true  если съедобен
bool IsEdibleObject (string objectName)
{
	foreach ( string  obj  in edibleObject)
	{
		if(objectName == obj)
			return true;
	}

    foreach (string obj in notEdibleObject)
    {
        if (objectName == obj)
            return false;
    }

	Console.WriteLine("Объект не найден");  // не самая  хорошая строчка  - потом  переделаем 
	return false;
}



// случайное  да  или  нет  - пригодиться
bool GetRandomTrue_False()
{
    Random random = new Random();
    if (random.Next(2) == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}


// из строки  в  bool -например -  yes - это true
bool IsTrue_Folse (string otvet)
{
	if(otvet == "yes")
		return true;	
	if(otvet =="no")
		return false;

    Console.WriteLine("будьте добры всегда отвечать только yes и no!");  // не самая  хорошая строчка  - потом  переделаем 
    return false;
}


// из  bool в строку  - например  true - это  уes 
string GetStringTrueFalse(bool otvetPK)
{
    if (otvetPK == true) { return "yes"; }
    else { return "no"; }
}



// если true - то  съедобные
string[] ReadList(bool variant )
{
	if (variant)
	{
        return  new string[] { "молоко", "яблоко", "печенье" };
    }
	else
	{
		return new string[] { "тумба", "кактус", "книга" };
    }
}

