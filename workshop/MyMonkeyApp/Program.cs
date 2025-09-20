using MyMonkeyApp;

/// <summary>
/// MonkeyHelper를 활용한 메뉴 기반 콘솔 앱
/// </summary>
class Program
{
    static readonly string[] asciiArts = new[]
    {
        @"  (\__/)
  (•ㅅ•)  \n  / 　 づ",
        @"   ／￣￣＼\n  ( ･ω･ )\n  ／ >　　づ",
        @"   ⠀⢀⣠⣤⣤⣀\n   ⠀⣾⣿⣿⣿⣿⣷\n   ⠀⠉⠉⠉⠉⠉"
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            ShowRandomAsciiArt();
            Console.WriteLine("==== Monkey 메뉴 ====");
            Console.WriteLine("1. 모든 원숭이 나열");
            Console.WriteLine("2. 이름으로 원숭이 세부 정보");
            Console.WriteLine("3. 무작위 원숭이");
            Console.WriteLine("4. 종료");
            Console.Write("메뉴 선택: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListAllMonkeys();
                    break;
                case "2":
                    GetMonkeyByName();
                    break;
                case "3":
                    GetRandomMonkey();
                    break;
                case "4":
                    Console.WriteLine("앱을 종료합니다.");
                    return;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
            Console.WriteLine("계속하려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }

    static void ShowRandomAsciiArt()
    {
        var rand = new Random();
        var art = asciiArts[rand.Next(asciiArts.Length)];
        Console.WriteLine(art);
        Console.WriteLine();
    }

    static void ListAllMonkeys()
    {
        var monkeys = MonkeyHelper.GetMonkeys();
        Console.WriteLine("| 이름           | 서식지   | 개체수     |");
        Console.WriteLine("|---------------|----------|-----------|");
        foreach (var monkey in monkeys)
        {
            Console.WriteLine($"| {monkey.Name,-13} | {monkey.Location,-8} | {monkey.Population,9} |");
        }
    }

    static void GetMonkeyByName()
    {
        Console.Write("원숭이 이름을 입력하세요: ");
        var name = Console.ReadLine();
        var monkey = MonkeyHelper.GetMonkeyByName(name ?? "");
        if (monkey != null)
        {
            Console.WriteLine($"이름: {monkey.Name}\n서식지: {monkey.Location}\n개체수: {monkey.Population}");
        }
        else
        {
            Console.WriteLine("해당 이름의 원숭이가 없습니다.");
        }
    }

    static void GetRandomMonkey()
    {
        var monkey = MonkeyHelper.GetRandomMonkey();
        Console.WriteLine($"무작위로 선택된 원숭이: {monkey.Name}\n서식지: {monkey.Location}\n개체수: {monkey.Population}");
        Console.WriteLine($"무작위 선택 횟수: {MonkeyHelper.GetRandomPickCount()}");
    }
}
