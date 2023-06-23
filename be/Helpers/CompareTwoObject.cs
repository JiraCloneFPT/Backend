using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace be.Helpers
{
    public static class CompareTwoObject
    {
        public static string CutString (string name)
        {
            string[] words = Regex.Split(name, @"(?<!^)(?=[A-Z][^A-Z]+$)");
            return string.Join(" ", words);

        }
        public static List<Properties> CompareObjects<T>(T obj1, T obj2)
        {
            List<Properties> differences = new List<Properties>();

            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                object value1 = property.GetValue(obj1);
                object value2 = property.GetValue(obj2);

                if (!Equals(value1, value2))
                {
                    Properties difference = new Properties();
                    difference.Property = CutString(property.Name);
                    difference.Orginal = value1;
                    difference.New = value2;
                    differences.Add(difference);
                }
            }

            return differences;
        }
    }
    public class Properties
    {
        public string Property { get; set; }
        public object Orginal { get; set; }
        public object New { get; set; }
    }
}
