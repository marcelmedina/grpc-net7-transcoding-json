using Grpc.Net.Client;
using System.Text.Json;
using GrpcNet7JSONTranscoding.Protos;
using System.Net.Http;

var userId = 1;

// gRPC
var channel = GrpcChannel.ForAddress("https://localhost:7060");
var client = new UserService.UserServiceClient(channel);
var userDetails = await client.GetUserDetailsAsync(new UserRequest() { UserId = userId });
Console.WriteLine(JsonSerializer.Serialize(userDetails));

// REST API
var httpClient = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7060/user/{userId}") { Version = new Version(2, 0) };
var response = await httpClient.SendAsync(request);
response.EnsureSuccessStatusCode();
var content = await response.Content.ReadAsStringAsync();
Console.WriteLine(content);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();