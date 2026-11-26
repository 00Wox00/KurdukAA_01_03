using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurdukAA_01_03
{
    public class MobileOperatorWithFee : MobileOperator
    {
        private bool hasConnectionFee;
        // Свойство для признака платы за соединение
        public bool HasConnectionFee
        {
            get { return hasConnectionFee; }
            set { hasConnectionFee = value; }
        }
        // Конструктор без параметров: вызывает конструктор базового класса
        public MobileOperatorWithFee() : base()
        {
            hasConnectionFee = false;
        }
        // Конструктор с параметрами: базовые поля передаются в конструктор базового класса
        public MobileOperatorWithFee(string name, double costPerMinute, double coverageArea, bool hasConnectionFee) : base(name, costPerMinute, coverageArea)
        {
            this.hasConnectionFee = hasConnectionFee;
        }
        // Qp: перекрывает расчёт качества базового класса и считает по новой формуле
        public override double CalculateQuality()
        {
            double q = base.CalculateQuality();

            if (hasConnectionFee)
            {
                return 0.5 * q;
            }
            return 2.5 * q;
        }
        // Ввод информации: базовые поля вводятся методом базового класса, затем свойство P
        public void Input(string nameText, string costText, string areaText, bool feeValue)
        {
            base.Input(nameText, costText, areaText);
            hasConnectionFee = feeValue;
        }

        // Вывод информации: базовые поля плюс свойство P
        public override string Show()
        {
            string feeText;
            if (hasConnectionFee)
            {
                feeText = "есть";
            }
            else
            {
                feeText = "нет";
            }
            return base.Show() + Environment.NewLine + "Плата за соединение: " + feeText;
        }
    }
}