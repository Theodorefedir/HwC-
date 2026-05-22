using System.ComponentModel.DataAnnotations;

namespace OverloadOperatorsHw
{
    internal class Program
    {
        class Square {
            private int a;

            public int A
            {
                get { return a; }
                set
                {
                    if (value > 0)
                    {
                        a = value;
                    }
                    else
                    {
                        a = 10;
                    }
                }
            }

            public Square() {
                A = 10;
            }
            public Square(int a)
            {
                A = a;
            }

            public override string ToString()
            {
                return $"A = {A}";
            }
            public static Square operator ++(Square sq) {
                sq.A++;
                return sq;
            }
            public static Square operator --(Square sq)
            {
                sq.A--;
                return sq;
            }
            public static Square operator +(Square sq, int n) { 
                Square res = new Square();
                res.A = sq.A + Math.Abs(n);
                return res;
            }
            public static Square operator -(Square sq, int n)
            {
                Square res = new Square();
                res.A = Math.Abs(sq.A - n);
                if (res.A > 0)
                {
                    return res;
                }
                else { 
                    return sq;
                }
            }
            public static Square operator *(Square sq, int n)
            {
                Square res = new Square();
                res.A = sq.A * Math.Abs(n);
                return res;
            }
            public static Square operator /(Square sq, int n)
            {
                Square res = new Square();
                res.A = sq.A / Math.Abs(n);
                return res;
            }
            public static bool operator >(Square s1, Square s2)
            {
                return s1.A > s2.A;
            }

            public static bool operator <(Square s1, Square s2)
            {
                return s1.A < s2.A;
            }

            public static bool operator >=(Square s1, Square s2)
            {
                return s1.A >= s2.A;
            }

            public static bool operator <=(Square s1, Square s2)
            {
                return s1.A <= s2.A;
            }
            public static bool operator ==(Square s1, Square s2)
            {
                return s1.A == s2.A;
            }
            public static bool operator !=(Square s1, Square s2)
            {
                return s1.A != s2.A;
            }
            public static bool operator true(Square sq) {
                return (sq.A > 0);
            }
            public static bool operator false(Square sq) {
                return (sq.A <= 0);
            }
            public static implicit operator Rectangle(Square sq)
            {
                Rectangle rect = new Rectangle();
                rect.A = sq.A;
                rect.B = sq.A;
                return rect;
            }
            public static implicit operator int(Square sq)
            {
                return sq.A;
            }
        }
        class Rectangle {
            private int a;

            public int A
            {
                get { return a; }
                set {
                    if (value > 0)
                    {
                        a = value;
                    }
                    else {
                        a = 10;
                    }
                }
            }

            private int b;

            public int B
            {
                get { return b; }
                set
                {
                    if (value > 0)
                    {
                        b = value;
                    }
                    else
                    {
                        b = 10;
                    }
                }
            }

            public Rectangle() { 
                A = 10;
                B = 10;
            }
            public Rectangle(int a, int b)
            {
                A = a;
                B = b;
            }

            public override string ToString()
            {
                return $"A = {A}, B = {B}";
            }

            public int Area() {
                return A * B;
            }
            public static Rectangle operator ++(Rectangle rt) {
                rt.A++;
                rt.B++;
                return rt;
            }
            public static Rectangle operator --(Rectangle rt)
            {
                rt.A--;
                rt.B--;
                return rt;
            }
            public static Rectangle operator +(Rectangle rt, int n)
            {
                Rectangle res = new Rectangle()
                {
                    A = rt.A + Math.Abs(n),
                    B = rt.B + Math.Abs(n)
                };
                return res;
            }
            public static Rectangle operator -(Rectangle rt, int n)
            {
                Rectangle res = new Rectangle()
                {
                    A = Math.Abs( rt.A - n),
                    B = Math.Abs(rt.B - n)
                };
                if (res.A > 0 && res.B > 0)
                {
                    return res;
                }
                else
                {
                    return rt;
                }
            }
            public static Rectangle operator *(Rectangle rt, int n)
            {
                Rectangle res = new Rectangle()
                {
                    A = rt.A * Math.Abs(n),
                    B = rt.B * Math.Abs(n)
                };
                return res;
            }
            public static Rectangle operator /(Rectangle rt, int n)
            {
                Rectangle res = new Rectangle()
                {
                    A = rt.A / Math.Abs(n),
                    B = rt.B / Math.Abs(n)
                };
                return res;
            }
            public static bool operator <(Rectangle r1, Rectangle r2)
            {
                return r1.Area() < r2.Area();
            }
            public static bool operator >(Rectangle r1, Rectangle r2)
            {
                return r1.Area() > r2.Area();
            }
            public static bool operator <=(Rectangle r1, Rectangle r2)
            {
                return r1.Area() <= r2.Area();
            }
            public static bool operator >=(Rectangle r1, Rectangle r2)
            {
                return r1.Area() >= r2.Area();
            }
            public static bool operator ==(Rectangle r1, Rectangle r2)
            {
                return r1.Area() == r2.Area();
            }
            public static bool operator !=(Rectangle r1, Rectangle r2)
            {
                return r1.Area() != r2.Area();
            }
            public static bool operator true(Rectangle r) {
                return (r.Area() > 0);
            }
            public static bool operator false(Rectangle r) {
                return (r.Area() <= 0);
            }
            public static explicit operator Square(Rectangle rect)
            {
                Square sq = new Square();
                sq.A = (rect.A + rect.B) / 2;
                return sq;
            }
            public static explicit operator int(Rectangle rect)
            {
                return rect.Area();
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
