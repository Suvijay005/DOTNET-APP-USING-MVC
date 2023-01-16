namespace DAL;
using BOL;
using MySql.Data.MySqlClient;
public class DBManager
{
public static string conString=@"Server=localhost;port=3306;user=root;password=Su$hr4567Ut97;database=transflower";
public static List<Department> GetAllDepartments(){
List<Department> allDepartments=new List<Department>();
MySqlConnection con =new MySqlConnection();//creating object for connection to mysql db
con.ConnectionString=conString;//gets or sets a string used to connect to a MySql server database
try{
con.Open();
MySqlCommand cmd =new MySqlCommand();
cmd.Connection=con;
string query="SELECT * FROM departments";
cmd.CommandText=query;
MySqlDataReader reader=cmd.ExecuteReader();
while(reader.Read()){

int id=int.Parse(reader["id"].ToString());
string name=reader["name"].ToString();
string location=reader["location"].ToString();

Department dept=new Department{
    Id=id,
    Name=name,
    Location=location
};
allDepartments.Add(dept);
}
}
catch(Exception e){
    Console.WriteLine(e.Message);
}
finally{
    con.Close();
}
return allDepartments;
}

public static bool Insert(int id, string name, string location){
bool status=false;
string query="INSERT INTO departments(id,name,location)" + "VALUES('" + id + "','" + name + "','" + location + "')";
MySqlConnection con=new MySqlConnection();
con.ConnectionString=conString;
try{
con.Open();
MySqlCommand cmd=new MySqlCommand(query,con);
cmd.ExecuteNonQuery();
status=true ;
}
catch(Exception e){
    Console.WriteLine(e.Message);
}
finally{
    con.Close();
}
return status;
}

public static void DeleteDb(int id)
{
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=conString;
try{
con.Open();
string query="DELETE FROM departments WHERE id="+id;
MySqlCommand cmd=new MySqlCommand(query,con);
cmd.ExecuteNonQuery();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
finally{
    con.Close();
}
return;
}

public static void Updatedb(int id,string name,string location)
{
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=conString;
try{
    con.Open();
    string query="UPDATE departments SET name='"+name+"',location='"+location+"' WHERE Id="+id;
    MySqlCommand cmd=new MySqlCommand(query,con);
    cmd.ExecuteNonQuery();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
finally{
    con.Close();
}
return;
}

}
