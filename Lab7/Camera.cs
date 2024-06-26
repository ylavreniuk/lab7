using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace ClassLib
{
    public class Camera : IComparable
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Contry { get; set; }
        public int SceenDiagonal { get; set; }
        public int MatrixSize { get; set; }
        public double YearOfProduction { get; set; }
        public double Weight { get; set; }
        public bool LensInterchangeable { get; set; }

        public double Price
        {
            get { return MatrixSize * YearOfProduction; }
        }
        public Camera()
        {
        }

        public Camera(string name, string model, string contry, int sceenDiagonal,
            int matrixSize, double yearOfProduction,
            double weight, bool lensInterchangeable)
        {
            Name = name;
            Model = model;
            Contry = contry;
            SceenDiagonal = sceenDiagonal;
            MatrixSize = matrixSize;
            YearOfProduction = yearOfProduction;
            Weight = weight;
            LensInterchangeable = lensInterchangeable;
            

        }
        public string Info()
        {
            return Name + ", " + Model + ", " +Price;
        }
        public int CompareTo(object obj)
        {
            Camera b = obj as Camera;
            return string.Compare(this.Name, b.Name);
        }
    }
}



