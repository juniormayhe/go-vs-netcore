using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WebApplication22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        public TodoController(MySqlDatabase mySqlDatabase)
        {
            this.MySqlDatabase = mySqlDatabase;
        }

        private MySqlDatabase MySqlDatabase { get; set; }

        [HttpGet]
        public async Task<IEnumerable<TodoModel>> GetAsync()
        {
            return await GetAll();
        }

        private async Task<List<TodoModel>> GetAll()
        {
            var ret = new List<TodoModel>();

            var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT ID, Title, Completed FROM todo_models";

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var t = new TodoModel
                    {
                        ID = reader.GetFieldValue<uint>(0),
                        Title = reader.GetFieldValue<string>(1),
                        Completed = reader.GetFieldValue<bool>(2)
                    };

                    ret.Add(t);
                }
            }

            return ret;
        }
    }
}
