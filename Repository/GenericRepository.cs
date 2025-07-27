using Microsoft.EntityFrameworkCore;
using StudentManagementSys_SURE.Models;

namespace StudentManagementSys_SURE.Repository
{
    public class GenericRepository<TEntity> where TEntity : class 
    {
        StudentManagContext db;
        public GenericRepository(StudentManagContext db)
        {
            this.db = db;
        }   

        public List<TEntity> selectAll()
        {
            return db.Set<TEntity>().ToList();
        }
        //public TEntity GetById(int id)
        //{
        //    return db..Set<TEntity>().Include(s => s.Department)
        //              .FirstOrDefault(s => s.Id == id);
        //}
        public void Add(TEntity entity) 
        {             
            db.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {

            db.Update(entity);
        }

        public void Delete(int id)
        {
            TEntity s=db.Set<TEntity>().Find(id);
            db.Set<TEntity>().Remove(s);
            
        }

        public void Save() {
        db.SaveChanges();
        }
    }
}
