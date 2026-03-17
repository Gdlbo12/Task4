using System;

namespace AvaloniaApp;

public static class Logic
{
    public static string GetMaxNum(string? inputText)
    {
        try
        {
            if (inputText == null) return "Ошибка ввода!";
            int num = int.Parse(inputText);
            

            int h = num / 100;         
            int b = (num / 10) % 10;   
            int c = num % 10;          

            
            int max = h;
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }

            return "Наибольшая цифра: " + max.ToString();
        }
        catch
        {
            return "Ошибка ввода!";
        }
    }
}
