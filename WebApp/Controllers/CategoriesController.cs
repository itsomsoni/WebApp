using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public static string Configuration { get; set; }
        public CategoriesController(IConfiguration configuration)
        {
            Configuration = Convert.ToString(configuration.GetConnectionString("localDB"));
        }
        public IActionResult Index()
        {
            List<CategoriesModel> categories = new List<CategoriesModel>();
            using (SqlConnection connection = new SqlConnection(Configuration))
            {
                string sqlQuery = "select CategoryId, CategoryName, CategoryDescription from Categories";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            CategoriesModel category = new()
                            {
                                CategoryId = Convert.ToInt32(dataReader["CategoryId"]),
                                CategoryName = Convert.ToString(dataReader["CategoryName"]),
                                CategoryDescription = Convert.ToString(dataReader["CategoryDescription"])
                            };
                            categories.Add(category);
                        }
                    }
                    connection.Close();
                }
            }
            //var _categories = CategoriesRepo.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoriesModel category = new CategoriesModel();
            using (SqlConnection connection = new SqlConnection(Configuration))
            {
                string sqlQuery = $"select CategoryId, CategoryName, CategoryDescription from Categories Where CategoryId = {id}";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            category.CategoryId = Convert.ToInt32(dataReader["CategoryId"]);
                            category.CategoryName = Convert.ToString(dataReader["CategoryName"]);
                            category.CategoryDescription = Convert.ToString(dataReader["CategoryDescription"]);
                        }
                    }
                    connection.Close();
                }
            }

            ViewBag.Action = nameof(Edit);
            //var Data = CategoriesRepo.GetCategoriesById(id);

            return View(category);
            //return Content($"Your Selected Id = {id}");
        }
        [HttpPost]
        public IActionResult Edit(CategoriesModel model)
        {
            if (ModelState.IsValid)
            {
                CategoriesModel category = new CategoriesModel();
                using (SqlConnection connection = new SqlConnection(Configuration))
                {
                    string sqlQuery = $"UPDATE Categories SET CategoryName = '{model.CategoryName}', CategoryDescription = '{model.CategoryDescription}' Where CategoryId = {model.CategoryId}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                //CategoriesRepo.UpdateCategories(model.CategoryId, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Add()
        {
            ViewBag.Action = nameof(Add);
            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoriesModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(Configuration))
                {
                    string sqlQuery = $"insert into Categories(CategoryName, CategoryDescription) values('{model.CategoryName}','{model.CategoryDescription}')";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                //CategoriesRepo.AddCategories(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Delete(int CategoryId)
        {
            using (SqlConnection connection = new SqlConnection(Configuration))
            {
                string sqlQuery = $"DELETE FROM Categories WHERE CategoryId = {CategoryId}";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            //CategoriesRepo.DeleteCategories(CategoryId);
            return Redirect(nameof(Index));
        }
        public IActionResult AddNew()
        {
            return RedirectToAction(nameof(Add));
        }
    }
}
