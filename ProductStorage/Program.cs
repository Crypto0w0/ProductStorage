using System.Data.SqlClient;

class Program
{
    static string connectionString = "Data Source=localhost;Database=test;Integrated Security=false;User ID=root;Password=Alex228420;";

    static void Main()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection succeded");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Connection error: {e.Message}");
            }
        }
        
        int ans;
        Console.WriteLine("1 - Add new product");
        Console.WriteLine("2 - Add new type product");
        Console.WriteLine("3 - Add new supplier");
        Console.WriteLine("4 - Update info about a product");
        Console.WriteLine("5 - Update info about a supplier");
        Console.WriteLine("6 - Update info about a categoty");
        Console.WriteLine("7 - Delete a product");
        Console.WriteLine("8 - Delete a supplier");
        Console.WriteLine("9 - Delete a categoty");
        ans = Convert.ToInt32(Console.ReadLine());
        if (ans == 1)
        {
            AddNewProduct();
        }
        else if (ans == 2)
        {
            AddNewCategory();
        }
        else if (ans == 3)
        {
            AddNewSupplier();
        }
        else if (ans == 4)
        {
            UpdateProduct();
        }
        else if (ans == 5)
        {
            UpdateSupplier();
        }
        else if (ans == 6)
        {
            UpdateCategory();
        }
        else if (ans == 7)
        {
            DeleteProduct();
        }
        else if (ans == 8)
        {
            DeleteSupplier();
        }
        else if (ans == 9)
        {
            DeleteCategory();
        }
        else Console.WriteLine("Unknown command");
    }
    
    static void AddNewProduct()
    {
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            Console.Write("Name: ");
            string n = Console.ReadLine();
            Console.Write("id_category: ");
            int idc = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price: ");
            int p = Convert.ToInt32(Console.ReadLine());
            Console.Write("Quantity: ");
            int q = Convert.ToInt32(Console.ReadLine());
            Console.Write("id_producer: ");
            int idp = Convert.ToInt32(Console.ReadLine());
            Console.Write("id_measurement: ");
            int idmes = Convert.ToInt32(Console.ReadLine());
            Console.Write("id_markup: ");
            int idmar = Convert.ToInt32(Console.ReadLine());
            connection.Open();
            string query = "INSERT INTO Product (name, id_category, price, quantity, id_producer, id_measurement, id_markup) VALUES (@Name, @ID_categoty, @Price, @Quantity, @ID_producer, @ID_measurement, @ID_markup)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", n);
                command.Parameters.AddWithValue("@ID_category", idc);
                command.Parameters.AddWithValue("@Price", p);
                command.Parameters.AddWithValue("@Quantity", q);
                command.Parameters.AddWithValue("@ID_producer", idp);
                command.Parameters.AddWithValue("@ID_measurement", idmes);
                command.Parameters.AddWithValue("@ID_markup", idmar);
            }
            
        }
    }
    static void AddNewCategory()
    {
        Console.Write("Name: ");
        string n = Console.ReadLine();
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Category (name) VALUES (@Name)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", n);
            }
        }
    }
    static void AddNewSupplier()
    {
        Console.Write("Name: ");
        string n = Console.ReadLine();
        Console.Write("id_adress: ");
        int ida = Convert.ToInt32(Console.ReadLine());
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Supplier (name, id_adress) VALUES (@Name, @ID_adress)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", n);
                command.Parameters.AddWithValue("@ID_adress", ida);
            }
        }
    }
    static void UpdateProduct()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Enter the id of product you want to change");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1 - Change name");
            Console.WriteLine("2 - Change price");
            Console.WriteLine("3 - Change id_category");
            Console.WriteLine("4 - Change quantity");
            Console.WriteLine("5 - Change id_producer");
            Console.WriteLine("6 - Change id_measurement");
            Console.WriteLine("7 - Change id_markup");
            int ans = Convert.ToInt32(Console.ReadLine());
            string query;
            if (ans == 1)
            {
                Console.WriteLine("New name: ");
                string n = Console.ReadLine();
                query = "UPDATE Product SET name = @Name WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", n);
                    command.Parameters.AddWithValue("@ID", ID);
                }
            }
            else if (ans == 2)
            {
                Console.WriteLine("New price: ");
                int p = Convert.ToInt32(Console.ReadLine());
                query = "UPDATE Product SET price = @Price WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Price", p);
                    command.Parameters.AddWithValue("@ID", ID);
                    
                }
            }
            else if (ans == 3)
            {
                Console.WriteLine("New id_category: ");
                int idcat = Convert.ToInt32(Console.ReadLine());
                query = "UPDATE Product SET id_category = @ID_category WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_category", idcat);
                    command.Parameters.AddWithValue("@ID", ID);
                }
            }
            else if (ans == 4)
            {
                Console.WriteLine("New quantity: ");
                int q = Convert.ToInt32(Console.ReadLine());
                query = "UPDATE Product SET quantity = @Quantity WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Quantity", q);
                    command.Parameters.AddWithValue("@ID", ID);
                }
            }
            else if (ans == 5)
            {
                Console.WriteLine("New id_producer: ");
                int idp = Convert.ToInt32(Console.ReadLine());
                query = "UPDATE Product SET id_producer = @ID_producer WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_producer", idp);
                    command.Parameters.AddWithValue("@ID", ID);
                }
            }
            else if (ans == 6)
            {
                Console.WriteLine("New id_measurement: ");
                int idmes = Convert.ToInt32(Console.ReadLine());
                query = "UPDATE Product SET id_measurement = @ID_mesurement WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_mesurement", idmes);
                    command.Parameters.AddWithValue("@ID", ID);
                }
            }
            else if (ans == 7)
            {
                Console.WriteLine("New id_markup: ");
                int idmar = Convert.ToInt32(Console.ReadLine());
                query = "UPDATE Product SET id_markup = @ID_markup WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_markup", idmar);
                    command.Parameters.AddWithValue("@ID", ID);
                }
            }
            else Console.WriteLine("Unknown command");
        }
    }
    static void UpdateSupplier()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Enter the id of product you want to change");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1 - Change name");
            Console.WriteLine("2 - Change id_adress");
            int ans = Convert.ToInt32(Console.ReadLine());
            string query;
            if (ans == 1)
            {
                Console.WriteLine("New name: ");
                string n = Console.ReadLine();
                query = "UPDATE Supplier SET name = @Name WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", n);
                    command.Parameters.AddWithValue("@ID", ID);
                }
            }
            else if (ans == 2)
            {
                Console.WriteLine("New id_adress: ");
                int ida = Convert.ToInt32(Console.ReadLine());
                query = "UPDATE Supplier SET id_adress = @ID_adress WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_adress", ida);
                    command.Parameters.AddWithValue("@ID", ID);
                }
            }
            else Console.WriteLine("Unknown command");
        }
    }
    static void UpdateCategory()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Enter the id of product you want to change");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("New name: ");
            string n = Console.ReadLine();
            string query = "UPDATE Category SET name = @Name WHERE id = @ID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", n);
                command.Parameters.AddWithValue("@ID", ID);
            }
        }
    }
    static void DeleteProduct()
    {
        Console.WriteLine("Enter the id of product you want to delete");
        int ID = Convert.ToInt32(Console.ReadLine());
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Product WHERE id = @ID ";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
            }
        }
    }
    static void DeleteSupplier()
    {
        Console.WriteLine("Enter the id of supplier you want to delete");
        int ID = Convert.ToInt32(Console.ReadLine());
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Supplier WHERE id = @ID ";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
            }
        }
    }
    static void DeleteCategory()
    {
        Console.WriteLine("Enter the id of categoty you want to delete");
        int ID = Convert.ToInt32(Console.ReadLine());
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Category WHERE id = @ID ";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
            }
        }
    }
}