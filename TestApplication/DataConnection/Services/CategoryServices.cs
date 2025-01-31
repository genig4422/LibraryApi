using TestApplication.DataConnection.Models;
using TestApplication.DataConnection.ViewModels;
using TestApplication.Migrations;

namespace TestApplication.DataConnection.Services
{
    public class CategoryServices
    {
        private AppDbContext _context;

        public CategoryServices(AppDbContext context)
        {
            _context = context;
        }

        public void AddCategory(CategoryVM category)
        {
            var _category = new Category()
            {
                CategoryName = category.CategoryName
            };
            _context.Category.Add(_category);
            _context.SaveChanges();
        }


        public void RemoveCategoryByID(int memberId)
        {
            var _members = _context.Category.FirstOrDefault(n => n.Id == memberId);
            if (_members != null)
            {
                _context.Category.Remove(_members); // Use _context.Members
                _context.SaveChanges();
            }
        }


        public List<Category> GetAllCategories()
        {
            return _context.Category.ToList();
        }

        // Update a category by ID
        public Category UpdateCategoryById(int categoryId, CategoryVM category)
        {
            var _category = _context.Category.FirstOrDefault(n => n.Id == categoryId);
            if (_category != null)
            {
                _category.CategoryName = category.CategoryName;
                _context.SaveChanges();
            }

            return _category;
        }
    }
}
