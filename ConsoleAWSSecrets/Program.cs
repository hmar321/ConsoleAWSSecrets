using ConsoleAWSSecrets;
using ConsoleAWSSecrets.Helpers;
using ConsoleAWSSecrets.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

Console.WriteLine("Ejemplo secrets manager");
string miSecreto = await HelperSecretManager.GetSecretAsync();
Console.WriteLine(miSecreto);

//PODEMOS DAR FORMATO A NUESTRO SECRET PARA PODER UTILIZARLO COMO CLASE
KeysModel model = JsonConvert.DeserializeObject<KeysModel>(miSecreto);
Console.WriteLine("MySql: " + model.Mysql);

//ALMACENAMOS EL OBJETO KEYS MODEL DENTRO DEL DY
var provider = new ServiceCollection().AddTransient<ClaseTest>().AddSingleton<KeysModel>(x => model).BuildServiceProvider();
//EN CUALQUIER CLASE PODEMOS RECUPERAR LAS KEYS, POR EJEMPLO,
//EN EL PROPIO PROGRAM SI NECESITAMOS CONNECTION STRING O EN
//CUALQUIER OTRA CLASE DE INYECCION
var service = provider.GetService<KeysModel>();
string connectionString = service.Mysql;
Console.WriteLine(connectionString);
var test = provider.GetService<ClaseTest>();
Console.WriteLine("Api: "+test.GetValue());

