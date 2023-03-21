using System;
using System.IO;
using System.Text.Json;

namespace L3
{
    class Interval
    {
        public int leftRange { get; set; }
        public int rightRange { get; set; }

        public Interval(int leftRange, int rightRange)
        {
            this.leftRange = leftRange;
            this.rightRange = rightRange;
        }
        public void intervalLength()
        {
            int length = rightRange - leftRange;
            Console.WriteLine("Довжина інтервалу: " + length);
        }
        public void stepLeft(int number1)
        {
            leftRange -= number1;
            rightRange -= number1;
            Console.WriteLine($"Значення після зміщення вліво на {number1}: {leftRange} {rightRange}");
        }
        public void stepRight(int number2)
        {
            leftRange += number2;
            rightRange += number2;
            Console.WriteLine($"Значення після зміщення вправо на {number2}: {leftRange} {rightRange}");
        }
        public void Compression(double number3)
        {
            double compression = (rightRange - leftRange) / number3;
            Console.WriteLine($"Інтервал після стягнення на {number3}: {compression}");
        }
        public void Stretch(double number4)
        {
            double stretch = (rightRange - leftRange) * number4;
            Console.WriteLine($"Інтервал після розтягу на {number4}: {stretch}");
        }
        public int Comparee(Interval otherInterval)
        {
            if (this.leftRange < otherInterval.leftRange)
                return -1;
            else if (this.leftRange > otherInterval.leftRange)
                return 1;
            else return 0;
        }
        public void Suma(Interval otherInterval)
        {
            int l = leftRange + otherInterval.leftRange;
            int r = rightRange + otherInterval.rightRange;
            Console.WriteLine($"Сума: [{l}, {r}]");
        }
        public void Riz(Interval otherInterval)
        {
            int l = otherInterval.leftRange - leftRange;
            int r = otherInterval.rightRange - rightRange;
            Console.WriteLine($"Різниця: [{l}, {r}]");
        }
        class Program
        {
            static void Main(string[] args)
            {
                Interval interval1 = new Interval(5, 10);
                interval1.intervalLength();
                interval1.stepLeft(2);
                interval1.stepRight(4);
                interval1.Compression(3);
                interval1.Stretch(10);
                Interval interval2 = new Interval(15, 25);
                Console.WriteLine("-------------");
                interval2.intervalLength();
                interval2.stepLeft(8);
                interval2.stepRight(14);
                interval2.Compression(21);
                interval2.Stretch(110);
                Console.WriteLine("-------------");
                Console.WriteLine("-1 - Другий більший за перший, 1 - Другий менший за перший, 0 - Інше :");
                int result = interval1.Comparee(interval2);
                Console.WriteLine(result);
                interval1.Suma(interval2);
                interval1.Riz(interval2);

                //string fileName = "Interval1.json";
                //string json = JsonSerializer.Serialize(interval1);
                //File.WriteAllText(fileName, json);

                string path = @"C:\Users\nasti\OneDrive\Документы\Универ\КПИ 1 курс\Прога\Homework2.3.1\bin\Debug\net6.0\Interval1.json";
                string jsontext = File.ReadAllText(path);

                void Save(object i1)
                {
                    File.WriteAllText(path, JsonSerializer.Serialize(i1));
                }
                Interval Load()
                {
                    return JsonSerializer.Deserialize<Interval>(jsontext);
                }
                Save(interval1);
                interval1 = Load();
            }
        }


    }
}