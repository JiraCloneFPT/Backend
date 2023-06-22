using System.Reflection;

namespace be.Helpers
{
    public static class CompareTwoObject
    {
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
                    difference.Property = property.Name;
                    difference.Value1 = value1;
                    difference.Value2 = value2;
                    differences.Add(difference);
                }
            }

            return differences;
        }
    }
    public class Properties
    {
        public string Property { get; set; }
        public object Value1 { get; set; }
        public object Value2 { get; set; }
    }
}
