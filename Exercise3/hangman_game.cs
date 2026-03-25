using System;
public enum GuessResult
{
    Correct = 0,
    Incorrect = 1,
    Duplicate = 2
}
public class HangmanService
{
    private string[] _wordList = { "Softsquaregroup", "Traveller", "Programming", "Computer", "Algorithm", "Database", "Framework", "Interface", "Project", "Internship" };
    private string _currentWord = "";
    private char[] _displayWord = Array.Empty<char>();
    private bool[] _guessedChars = new bool[26];
    private int _remainingTries = 10;
    private Random _random = new Random();

    public void Restart()
    {
        _currentWord = _wordList[_random.Next(_wordList.Length)].ToUpper();
        _displayWord = new char[_currentWord.Length];
        _guessedChars = new bool[26];
        _remainingTries = 10;

        for (int i = 0; i < _displayWord.Length; i++)
            _displayWord[i] = '_';
    }

    public string GetDisplay()
    {
        return string.Join(" ", _displayWord);
    }

    // จำนวนครั้งที่เหลือ
    public int GetRemainingTry()
    {
        return _remainingTries;
    }

    // ตรวจสอบตัวอักษรที่ผู้เล่นกด
    public GuessResult Input(char c)
    {
        c = char.ToUpper(c);

        if (!char.IsLetter(c))
            return GuessResult.Incorrect;

        int index = c - 'A';

        // ตรวจสอบว่าเคยกดไปแล้วหรือยัง
        if (_guessedChars[index])
            return GuessResult.Duplicate;

        _guessedChars[index] = true;

        // ตรวจสอบว่าตัวอักษรอยู่ในคำหรือไม่
        bool found = false;
        for (int i = 0; i < _currentWord.Length; i++)
        {
            if (_currentWord[i] == c)
            {
                _displayWord[i] = c;
                found = true;
            }
        }

        if (found)
            return GuessResult.Correct;

        _remainingTries--;
        return GuessResult.Incorrect;
    }

    // ตรวจสอบว่าชนะแล้วหรือยัง
    public bool IsWin()
    {
        return !Array.Exists(_displayWord, ch => ch == '_');
    }

    // ตรวจสอบว่าแพ้แล้วหรือยัง
    public bool IsLose()
    {
        return _remainingTries <= 0;
    }
}
class Program
{
    static void Main(string[] args)
    {
        HangmanService hangman = new HangmanService();
        hangman.Restart();

        Console.WriteLine("=== HANGMAN GAME ===");
        Console.WriteLine("(กด Enter โดยไม่ระบุตัวอักษร เพื่อเริ่มเกมใหม่)\n");

        while (true)
        {
            Console.WriteLine($"\nคำศัพท์: {hangman.GetDisplay()}");
            Console.WriteLine($"Remaining tries: {hangman.GetRemainingTry()}");
            Console.Write("Please enter character: ");

            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("\n--- เริ่มเกมใหม่ ---");
                hangman.Restart();
                continue;
            }

            char c = input[0];
            GuessResult result = hangman.Input(c);

            switch (result)
            {
                case GuessResult.Correct:
                    Console.WriteLine($"\nคำศัพท์: {hangman.GetDisplay()}");
                    if (hangman.IsWin())
                    {
                        Console.WriteLine("\nCongratulation, you're win!");
                        Console.Write("\nเล่นอีกครั้ง? (y/n): ");
                        string? again = Console.ReadLine();
                        if (again?.ToLower() == "y")
                        {
                            hangman.Restart();
                            Console.WriteLine("\n--- เริ่มเกมใหม่ ---");
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;

                case GuessResult.Incorrect:
                    Console.WriteLine($"Sorry, you're wrong. Remaining {hangman.GetRemainingTry()}");
                    if (hangman.IsLose())
                    {
                        Console.WriteLine("\nGame Over! You lose.");
                        Console.Write("\nเล่นอีกครั้ง? (y/n): ");
                        string? again = Console.ReadLine();
                        if (again?.ToLower() == "y")
                        {
                            hangman.Restart();
                            Console.WriteLine("\n--- เริ่มเกมใหม่ ---");
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;

                case GuessResult.Duplicate:
                    Console.WriteLine("You have already tried this character.");
                    break;
            }
        }
    }
}