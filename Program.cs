using System;
using System.Text;

class Program
{
    /* Aluno: Lucas Barros Simon - RA: 235182
     * Aluno: Osi Paes Junior - RA: 237112 */

    /* Função de criptografia: Fórmula: cCripto(i) = (cOriginal(i) + 
       cChave(i % comprimentoChave)) * 2
     * Para realizar a criptografia, é feita a adição do valor do 
       caractere do texto original (cOriginal(i)) com o valor do 
       caractere da chave (cChave(i % comprimentoChave), onde % 
       comprimentoChave trata a repetição da chave). O produto dessa 
       adição é então dobrado para obter o caractere criptografado 
       (cCripto(i)). */

    /* Função de descriptografia: Fórmula: cDescripto(i) = (cCripto(i) /
       2) - cChave(i % comprimentoChave)
     * Para realizar a descriptografia, o procedimento consiste em 
       dividir o número correspondente ao caractere criptografado 
       (cCripto(i)) por 2. Depois, é necessário subtrair o valor do 
       caractere da chave (cChave(i % comprimentoChave)) para obter o 
       caractere inicial do texto original (cDescripto(i)). */

    static void Main()
    {
        Console.WriteLine("1 - Criptografar");
        Console.WriteLine("2 - Descriptografar");
        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine();

        if (opcao == "1")
        {
            ExecutarCriptografia();
        }
        else if (opcao == "2")
        {
            ExecutarDescriptografia();
        }
        else
        {
            Console.WriteLine("Opção inválida!");
        }
    }

    static void ExecutarCriptografia()
    {
        Console.Write("Digite a chave de criptografia: ");
        string chave = Console.ReadLine();
        Console.Write("Digite o texto para criptografar: ");
        string textoOriginal = Console.ReadLine();
        string textoCripto = Criptografia(textoOriginal, chave);
        Console.WriteLine($"Texto criptografado: {textoCripto}");
    }

    static void ExecutarDescriptografia()
    {
        Console.Write("Digite a chave de descriptografia: ");
        string chave = Console.ReadLine();
        Console.Write("Digite o texto para descriptografar: ");
        string textoCripto = Console.ReadLine();
        string textoDescripto = Descriptografia(textoCripto, chave);
        Console.WriteLine($"Texto descriptografado: {textoDescripto}");
    }

    static string Criptografia(string textoOriginal, string chave)
    {
        StringBuilder textoCripto = new StringBuilder();
        int comprimentoChave = chave.Length;

        for (int i = 0; i < textoOriginal.Length; i++)
        {
            char cOriginal = textoOriginal[i];
            char cChave = chave[i % comprimentoChave];
            // Função matemática para criptografia
            int desloc = (cOriginal + cChave) * 2;
            char cCripto = (char)desloc;
            textoCripto.Append(cCripto);
        }

        return textoCripto.ToString();
    }

    static string Descriptografia(string textoCripto, string chave)
    {
        StringBuilder textoDescripto = new StringBuilder();
        int comprimentoChave = chave.Length;

        for (int i = 0; i < textoCripto.Length; i++)
        {
            char cCripto = textoCripto[i];
            char cChave = chave[i % comprimentoChave];
            // Função matemática para descriptografia
            int desloc = cCripto / 2;
            char cDescripto = (char)(desloc - cChave);
            textoDescripto.Append(cDescripto);
        }

        return textoDescripto.ToString();
    }
}