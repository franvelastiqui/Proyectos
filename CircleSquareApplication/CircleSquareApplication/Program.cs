using System;

namespace CircleInSquareApplication
{
    class Program
    {
        public struct CircleInSquare : IPattern
        {
            public double Radius;
            public char InnerSymbol;
            public char OuterSymbol;

            public CircleInSquare(double radius, char innerSymbol, char outerSymbol)
            {
                Radius = radius;
                InnerSymbol = innerSymbol;
                OuterSymbol = outerSymbol;
            }

            public void WriteMemberValuesToScreen()
            {
                Console.WriteLine($"Radius = {Radius}, InnerSymbol = '{InnerSymbol}', OuterSymbol = '{OuterSymbol}'");

            }



            public void Draw()
            {
                double radiusInner = Radius - 0.5;
                double radiusOuter = Radius + 0.5;

                Console.WriteLine();

                for (double y = Radius; y >= -Radius; --y)
                {
                    for (double x = -Radius; x < radiusOuter; x += 0.5)
                    {
                        double value = x * x + y * y;

                        if (value >= radiusInner * radiusInner)
                        {
                            Console.Write(OuterSymbol);
                            System.Threading.Thread.Sleep(50);
                        }
                        else
                        {
                            Console.Write(InnerSymbol);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
        public interface IPattern
        {
            void Draw();
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the radius of the circle");

            double radius = Convert.ToDouble(Console.ReadLine());

            CircleInSquare circleInSquare1; //= new CircleInSquare(radius,'0','1');

            circleInSquare1.Radius = radius;
            circleInSquare1.InnerSymbol = '@';
            circleInSquare1.OuterSymbol = '-';
            CircleInSquare circleInSquare2; //= new CircleInSquare(radius, '&', '%');

            circleInSquare2.Radius = radius;
            circleInSquare2.InnerSymbol = '0';
            circleInSquare2.OuterSymbol = '1';

            CircleInSquare circleInSquare3; //= new CircleInSquare(radius, '^', '$');
            circleInSquare3.Radius = radius;
            circleInSquare3.InnerSymbol = '0';
            circleInSquare3.OuterSymbol = '1';

            CircleInSquare circleInSquare4; //= new CircleInSquare(radius, '^', '$');
            circleInSquare4.Radius = radius;
            circleInSquare4.InnerSymbol = '0';
            circleInSquare4.OuterSymbol = '1';

            CircleInSquare[] circleInSquares = new CircleInSquare[4];

            circleInSquares[0] = circleInSquare1;
            circleInSquares[1] = circleInSquare2;
            circleInSquares[1].Radius = radius / 2;
            circleInSquares[2] = circleInSquare3;
            circleInSquares[2].Radius = radius / 3;
            circleInSquares[3] = circleInSquare4;
            circleInSquares[3].Radius = radius / 4;

            foreach (CircleInSquare circleInSquare in circleInSquares)
            {
                circleInSquare.Draw();
            }

            Console.ReadKey();

        }


    }
}