
using System;
using System.Threading.Tasks;

class Program
{
	static readonly string[] AsciiArts = new[]
	{
		@"  .-""""""-.",
		@" (o o)  ",
		@"/  V  ",
		@"/--m--\",
		@"  (o.o)",
		@"  ( : )",
		@"  ( '_' )",
		@"  (='.'=)",
		@"  ( '_' )",
		@"  (o.o)"
	};

	static async Task Main(string[] args)
	{
		await MonkeyHelper.InitializeAsync();
		bool running = true;
		var rand = new Random();
		while (running)
		{
			Console.Clear();
			// 무작위 ASCII 아트 표시
			Console.WriteLine(AsciiArts[rand.Next(AsciiArts.Length)]);
			Console.WriteLine("============================");
			Console.WriteLine(" Monkey Console App Menu ");
			Console.WriteLine("============================");
			Console.WriteLine("1. 모든 원숭이 나열");
			Console.WriteLine("2. 이름으로 특정 원숭이의 세부 정보 가져오기");
			Console.WriteLine("3. 무작위 원숭이 가져오기");
			Console.WriteLine("4. 앱 종료");
			Console.Write("메뉴를 선택하세요: ");
			var input = Console.ReadLine();
			Console.WriteLine();
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
					running = false;
					Console.WriteLine("앱을 종료합니다.");
					break;
				default:
					Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
					break;
			}
			if (running)
			{
				Console.WriteLine("\n아무 키나 누르면 메뉴로 돌아갑니다...");
				Console.ReadKey();
			}
		}
	}

	static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		Console.WriteLine("\n[모든 원숭이 목록]");
		foreach (var m in monkeys)
		{
			Console.WriteLine($"- {m.Name} ({m.Location}) - 개체수: {m.Population}");
		}
	}

	static void GetMonkeyByName()
	{
		Console.Write("원숭이 이름을 입력하세요: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.GetMonkeyByName(name);
		if (monkey != null)
		{
			Console.WriteLine($"\n이름: {monkey.Name}\n위치: {monkey.Location}\n개체수: {monkey.Population}\n설명: {monkey.Details}\n이미지: {monkey.Image}");
		}
		else
		{
			Console.WriteLine("해당 이름의 원숭이를 찾을 수 없습니다.");
		}
	}

	static void GetRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		if (monkey != null)
		{
			Console.WriteLine($"\n[무작위 원숭이]");
			Console.WriteLine($"이름: {monkey.Name}\n위치: {monkey.Location}\n개체수: {monkey.Population}\n설명: {monkey.Details}\n이미지: {monkey.Image}");
			Console.WriteLine($"(무작위 원숭이 선택 횟수: {MonkeyHelper.GetRandomMonkeyAccessCount()})");
		}
		else
		{
			Console.WriteLine("원숭이 데이터가 없습니다.");
		}
	}
}
