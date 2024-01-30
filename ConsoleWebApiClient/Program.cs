using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ConsoleWebApiClient
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }

    internal class Program
    {

     
         public static void  Main()
        {
            Console.WriteLine("Bitte drücken Sie eine Taste um das POST abzuschicken");
            Console.ReadLine();
            Console.WriteLine("POST TodoItem");

            TodoItem postPayload = new TodoItem();
            postPayload.Name="ein Demo aus C#";
            postPayload.IsComplete = false;
            var todoitem= PostTodoItem(postPayload).Result;
            Console.WriteLine(todoitem);

        }
        static HttpClient client = new HttpClient();
        static async Task<TodoItem> PostTodoItem(TodoItem payload)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:7077/api/TodoItems", payload);
            response.EnsureSuccessStatusCode();
            
            var content = response.Content;
            var result = await content.ReadAsStringAsync();
            TodoItem todoItem = JsonConvert.DeserializeObject<TodoItem>(result);
            return todoItem;

        }


    }
}
