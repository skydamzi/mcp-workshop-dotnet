using System.Collections.Generic;

namespace MyMonkeyApp;

/// <summary>
/// Monkey 데이터 관리용 헬퍼 클래스
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> monkeys = new()
    {
        new Monkey { Name = "일본원숭이", Location = "일본", Population = 100000 },
        new Monkey { Name = "코주부원숭이", Location = "보르네오", Population = 7000 },
        new Monkey { Name = "금사원숭이", Location = "중국", Population = 15000 }
    };

    private static int randomPickCount = 0;

    /// <summary>
    /// 모든 원숭이 목록을 반환합니다.
    /// </summary>
    public static List<Monkey> GetMonkeys() => monkeys;

    /// <summary>
    /// 이름으로 특정 원숭이를 반환합니다. 없으면 null 반환
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        return monkeys.Find(m => m.Name == name);
    }

    /// <summary>
    /// 무작위 원숭이를 반환하고, 선택 횟수를 증가시킵니다.
    /// </summary>
    public static Monkey GetRandomMonkey()
    {
        var rand = new Random();
        randomPickCount++;
        return monkeys[rand.Next(monkeys.Count)];
    }

    /// <summary>
    /// 무작위 원숭이 선택 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomPickCount() => randomPickCount;
}
