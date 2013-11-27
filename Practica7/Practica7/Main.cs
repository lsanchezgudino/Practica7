using System;

namespace Practica7
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			try 
				{
				Console.BackgroundColor = ConsoleColor.DarkMagenta;
				Console.ForegroundColor = ConsoleColor.White;
				Persona persona = new Persona();
				string opc;
				do{
					Console.Clear();
					Console.WriteLine ("\n\t\t░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
					                   "\t\t░░\t◄ Menu Principal ► \t░░\n" +
					                   "\t\t░░ 1.- Mostrar todo \t\t░░\n" +
					                   "\t\t░░ 2.- Agregar Nuevo Registro \t░░\n" +
					                   "\t\t░░ 3.- Editar Registro \t\t░░\n" +
					                   "\t\t░░ 4.- Eliminar Registro \t░░\n" +
					                   "\t\t░░ 5.- Salir \t\t\t░░\n" +
					                   "\t\t░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
					opc = Console.ReadLine();
					switch(opc){
						case "1": 
							Console.Clear();
							persona.mostrarTodos();	
							break;
						case "2": 
							Console.Clear();
							persona.insertarRegistroNuevo();
							break;
						case "3":
							Console.Clear();
							persona.editarRegistro();
							break;
						case "4":
							Console.Clear();
							persona.eliminarRegistroPorId();
							break;
						case "5":
							Console.Clear();
							Console.Write("Press any key to continue . . . ");
							Console.ReadKey(true);
							break;
						default:
							Console.Clear();
							Console.WriteLine("Opcion incorrecta");
							Console.ReadKey(true);
							break;
					}
					}while(opc != "5");
			}catch(Exception){
				Console.WriteLine("NO EXISTE BASE DE DATOS\n");
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
	}
}
