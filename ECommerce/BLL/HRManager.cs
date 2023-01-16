namespace BLL;
using DAL;
using BOL;
public class HRManager
{
public List<Department> GetAllDepartments (){
List<Department> allDepartments =new List<Department>();
allDepartments=DBManager.GetAllDepartments();
return allDepartments;
}

public bool Insert(int id, string name, string location)
{
DBManager dbmgr=new DBManager();
return DBManager.Insert(id, name, location);

}

public void Deletedep(int id)
{
 DBManager.DeleteDb(id);
}

public void Updatedep(int id, string name, string location)
{
    DBManager.Updatedb(id,name,location);
}

}
