using System;
using System.IO;
using System.Collections.Generic;


class Program {
  public class Triangle 
    {
      public int a {get; private set;}
      public int b {get; private set;}
      public int c {get; private set;}
    
      public Triangle(int[] sides)
      {
        a = Math.Min(sides[0],Math.Min(sides[1],sides[2]));
        c = Math.Max(sides[0],Math.Max(sides[1],sides[2]));
        int t1 = Array.IndexOf(sides, a);
        int t2 = Array.IndexOf(sides,c);
        switch(t1+t2)
        {
          case 1: b = sides[2]; break;
          case 2: b = sides[1]; break;
          default: b = sides[0]; break;
        }
      }
      public bool IsValid (){
        if ((a+b)>c) {
          return true;
        } else {return false;}
      }
      public string Printer() {
        return a.ToString() + ", " + b.ToString() + ", " + c.ToString();
      }
  }
  
  public static void Main (string[] args) 
  {
    List<string> rawlines = new List<string>();
    //string fileName = "test.txt";
    string fileName = "input.txt";
    using (StreamReader reader = new StreamReader(File.Open(fileName, FileMode.OpenOrCreate))) {
      while (!reader.EndOfStream){
        rawlines.Add(reader.ReadLine().Trim());  
      }
    }
    
    List<Triangle> triangles = new List<Triangle>();
    foreach (string line in rawlines) {
      int space1 = line.IndexOf(' ');
      int[] triArray = new int[3];
      triArray[0] = int.Parse(line.Substring(0,space1));
      string temp1 = line.Substring(space1).Trim();
      int space2 = temp1.IndexOf(' ');
      triArray[1] = int.Parse(temp1.Substring(0,space2));
      triArray[2] = int.Parse(temp1.Substring(space2).Trim());
      Triangle temptri = new Triangle(triArray);
      triangles.Add(temptri);
    }
    int counter = 0;
    foreach (Triangle tri in triangles) {
      if (tri.IsValid()) {counter += 1; }
    }
    Console.WriteLine($"Part 1: I've found {triangles.Count} triangles.");
    Console.WriteLine($"In the end, I found {counter} were possible.");

    List<Triangle> triangles2 = new List<Triangle>();
    for (int i=0;i<rawlines.Count;i+=3) 
    {
      int[] line1 = new int[3];
      int[] line2 = new int[3];
      int[] line3 = new int[3];
      int space1l1 = rawlines[i].IndexOf(' ');
      line1[0] = int.Parse(rawlines[i].Substring(0,space1l1));
      string l1temp = rawlines[i].Substring(space1l1).Trim();
      int space2l1 = l1temp.IndexOf(' ');
      line1[1] = int.Parse(l1temp.Substring(0,space2l1));
      line1[2] = int.Parse(l1temp.Substring(space2l1).Trim());
      int space1l2 = rawlines[i+1].IndexOf(' ');
      line2[0] = int.Parse(rawlines[i+1].Substring(0,space1l2));
      string l2temp = rawlines[i+1].Substring(space1l2).Trim();
      int space2l2 = l2temp.IndexOf(' ');
      line2[1] = int.Parse(l2temp.Substring(0,space2l2));
      line2[2] = int.Parse(l2temp.Substring(space2l2).Trim());
      int space1l3 = rawlines[i+2].IndexOf(' ');
      line3[0] = int.Parse(rawlines[i+2].Substring(0,space1l3));
      string l3temp = rawlines[i+2].Substring(space1l3).Trim();
      int space2l3 = l3temp.IndexOf(' ');
      line3[1] = int.Parse(l3temp.Substring(0,space2l3));
      line3[2] = int.Parse(l3temp.Substring(space2l3).Trim());
      int[] tri1_a = new int[3];
      tri1_a[0] = line1[0];
      tri1_a[1] = line2[0];
      tri1_a[2] = line3[0];
      int[] tri2_a = new int[3];
      tri2_a[0] = line1[1];
      tri2_a[1] = line2[1];
      tri2_a[2] = line3[1];
      int[] tri3_a = new int[3];
      tri3_a[0] = line1[2];
      tri3_a[1] = line2[2];
      tri3_a[2] = line3[2];
      Triangle tri1 = new Triangle(tri1_a);
      Triangle tri2 = new Triangle(tri2_a);
      Triangle tri3 = new Triangle(tri3_a);
      triangles2.Add(tri1);
      triangles2.Add(tri2);
      triangles2.Add(tri3);      
    }
    int counter2 = 0;
    foreach (Triangle tri in triangles2) {
      if (tri.IsValid()) {counter2 += 1; }
    }
    Console.WriteLine($"Part 2: I found {triangles2.Count} triangles.");
    Console.WriteLine($"In the end, I found {counter2} were possible.");
  }
}
