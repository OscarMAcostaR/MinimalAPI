var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// End Points 

// Recibir nombre y apellido por url Forma 
// url http://localhost:5262/hellowhitname/Oscar/Allstar
app.MapGet("/hellowhitname/{name}/{lastname}", 
	(string name, string lastname) => $"Hola {name} {lastname}");

// Ejemlo de solicitud JSON
// End Point con metodos Asyncronos 
// {JSON} Placeholder https://jsonplaceholder.typicode.com/
// Servicio de prueba https://jsonplaceholder.typicode.com/todos/1
// url del servicio http://localhost:5262/response

app.MapGet("/response", async() =>
{
	HttpClient client = new HttpClient();
			   var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
	response.EnsureSuccessStatusCode();
	string responseBody = await response.Content.ReadAsStringAsync();
	return responseBody; 

});
// async permite que EjecutarTareaLargaAsync contenga operaciones asíncronas.
// await permite pausar y esperar que Task.Delay se complete sin bloquear el hilo principal.



app.Run();
