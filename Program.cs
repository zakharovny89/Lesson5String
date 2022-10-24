//1.Visual studio - Console Application
//2.Считать строку текста из консоли (продвинутое задание: из файла).
//Строка содержит буквы латинского алфавита, знаки препинания и цифры. 
//3. Реализовать меню выбора действий:
//-Найти слова, содержащие максимальное количество цифр.
//- Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.
//- Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять».
//- Вывести на экран сначала вопросительные, а затем восклицательные предложения.
//- Вывести на экран только предложения, не содержащие запятых.
//- Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.
//4. Приложение не должно падать ни при каких условиях.

using Lesson5String;

string path = @"C:\Users\Николай\source\repos\Lesson5String\bin\Text.txt";
string text = File.ReadAllText(path);
Actions action = new Actions(text);

Console.WriteLine("Перечень слов:");
foreach (string word in action.words)
{
    Console.WriteLine(word);
}
Console.WriteLine();

Console.WriteLine("Cлова, содержащие максимальное количество цифр:");
action.ResiveWordsWithMaxNumbers();
Console.WriteLine();

Console.WriteLine("Cамое длинное слово:");
action.LongestWord();
Console.WriteLine($"Оно повторяется {action.longestWordCount} раз.");
Console.WriteLine();

Console.WriteLine("Перечень слов, где цифры от 0 до 9 заменены на слова «zero», «one», …, «nine»:");
action.ChangeWords();
Console.WriteLine();

Console.WriteLine("Вопросительные предложения:");
action.InterrogativeSentences();
Console.WriteLine();

Console.WriteLine("Восклицательные предложения:");
action.ExclamatorySentences();
Console.WriteLine();

Console.WriteLine("Предложения без запятых:");
action.SuggestionsWithoutCommas();
Console.WriteLine();

Console.WriteLine("Слова, начинающиеся и заканчивающиеся на одну и ту же букву:");
action.WordsWithTherSameLetters();
Console.WriteLine();