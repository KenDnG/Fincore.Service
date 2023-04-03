namespace FINCORE.HELPER.LIBRARY.Helper
{
    public static class ConvertHelper
    {
        public static string ConvertAttribute(string Attribute)
        {
            if (Attribute.Length < 1)
            {
                return null;
            }
            char[] ch = new char[Attribute.Length];
            for (int i = 0; i < Attribute.Length; i++)
            {
                if (i == 0)
                {
                    ch[i] = Char.ToUpper(Attribute[i]);
                }
                else if (char.Equals(Attribute[i], '_'))
                {
                    ch[i] = Attribute[i];
                    i++;
                    ch[i] = Char.ToUpper(Attribute[i]);
                }
                else
                {
                    ch[i] = Attribute[i];
                }
            }

            Attribute = '@' + String.Join("", ch);
            var x = string.Format(@"""{0}""", Attribute.Replace("_", String.Empty));
            return string.Format(@"""{0}""", Attribute.Replace("_", String.Empty)).Replace("\"", "");
        }
    }
}