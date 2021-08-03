using System;

namespace App1
{
  class Program
  {
    static void Main(string[] args)
    {

      var poll = pollUser();
      printPoll(poll);
      //Console.ReadKey();

    }

    private static void printPoll(Tuple<string, string, int, int, string[], int, string[]> poll)
    {
      Console.WriteLine("Ваше полное имя: " + poll.Item1 + " " + poll.Item2);
      Console.WriteLine("Ваш возраст: " + poll.Item3);
      if (poll.Item4 == 0)
        Console.WriteLine("У Вас нет питомцев.");
      else
      {
        Console.Write("У Вас " + poll.Item4);
        switch (poll.Item4)
        {
          case 1:
            Console.WriteLine(" питомец.");
            break;
          case 2:
          case 3:
          case 4:
            Console.WriteLine(" питомца.");
            break;
          default:
            Console.WriteLine(" питомцев.");
            break;
        }
        Console.WriteLine("Их клички:");
        for (int i = 0; i < poll.Item4; i++)
          Console.Write("'" + poll.Item5[i] + "' ");
      }
      if (poll.Item6 != 0)
      {
        Console.WriteLine("\nВаши любимые цвета: ");
        for (int i = 0; i < poll.Item6; i++)
          Console.Write("'" + poll.Item7[i] + "' ");
      }
      else
      {
        Console.WriteLine("\nУ Вас нет любимых цветов.");
      }
    }

    static Tuple<string, string, int, int, string[], int, string[]> pollUser()
    {
      int petsNum = 0;
      string[] petNames = { };
      Console.WriteLine("Пройдите небольшой опрос.");
      Console.Write("\nВведите Ваше имя: ");
      string firstName = Console.ReadLine();
      Console.Write("Укажите Вашу фамилию: ");
      string lastName = Console.ReadLine();
      Console.Write("Укажите свой возраст: ");
      int age = checkInput();
      Console.Write("У Вас есть питомец? Введите 'Да' или 'Нет': ");
      bool hasPets = checkPets();
      if (hasPets)
      {
        Console.Write("Сколько у Вас питомцев? ");
        petsNum = checkInput();
        if (petsNum != 0)
        {
          Console.WriteLine("Как зовут Ваших питомцев? Введите их клички: ");
          petNames = getArray(petsNum);
        }
      }

      Console.Write("Сколько у Вас любимых цветов? ");
      int colorsNum = checkInput();
      if (colorsNum != 0)
        Console.WriteLine("Перечислите Ваши любимые цвета: ");
      string[] favcolors = getArray(colorsNum);
      Console.WriteLine("Приятно познакомиться, " + firstName);
      Console.WriteLine("Давайте подведём итог нашему общениию. ");
      var pollResult = Tuple.Create(firstName, lastName, age, petsNum, petNames, colorsNum, favcolors);
      //Console.WriteLine(pollResult);
      //printPoll(pollResult);
      return pollResult;
    }
    static string[] getArray(int length)
    {
      string[] arr = new string[length];
      for (int i = 0; i < length; i++)
        arr[i] = Console.ReadLine();
      //string input = Console.ReadLine();
      //return input.Split(" ");
      return arr;

    }
    static bool checkPets()
    {
      while (true)
      {
        string input = Console.ReadLine();
        switch (input)
        {
          case "Да":
          case "да":
          case "да ":
          case "Да ":
            return true;
          case "Нет":
          case "Нет ":
          case "нет":
          case "нет ":
            return false;
          default:
            Console.Write("Ответьте только 'Да' или 'Нет': ");
            break;
        }
      }


    }
    static int checkInput()
    {
      bool check = false;
      string input;
      int i = 0;
      while (!check)
      {
        input = Console.ReadLine();
        check = checkInt(input);
        if (!check)
          Console.Write("Нужно ввести целое число. Попробуйте ещё раз: ");
        else
        {
          i = int.Parse(input);
          break;
        }
      }

      return i;
    }
    static bool checkInt(string input)
    //static (bool b, int num) checkInt(string input)
    {
      if (int.TryParse(input, out _))
        return true;

      else
        return false;
    }
  }
}
