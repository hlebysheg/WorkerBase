using WorkerBase.Helpers;
using WorkerBase.models;

namespace WorkerBase.repository
{
    public class _workerRep
    {
        ApplicationContext _db;
        public _workerRep(ApplicationContext db)
        {
            _db = db;
        }

        public List<Worker> getAll()
        {
            List<Worker> all = new List<Worker>();
            all = _db.Worker.ToList();
            return all;
        }

        public Worker? create(WorkerToCreate wk)
        {
            Worker worker = new Worker
            {
                BirhtDay = wk.BirhtDay,
                Salary = wk.Salary,
                WorkDay = wk.WorkDay,
                FullName = wk.FullName,
                DepName = wk.DepName,
            };
            try
            {
                _db.Worker.Add(worker);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }
            
            return worker;
        }

        public bool delete(int id)
        {
            Worker? wk= _db.Worker.FirstOrDefault(x => x.Id == id);

            if (wk == null) return false;

            try
            {
                _db.Worker.Remove(wk);
                _db.SaveChanges();
            }
            catch 
            {
                return false;
            }

            return true;
        }

        public Worker? update(Worker wk)
        {
            Worker worker = _db.Worker.FirstOrDefault(y => y.Id == wk.Id);
            if (worker == null) return null;
            worker.FullName = wk.FullName;
            worker.DepName = wk.DepName;
            worker.WorkDay = wk.WorkDay;
            worker.Salary = wk.Salary;
            worker.WorkDay = wk.WorkDay;

            try
            {
                _db.SaveChanges();
            }
            catch { return null; }
            

            return worker;
        }
    }
}
