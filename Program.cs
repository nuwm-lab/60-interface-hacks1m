using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    class Program
    {
        static void Main(string[] args)
        {
            // Демонстрація роботи двовимірної та тривимірної матриць
            Console.WriteLine("2D Matrix (3x3) - filled with random values:");
            var m2 = new Matrix2D();
            m2.FillRandom(0, 99);
            Console.WriteLine(m2);
            Console.WriteLine($"Minimum element in 2D matrix: {m2.GetMin()}\n");

            Console.WriteLine("3D Matrix (3x3x3) - filled with random values:");
            var m3 = new Matrix3D();
            m3.FillRandom(0, 99);
            Console.WriteLine(m3);
            Console.WriteLine($"Minimum element in 3D matrix: {m3.GetMin()}\n");

            // NOTE: The ReadFromConsole() methods exist for both classes.
            // To use them interactively, uncomment the following lines:
            // m2.ReadFromConsole();
            // m3.ReadFromConsole();
        }
    }

    // Двовимірна матриця 3x3
    class Matrix2D
    {
        protected int[,] A = new int[3, 3];

        // Зчитування з клавіатури
        public virtual void ReadFromConsole()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    while (true)
                    {
                        Console.Write($"Enter element A[{i},{j}]: ");
                        string? s = Console.ReadLine();
                        if (int.TryParse(s, out int val))
                        {
                            A[i, j] = val;
                            break;
                        }
                        Console.WriteLine("Invalid integer, please try again.");
                    }
                }
            }
        }

        // Заповнити випадковими числами в діапазонi [min, max]
        public virtual void FillRandom(int min = 0, int max = 100)
        {
            var rnd = new Random();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    A[i, j] = rnd.Next(min, max + 1);
        }

        // Знайти мінімальний елемент
        public virtual int GetMin()
        {
            int min = A[0, 0];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (A[i, j] < min) min = A[i, j];
            return min;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sb.Append(A[i, j].ToString().PadLeft(4));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }

    // Тривимірна матриця 3x3x3, похідна від Matrix2D
    class Matrix3D : Matrix2D
    {
        private int[,,] B = new int[3, 3, 3];

        public override void ReadFromConsole()
        {
            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine($"Layer {k}:");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        while (true)
                        {
                            Console.Write($"Enter element A[{k},{i},{j}]: ");
                            string? s = Console.ReadLine();
                            if (int.TryParse(s, out int val))
                            {
                                B[k, i, j] = val;
                                break;
                            }
                            Console.WriteLine("Invalid integer, please try again.");
                        }
                    }
                }
            }
        }

        public override void FillRandom(int min = 0, int max = 100)
        {
            var rnd = new Random();
            for (int k = 0; k < 3; k++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        B[k, i, j] = rnd.Next(min, max + 1);
        }

        public override int GetMin()
        {
            int min = B[0, 0, 0];
            for (int k = 0; k < 3; k++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (B[k, i, j] < min) min = B[k, i, j];
            return min;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            for (int k = 0; k < 3; k++)
            {
                sb.AppendLine($"Layer {k}:");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sb.Append(B[k, i, j].ToString().PadLeft(4));
                    }
                    sb.AppendLine();
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
