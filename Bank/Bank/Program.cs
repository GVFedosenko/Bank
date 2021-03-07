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
                            $"SELECT table_Bank.id, table_Bank.firstName, table_Bank.lastName, table_Bank.patronymic, table_Bank.birthday from table_Bank;";
                        MySqlCommand command = new MySqlCommand
                        {
                            Connection = connection, CommandText = sql
                        };
                        MySqlDataReader result = command.ExecuteReader();
                        while (result.Read())
                        {
                            string tempName0 = result.GetString("numberClient");
                            string tempName1 = result.GetString("firstName");
                            string tempName2 = result.GetString("lastName");
                            string tempName3 = result.GetString("patronymic");
                            string tempname6 = result.GetString("birthday");
                            Console.WriteLine(
                                $"{tempName0} - {tempName1} - {tempName2} - {tempName3} - {tempname6}");
                        }
                        connection.Close();
                        break;
                    case "2":
                        connection.Close();
                        Console.Write("Фамилия: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Имя: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Отчество: ");
                        string patronymic = Console.ReadLine();
                        Console.Write("Дата рождания: ");
                        string birthday = Console.ReadLine();
                        connection.Open();
                        sql = $"insert table_Bank(firstName, lastName, patronymic, birthday) value('{firstName}', '{lastName}', '{patronymic}', '{birthday}');";
                        MySqlCommand command1 = new MySqlCommand
                        {
                            Connection = connection, CommandText = sql
                        };
                        int res = command1.ExecuteNonQuery();
                        if (res == 0)
                        {
                            Console.WriteLine("Данные не добавились((");
                        }

                        else
                        {
                            Console.WriteLine("Данные добавились!");
                        }
                        
                        connection.Close();
                        break;
                    case "3":
                        connection.Close();
                        string sql2 =
                            $"SELECT table_Bank.id, table_Bank.firstName, table_Bank.lastName, table_Bank.patronymic, table_Bank.birthday from table_Bank;";
                        MySqlCommand command2 = new MySqlCommand
                        {
                            Connection = connection, CommandText = sql2
                        };
                        var result1 = command2.ExecuteReader();
                        while (result1.Read())
                        {
                            string tempName0 = result1.GetString("numberClient");
                            string tempName1 = result1.GetString("firstName");
                            string tempName2 = result1.GetString("lastName");
                            string tempName3 = result1.GetString("patronymic");
                            string tempname6 = result1.GetString("birthday");
                            Console.WriteLine(
                                $"{tempName0} - {tempName1} - {tempName2} - {tempName3} - {tempname6}");
                        }
                        Console.WriteLine("Введите номер клента, для которого желаете добавить счет: ");
                        int numberClient = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите сумму счета: ");
                        int sumContribution = Convert.ToInt32(Console.ReadLine());
                        string sql3 =
                            $"INSERT table_contribution(id, sumContribution) value('{numberClient}', '{sumContribution}');";
                        MySqlCommand command3 = new MySqlCommand
                        {
                            Connection = connection, CommandText = sql3
                        };
                        int res1 = command3.ExecuteNonQuery();
                        if (res1 == 0)
                        {
                            Console.WriteLine("Данные не добавились((");
                        }

                        else
                        {
                            Console.WriteLine("Данные добавились!");
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