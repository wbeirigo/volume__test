using System;
using System.Globalization;
using System.Xml.Linq;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

// Sphere class responnsible for calculete volume
public static class SphereVolume
{
    private const float PI = 3.14159F;

    private const float Surface = 4F / 3F;

    /* GetVolume
	 Input 	        radius float       Radius valus
	 Return 	  volume float     Volume value
	*/
    public static float GetVolume(float radius)
    {
        float volume = Surface * PI * radius * 3;
        return volume;
    }
}


// Read input file 
public static class IoFeatures
{
    public static List<string> readTextFromPath(String path)
    {
        List<string> lineList = new List<string>();

        if (!File.Exists(path))
            throw new Exception("Arquivo Não existe");

        using var fs = new FileStream(path, FileMode.Open);
        using var reader = new StreamReader(fs);
        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            if (line is string)
                lineList.Add(line);
        }
        return lineList;
    }
}



public class Program
{

    public static void Main()
    {
        string path = @"C:\Users\wbeirigo\source\repos\SphereVolume\input.txt";

        Console.WriteLine("Informe o cominho do arquivo, ou tecle enter para utilizar o caminho abaixo:");
        Console.WriteLine(path);

        string? pathFromUser = Console.ReadLine();
        if (pathFromUser.ToString() != string.Empty)
            path = pathFromUser.ToString();
        else
            path = @"C:\Users\wbeirigo\source\repos\SphereVolume\input.txt";

        string strOutPut;
        List<string> listInputLines = IoFeatures.readTextFromPath(path);
        foreach (string field in listInputLines)
        {
            try
            {
                float radius = float.Parse(field, CultureInfo.InvariantCulture.NumberFormat);
                float volume = SphereVolume.GetVolume(radius);
                strOutPut = string.Format("{0:F5}\t\tVolume = {1:F5}", radius, volume);
            }
            catch
            {
                strOutPut = string.Format("ERRO:[{0}]", field);
            }
            Console.WriteLine(strOutPut);
        }
    }
}
