namespace WebApp.Models
{
    public static class CategoriesRepo
    {
        public static List<CategoriesModel> _categories = new List<CategoriesModel>()
        {
            new() {CategoryId = 1, CategoryName = "Beverages", CategoryDescription = "Beverages"},
            new() {CategoryId = 2, CategoryName = "Bakery", CategoryDescription = "Bakery" },
            new() {CategoryId = 3, CategoryName = "Snacks", CategoryDescription = "Snacks" }
        };
        public static void AddCategories(CategoriesModel model)
        {
            var MaxId = _categories.Max(c => c.CategoryId);
            model.CategoryId = MaxId + 1;
            _categories.Add(model);
        }
        public static List<CategoriesModel> GetCategories() => _categories;
        public static CategoriesModel? GetCategoriesById(int? categoryId)
        {
            var Data = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (Data == null)
                return null;
            else
                return new CategoriesModel
                {
                    CategoryId = Data.CategoryId,
                    CategoryName = Data.CategoryName,
                    CategoryDescription = Data.CategoryDescription
                };
        }
        public static void UpdateCategories(int categoryId, CategoriesModel model)
        {
            if (categoryId != model.CategoryId)
                return;

            var Data = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (Data == null)
                return;
            else
            {
                Data.CategoryName = model.CategoryName;
                Data.CategoryDescription = model.CategoryDescription;
            }
        }
        public static void DeleteCategories(int? categoryId)
        {
            var Data = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (Data == null)
                return;
            else
                _categories.Remove(Data);
        }
    }
}
