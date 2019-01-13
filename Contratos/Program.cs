using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos.Entities;
using Contratos.Entities.Enums;

namespace Contratos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o nome do departamento:");
            string dept = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Nivel (Junior, MidLevel, Senior): ");
            WorkerLevel level;
            Enum.TryParse(Console.ReadLine(), true, out level);
            Console.WriteLine("Entre com o salário base: ");
            double salario = double.Parse(Console.ReadLine());

            Department department = new Department(dept);
            Worker worker = new Worker(nome, level, salario, department);

            Console.WriteLine("Quantos contratos para este trabalhador?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i<=n; i++)
            {
                Console.WriteLine($"Entre com os dados do {i}º contrato:");
                Console.Write("Entre com a data(dd/mm/aaaa): ");
                DateTime data = DateTime.Parse(Console.ReadLine());

                Console.Write("Entre com o valor por hora: ");
                int valorhora = int.Parse(Console.ReadLine());

                Console.Write("Entre com a duração (quantidade de horas): ");
                int qtdhora = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(data, valorhora, qtdhora);
                worker.AddContract(contract);

            }

            Console.WriteLine();
            Console.Write("Entre com o (mm/aaaa) para calcular o ganho:");
            string mesAno = Console.ReadLine();
            int mes = int.Parse(mesAno.Substring(0, 2));
            int ano = int.Parse(mesAno.Substring(3));

            Console.WriteLine("Nome: "+ worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("Ganhos: "+ worker.Income(ano,mes).ToString("F2"));



        }
    }
}
