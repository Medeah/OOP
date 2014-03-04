using System;
using System.Collections.Generic;
namespace l4
{

  struct AStruct
  {
    public int X { get; set; }
    public int Y { get; set; }
    //NB: Ovenstående er kun til illustration ift øvelsen.
    //Normalt skal en struct være uforanderlig (immutable) og derfor designes sådan her:

    /*
    public readonly int X;
    public readonly int Y;
    public AStruct(int x, int y)
    {
    this.X = x;
    this.Y = y;
    }
    */
  
    public override string ToString()
    {
      return string.Format("X = {0}, Y = {1}", X, Y);
    }
  }
  class AClass
  {
    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString()
    {
      return string.Format("X = {0}, Y = {1}", X, Y);
    }
  }
  class Program
  {
    public static void ChangeStruct(AStruct a) {
      a.Y = a.Y * 2;
    }
    public static void ChangeStruct(ref AStruct a)
    {
      a.Y = a.Y * 2;
    }
    public static void ChangeStructOut(out AStruct a)
    {

      a = new AStruct() { X = 1, Y = 2 };
    }
    public static void ChangeObject(AClass a) { a.Y = a.Y * 2; }
    public static void ChangeObject(ref AClass a) { a.Y = a.Y * 2; }
    public static void ChangeObjectToNull(ref AClass a) { a = null; }
    public static void ChangeObjectOut(out AClass a)
    {
      a = new AClass() { X = 1, Y = 2 };
    }
    public static void Main()
    {

      int x = 10;
      int y = x;
      Console.WriteLine("x = ({0}), y = ({1})", x, y);
      x = 20;
      Console.WriteLine("x = ({0}), y = ({1})", x, y);
      AStruct s1 = new AStruct() { X = 10, Y = 10 };
      AStruct s2 = s1;
      ChangeStruct(s2);
      Console.WriteLine("x = ({0}), y = ({1})", s2.X, s2.Y);
      ChangeStruct(ref s1);
      Console.WriteLine("x = ({0}), y = ({1})", s1.X, s1.Y);
      ChangeStructOut(out s2);
      Console.WriteLine("x = ({0}), y = ({1})", s2.X, s2.Y);

      AClass c1 = new AClass() { X = 10, Y = 10 };
      AClass c2 = c1;
      c1.X = 20;
      ChangeObject(c2);
      Console.WriteLine("x = ({0}), y = ({1})", c2.X, c2.Y);
      ChangeObject(ref c1);
      Console.WriteLine("x = ({0}), y = ({1})", c1.X, c1.Y);
      ChangeObjectOut(out c2);
      Console.WriteLine("x = ({0}), y = ({1})", c2.X, c2.Y);
      int[] tal1 = new int[] { 1, 2, 3, 4, 5 };
      int[] tal2 = tal1;
      tal2[0] = 10;
      List<string> navne1 = new List<string>()
      {
        "Ib", "Bo"
      };
      List<string> navne2 = navne1;
      navne2.Add("Kaj");
      navne1.Remove("Ib");
    }
  }
}