using System;
using MySql.Data.MySqlClient;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string inquiry =
            "Server=mysql60.hostland.ru;Database=host1323541_itstep38;Uid=host1323541_itstep;Pwd=269f43dc;";
            MySqlConnection connection = new MySqlConnection(inquiry); 
            connection.Open();

            if (connection.Ping())
            {
                Console.WriteLine("БД открылась!");
                Console.WriteLine("Вы в базе данных банка.");
                Console.WriteLine("Выберите необходимое действие:");
                Console.WriteLine("1. Посмотреть БД целиком.");
                Console.WriteLine("2. Создать нового клиента.");
                Console.WriteLine("3. Создать новый счет для клиента.");
                Console.WriteLine("4. Создать новый кредит для клиента.");
                Console.WriteLine("5. Остатки по счетам клиента.");
                Console.WriteLine("6. Остатки по кредитам клиента.");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        string sql =
                            $"SELECT table_Bank.id, table_Bank.firstName, table_Bank.lastName, table_Bank.patronymic, table_credit.sumCredit, table_contribution.sumContribution from table_Bank join table_credit join table_contribution on table_Bank.id = table_credit.id and table_Bank.id = table_contribution.id;";
                        MySqlCommand command = new MySqlCommand
                        {
                            Connection = connection, CommandText = sql
                        };
                        MySqlDataReader result = command.ExecuteReader();
                        while (result.Read())
                        {
                            string tempName0 = result.GetString("id");
                            string tempName1 = result.GetString("firstName");
                            string tempName2 = result.GetString("lastName");
                            string tempName3 = result.GetString("patronymic");
                            string tempName4 = result.GetString("sumCredit");
                            string tempName5 = result.GetString("sumContribution");
                            Console.WriteLine($"{tempName0} - {tempName1} - {tempName2} - {tempName3} - {tempName4} - {tempName5}");
                        }
                        connection.Close();
                        break;
                }
            }
            else
            {
                Console.Write("БД не открылась(((");
            }
            connection.Close();
        }
    }
}