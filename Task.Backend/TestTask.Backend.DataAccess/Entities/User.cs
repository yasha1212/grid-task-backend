using System.Text.Json.Serialization;

namespace TestTask.Backend.DataAccess.Entities
{
	public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

		[JsonPropertyName("lastName")]
		public string LastName { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }
    }
}

