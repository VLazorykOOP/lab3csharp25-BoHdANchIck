namespace Lab_3_Daneliuk
{
    internal class Program
    {
        abstract class Test
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }

            public Test(string name, DateTime date)
            {
                Name = name;
                Date = date;
            }

            public abstract void Show(); 
        }

        class Exam : Test
        {
            public string Subject { get; set; }
            public int Score { get; set; }

            public Exam(string name, DateTime date, string subject, int score)
                : base(name, date)
            {
                Subject = subject;
                Score = score;
            }

            public override void Show()
            {
                Console.WriteLine($"Exam: {Name}, Date: {Date.ToShortDateString()}, Subject: {Subject}, Score: {Score}");
            }
        }

        class FinalExam : Exam
        {
            public string DifficultyLevel { get; set; }

            public FinalExam(string name, DateTime date, string subject, int score, string difficultyLevel)
                : base(name, date, subject, score)
            {
                DifficultyLevel = difficultyLevel;
            }

            public override void Show()
            {
                Console.WriteLine($"Final Exam: {Name}, Date: {Date.ToShortDateString()}, Subject: {Subject}, Score: {Score}, Difficulty: {DifficultyLevel}");
            }
        }

        class Trial : Test
        {
            public string TrialType { get; set; }

            public Trial(string name, DateTime date, string trialType)
                : base(name, date)
            {
                TrialType = trialType;
            }

            public override void Show()
            {
                Console.WriteLine($"Trial: {Name}, Date: {Date.ToShortDateString()}, Type: {TrialType}");
            }
        }
        static void Main(string[] args)
        {
            Task1();
            Console.WriteLine();
            Console.ReadKey();
            Task2();
            Console.ReadKey();
        }

        static void Task1() 
        {
            Console.WriteLine("#Task_1");
            Random random = new Random();
            int n;
            Console.Write("Enter the number of trapezes: ");
            n = int.Parse(Console.ReadLine());

            Trapeze[] trapezes = new Trapeze[n];

            for (int i = 0; i < n; i++)
            {
                int a = random.Next(1, 20);
                int b = random.Next(1, 20);
                int h = random.Next(1, 20);
                int color = random.Next(1, 256);
                trapezes[i] = new Trapeze(a, b, h, color);
            }

            Console.WriteLine("\nTrapezes Information:");
            int squareCount = 0;
            foreach (var trap in trapezes)
            {
                trap.PrintInfo();
                Console.WriteLine($"Area: {trap.Area():F2}");
                Console.WriteLine($"Perimeter: {trap.Perimeter():F2}");
                Console.WriteLine(trap.IsSquare ? "This trapeze is a square!" : "This trapeze is not a square.");
                Console.WriteLine();

                if (trap.IsSquare)
                {
                    squareCount++;
                }
            }

            Console.WriteLine($"Total number of squares: {squareCount}");
        }

        static void Task2()
        {
            Console.WriteLine("#Task_2");
            Test[] tests = new Test[]
            {
                new Exam("Math Exam", new DateTime(2025, 5, 20), "Math", 85),
                new FinalExam("Graduation Exam", new DateTime(2025, 6, 10), "Physics", 90, "High"),
                new Trial("Driving Test", new DateTime(2025, 3, 15), "Practical"),
                new Exam("History Exam", new DateTime(2025, 5, 18), "History", 78),
                new FinalExam("Final Chemistry", new DateTime(2025, 6, 5), "Chemistry", 88, "Medium")
            };

            Console.WriteLine("All Tests:");
            foreach (var test in tests)
            {
                test.Show();
            }

            Array.Sort(tests, (t1, t2) => t1.Date.CompareTo(t2.Date));

            Console.WriteLine("\nSorted by Date:");
            foreach (var test in tests)
            {
                test.Show();
            }
        }
    }
}
