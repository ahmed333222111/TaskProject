using MyAppSLN.EntityServices.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppSLN.EntityServices
{
    public class TaskManager : BaseClass.BaseClass
    {
        #region Get
        #region GetAll
        public TaskResponse<List<Entity.Task>> GetAll()
        {
            try
            {
                List<Entity.Task> _taskList = _taskDBEntities.Tasks.ToList();
                if (_taskList.Count > 0)
                {
                    return Task_Success(_taskList);
                }
                else
                {

                    return Task_NotFound<List<Entity.Task>>();
                }
            }
            catch (Exception ex)
            {
                return Task_BadRequest<List<Entity.Task>>("Task Exception Is: " + ex.Message);
            }
        }
        #endregion
        #region GetById
        public TaskResponse<Entity.Task> GetById(int id)
        {
            try
            {
                var _entity = _taskDBEntities.Tasks.FirstOrDefault(e => e.Id == id);
                if (_entity != null)
                {
                    return Task_Success(_entity);
                }
                else
                {

                    return Task_NotFound<Entity.Task>();
                }
            }
            catch (Exception ex)
            {
                return Task_BadRequest<Entity.Task>("Task Exception Is: " + ex.Message);
            }
        }
        #endregion
        #region GetMaxNum
        public TaskResponse<int> GetMaxId()
        {
            try
            {
                var _entity = _taskDBEntities.Tasks.FirstOrDefault();
                if (_entity != null)
                {
                    int maxId = _taskDBEntities.Tasks.Max(u => u.Id) + 1;
                    return Task_Success(maxId);

                }
                else
                {
                    return Task_Success(1);
                }
            }
            catch (Exception ex)
            {
                return Task_BadRequest<int>("Task Exception Is: " + ex.Message);
            }
        }
        #endregion
        #endregion
        #region Operation
        #region Insert
        public TaskResponse<Entity.Task> Insert(Entity.Task task)
        {
            try
            {
                if (task.Title == string.Empty || task.Description == string.Empty || task.Assignee == string.Empty || task.DueDate <= DateTime.Now.Date)
                {
                    return Task_NotCreated(task, " You Should Write Valid Data - يجب ادخال بيانات صحيحة ");
                }
                task.Id = GetMaxId().Data;
                var _entity = _taskDBEntities.Tasks.FirstOrDefault(e => e.Id == task.Id);
                if (_entity == null)
                {
                    _taskDBEntities.Tasks.AddObject(task);
                    _taskDBEntities.SaveChanges();
                    return Task_Created(task, " Task Added Successful - تم اضافة مهمة بنجاح ");

                }
                else
                {
                    return Task_NotCreated(task, " Task Already Existing - المهمة تم اضافتها من قبل ");
                }
            }
            catch (Exception ex)
            {
                return Task_BadRequest(task, "Task Exception Is: " + ex.Message);
            }
        }
        #endregion
        #region Update
        public TaskResponse<Entity.Task> Update(Entity.Task task)
        {
            try
            {
                if (task.Title == string.Empty || task.Description == string.Empty || task.Assignee == string.Empty || task.DueDate <= DateTime.Now.Date)
                {
                    return Task_NotCreated(task, " You Should Write Valid Data - يجب ادخال بيانات صحيحة ");
                }
                var _entity = _taskDBEntities.Tasks.FirstOrDefault(e => e.Id == task.Id);
                if (_entity != null)
                {
                    _entity.Title = task.Title;
                    _entity.Description = task.Description;
                    _entity.Assignee = task.Assignee;
                    _entity.DueDate = task.DueDate;
                    _entity.Status = task.Status;
                    _taskDBEntities.SaveChanges();
                    return Task_Updated(task, " Task Updated Successful - تم تعديل المهمة بنجاح ");
                }
                else
                {
                    return Task_NotUpdated(task, " Task Does Not Exist in Database - المهمة غير موجودة فى قاعدة البيانات ");
                }
            }
            catch (Exception ex)
            {
                return Task_BadRequest(task, "Task Exception Is: " + ex.Message);
            }

        }
        #endregion
        #region Delete
        public TaskResponse<Entity.Task> Delete(int id)
        {
            try
            {
                var _entity = _taskDBEntities.Tasks.FirstOrDefault(e => e.Id == id);
                if (_entity != null)
                {
                    _taskDBEntities.Tasks.DeleteObject(_entity);
                    _taskDBEntities.SaveChanges();
                    return Task_Deleted(_entity, " Task Deleted Successful - تم حذف المهمة بنجاح ");
                }
                else
                {
                    return Task_NotFound<Entity.Task>(" Task Does Not Exist in Database - المهمة غير موجود فى قاعدة البيانات ");
                }
            }
            catch (Exception ex)
            {
                return Task_BadRequest<Entity.Task>("Task Exception Is: " + ex.Message);
            }
        }
        #endregion
        #endregion
    }
}
