public class ValidadorDeData
{
   public static bool VerificaSeDataEhValida(string data)
   {
      if (data.Length != 10)
         return false;

      string[] dataSplit = data.Split('/');

      if (dataSplit.Length != 3)
         return false;

      if (dataSplit[0].Length != 2 || dataSplit[1].Length != 2 || dataSplit[2].Length != 4)
         return false;

      if (!int.TryParse(dataSplit[0], out int dia) || !int.TryParse(dataSplit[1], out int mes) || !int.TryParse(dataSplit[2], out int ano))
         return false;

      if (dia < 1 || dia > 31 || mes < 1 || mes > 12 || ano < 1)
         return false;

      return true;
   }

    public static DateOnly ConversorStringInDateOnly(string data)
    {
        string[] dataSplit = data.Split('/');
        return new DateOnly(int.Parse(dataSplit[2]), int.Parse(dataSplit[1]), int.Parse(dataSplit[0]));
    }
}