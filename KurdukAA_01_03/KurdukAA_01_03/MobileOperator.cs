using System;

namespace KurdukAA_01_03
{
    public class MobileOperator
    {
        private string name;
        private double costPerMinute;
        private double coverageArea;
        // Свойство для названия оператора
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // Свойство для стоимости минуты с проверкой значения
        public double CostPerMinute
        {
            get { return costPerMinute; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Стоимость минуты должна быть больше 0");
                }
                costPerMinute = value;
            }
        }
        // Свойство для площади покрытия с проверкой значения
        public double CoverageArea
        {
            get { return coverageArea; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Площадь покрытия не может быть отрицательной");
                }
                coverageArea = value;
            }
        }
        // Конструктор без параметров: задаёт значения по умолчанию
        public MobileOperator()
        {
            name = "";
            costPerMinute = 1;
            coverageArea = 0;
        }
        // Конструктор с параметрами: значения проходят проверку в свойствах
        public MobileOperator(string name, double costPerMinute, double coverageArea)
        {
            Name = name;
            CostPerMinute = costPerMinute;
            CoverageArea = coverageArea;
        }
        // Расчёт качества Q = 100 * площадь покрытия / стоимость 1 минуты
        // virtual позволяет классу-потомку перекрыть метод
        public virtual double CalculateQuality()
        {
            return 100 * coverageArea / costPerMinute;
        }
        // Ввод информации об объекте: принимает текст из полей и переводит в числа
        public void Input(string nameText, string costText, string areaText)
        {
            Name = nameText;
            CostPerMinute = double.Parse(costText);
            CoverageArea = double.Parse(areaText);
        }
        // Вывод информации об объекте: возвращает строку для показа на форме
        public virtual string Show()
        {
            return "Оператор: " + Name + Environment.NewLine + "Стоимость 1 минуты: " + CostPerMinute + Environment.NewLine + "Площадь покрытия: " + CoverageArea + Environment.NewLine + "Качество Q: " + CalculateQuality().ToString("F2");
        }
    }
}