using System;
using System.Collections.Generic;
using System.Text;
using Books.Models;
using SQLite;

namespace Books.Repositories
{

        public class DatePublish
        {
            SQLiteConnection connection;
            public DatePublish()
            {
                connection = new SQLiteConnection(Constantes.Constants.DatabasePath, Constantes.Constants.Flags);
                connection.CreateTable<Date>();
            }
            public void Init()
            {
                connection.CreateTable<Date>();
            }
            public void InsertOrUpdate(Date fecha)
            {
                if (fecha.Id == 0)
                {
                    connection.Insert(fecha);
                }
                else
                {
                    connection.Update(fecha);
                }
            }
            public Date GetById(int Id)
            {
                return connection.Table<Date>().FirstOrDefault(item => item.Id == Id);
                
            }
            public List<Date> GetAll()
            {
                return connection.Table<Date>().ToList();
            }
            public void DeleteItem(int Id)
            {
                Date fecha = GetById(Id);
                connection.Delete(fecha);
            }
        }
}
