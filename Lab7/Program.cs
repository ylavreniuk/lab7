using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib;

namespace Lab7
{
    internal class Program
    {
        static List<Camera> Cameras; 

        static void PrintCameras() 
        {
            foreach (var camera in Cameras) 
            {
                Console.WriteLine(camera.Info());
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Cameras = new List<Camera>(); 
            FileStream fs = new FileStream("Camera.camera", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            try
            {
                Console.WriteLine("Читаємо дані з файлу...\n");
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    Camera camera1 = new Camera();
                    for (int i = 0; i < 9; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                camera1.Name = br.ReadString();
                                break;
                            case 2:
                                camera1.Model = br.ReadString();
                                break;
                            case 3:
                                camera1.Contry = br.ReadString();
                                break;
                            case 4:
                                camera1.SceenDiagonal = br.ReadInt32();
                                break;
                            case 5:
                                camera1.MatrixSize = br.ReadInt32();
                                break;
                            case 6:
                                camera1.YearOfProduction = br.ReadDouble();
                                break;
                            case 7:
                                camera1.Weight = br.ReadDouble();
                                break;
                            case 8:
                                camera1.LensInterchangeable = br.ReadBoolean();
                                break;
                        }
                    }
                    Cameras.Add(camera1); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталась помилка: {0}", ex.Message);
            }
            finally
            {
                br.Close();
            }

            Console.WriteLine($"Несортований перелік камер: {Cameras.Count}");
            PrintCameras(); 
            Cameras.Sort();
            Console.WriteLine($"Сортований перелік камер: {Cameras.Count}");
            PrintCameras();

            Camera camera = new Camera("Nikon", "D3500", "Japan", 3, 24, 2019, 365, true);
            Cameras.Add(camera); 
            Cameras.Sort();
            Console.WriteLine($"Перелік камер: {Cameras.Count}");
            PrintCameras();

            Console.WriteLine("Видаляємо останнє значення");
            Cameras.RemoveAt(Cameras.Count - 1); 
            Console.WriteLine($"Перелік камер: {Cameras.Count}");
            PrintCameras(); 

            Console.ReadKey();
        }
    }
}
