using System;
using System.Text.RegularExpressions;

namespace EasyFreteApp.Application.Service.Validators
{
    public static class CepValidator
    {
       public static decimal CepValid(this string cep)
       {
            int tamanhoValido = 8;
            Regex rgx = new Regex(@"^[0-9]*$");
            cep = cep.Replace("-", "");

            if (string.IsNullOrEmpty(cep) || cep.Length != tamanhoValido)
                throw new Exception("Cep inválido");
            if(!rgx.IsMatch(cep))
                throw new Exception("Cep contém caracteres inválidos");

            return decimal.Parse(cep);
       }
    }
}
