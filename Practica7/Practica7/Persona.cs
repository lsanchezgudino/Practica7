using System;
using MySql.Data.MySqlClient;
namespace Practica7
{
	public class Persona : MySQL
	{
		public Persona ()
		{
		}
		public void mostrarTodos(){
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string id = myReader["id"].ToString();
	            string codigo = myReader["codigo"].ToString();
	            string nombre = myReader["nombre"].ToString();
				string telefono = myReader["telefono"].ToString();
				string email = myReader["email"].ToString();
	            Console.WriteLine("ID: " + id +
				                  " Código: " + codigo + 
				                  " Nombre: " + nombre +
				                  " Telefono: " + telefono +
				                  " Email: " + email);
	       }
            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
			Console.ReadKey(true);
		}
		public void insertarRegistroNuevo(){
			string codigo, nombre, telefono, email;
			Console.WriteLine("Dame el Código: ");
			codigo = Console.ReadLine();
			Console.WriteLine("Dame el Nombre: ");
			nombre = Console.ReadLine();
			Console.WriteLine("Dame el Telefono: ");
			telefono = Console.ReadLine();
			Console.WriteLine("Dame el Email: ");
			email = Console.ReadLine();
			this.abrirConexion();
			string sql = "INSERT INTO `persona` (`codigo`, `nombre`, `telefono`, `email`) VALUES ('" + codigo + "', '" + nombre + "', '" + telefono + "', '" + email + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
			Console.WriteLine("\nAgregado con Exito!!!");
			Console.ReadKey(true);
		}
		public void mostrarID(string id){
			this.abrirConexion();
				MySqlCommand myCommand = new MySqlCommand("SELECT * FROM `persona` WHERE (`id`='" + id + "')", 
				                                          myConnection);
	            MySqlDataReader myReader = myCommand.ExecuteReader();	
				myReader.Read();
		        string codigo = myReader["codigo"].ToString();
		        string nombre = myReader["nombre"].ToString();
				string telefono = myReader["telefono"].ToString();
				string email = myReader["email"].ToString();
	            Console.Clear();
				Console.WriteLine("ID: " + id +
				                  " Código: " + codigo + 
				                  " Nombre: " + nombre +
				                  " Telefono: " + telefono +
				                  " Email: " + email);
	            myReader.Close();
				myReader = null;
	            myCommand.Dispose();
				myCommand = null;
				this.cerrarConexion();
		}
		public void editarRegistro(){
			string id, codigo, nombre, telefono, email, n;
			Console.WriteLine("¿Cual ID editar?: ");
			id = Console.ReadLine();
			try 
				{
				this.mostrarID(id);
				Console.WriteLine("\n¿Estas seguro en editar el Código? \n si - 1 / no - 2");
				n = Console.ReadLine();
				if(n == "1"){
					Console.WriteLine("Dame el Código: ");
					codigo = Console.ReadLine();
					Console.WriteLine("Dame el Nombre: ");
					nombre = Console.ReadLine();
					Console.WriteLine("Dame el Telefono: ");
					telefono = Console.ReadLine();
					Console.WriteLine("Dame el Email: ");
					email = Console.ReadLine();
					this.abrirConexion();
					string sql = "UPDATE `persona` SET `codigo`='" + codigo + "', `nombre`='" + nombre + "', `telefono`='" + telefono + "', `email`='" + email + "' WHERE (`id`='" + id + "')";
					this.ejecutarComando(sql);
					this.cerrarConexion();
					Console.WriteLine("\nSe editó con exito");
					Console.ReadKey(true);
				}
			}catch(Exception){
				Console.WriteLine("\nNo Existe el registro con el ID "+id);
				Console.ReadKey(true);
			}
		}
		public void eliminarRegistroPorId(){
			string id, n;
			Console.WriteLine("¿Cual ID se va Eliminar?: ");
			id = Console.ReadLine();
			try 
				{
				this.mostrarID(id);
				Console.WriteLine("\n¿Esta seguro que desea Eliminar el registro? \n si - 1 / no - 2");
				n = Console.ReadLine();
				if(n == "1"){
					this.abrirConexion();
					string sql = "DELETE FROM `persona` WHERE (`id`='" + id + "')";
					this.ejecutarComando(sql);
					this.cerrarConexion();
					Console.WriteLine("\nRegistro eliminado con exito");
					Console.ReadKey(true);
				}
			}catch(Exception){
				Console.WriteLine("\nNo Existe el reguistro con el ID "+id);
				Console.ReadKey(true);
			}
		}
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}
		private string querySelect(){
			return "SELECT * " +
	           	"FROM persona";
		}
	}
}