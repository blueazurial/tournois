using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    class DbToEntityMapper
    {
        public static Dish ToDish(IDataReader reader)
        {
            return new Dish
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Price = (float)(decimal)reader["Price"],
                CategoryId = (int)reader["CategoryId"],
                Active = (bool)reader["Active"],
                Discount = reader["Discount"] as int?,
                Picture = reader["Picture"] as string
            };
        }

        public static User ToUser(IDataReader reader)
        {
            for(int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine(reader[i]);
            }
            return new User
            {
                Id = (int)reader["Id"],
                Email = (string)reader["Email"],
                Street = (string)reader["Street"],
                ZipCode = (int) reader["ZipCode"],
                City = (string) reader["City"],
                BirthDate = reader["BirthDate"] as DateTime?,
                Role = reader["Role"] as string,
                Number = (string)reader["Number"],
                LastName = (string) reader["LastName"],
                FirstName = (string) reader["FirstName"]
            };
        }

        public static Comment ToComment(IDataReader reader)
        {
            return new Comment
            {
                Id = (int)reader["Id"],
                Content = reader["Content"].ToString(),
                Date = (DateTime)reader["Date"],
                UserId = (int)(reader["UserId"] == DBNull.Value ? null : reader["UserId"]),
                DishId = (int)reader["DishId"],
                Rating = (decimal)reader["Rating"]
            };
        }

        public static Category ToCategory(IDataReader reader)
        {
            return new Category
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString()
            };
        }
        

    }
}
