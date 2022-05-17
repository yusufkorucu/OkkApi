using Microsoft.AspNetCore.Authorization;
using OkkApi.Models;
using OkkApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkkApi.Services
{
    public interface IUserServices
    {
        /// <summary>
        /// get list of all Users
        /// </summary>
        /// <returns></returns>
        List<User> GetUserList();

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUserDetailsById(int userId);
        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="TCKNO"></param>
        /// <returns></returns>
        User GetUserDetailsByTCKNO(long TCKNO);

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        ResponseModel SaveUser(User userModel);


        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResponseModel DeleteUser(int userId);

        ///// <summary>
        ///// delete employees
        ///// </summary>
        ///// <param name="Plate"></param>
        ///// <returns></returns>
        //ResponseModel PlateQuery(string plate);
    }
    public class UserServices : IUserServices
    {
        private OKKTechDbContext db;

        public UserServices(OKKTechDbContext _db)
        {
            db = _db;
        }

        public ResponseModel DeleteUser(int userId)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                User user = GetUserDetailsById(userId);
                if (user != null)
                {
                    db.Remove<User>(user);
                    db.SaveChanges();
                    responseModel.IsSuccess = true;
                    responseModel.Messsage = "Başarı ile Silindi";
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Messsage = "Kullanıcı Bulunamadi";
                }

            }
            catch (Exception ex)
            {
                responseModel.IsSuccess = false;
                responseModel.Messsage = "Error : " + ex.Message;
            }
            return responseModel;
        }
        /// <summary>
        /// Return User Detail 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserDetailsById(int userId)
        {
            User user;
            try
            {
                user = db.Find<User>(userId);

            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }

       
        public User GetUserDetailsByTCKNO(long TCKNO)
        {

            User user;
            try
            {
                user = db.Users.Where(x => x.TCKNO == TCKNO).FirstOrDefault(); ;

            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }

        /// <summary>
        /// get Users of all employees
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserList()
        {
            List<User> userList;
            try
            {
                userList = db.Set<User>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return userList;
        }

        ///// <summary>
        ///// plate query db ismatch?
        ///// </summary>
        ///// <param name="plate"></param>
        ///// <returns></returns>
        //public ResponseModel PlateQuery(string plate)
        //{
        //    ResponseModel responseModel = new ResponseModel();
        //    User user;
        //    try
        //    {
        //        user = db.Users.Where(x => x.Plate == plate).FirstOrDefault();
        //        if (user != null)
        //        {
        //            responseModel.IsSuccess = true;
        //            responseModel.Messsage = "İşlem Başarılı";
        //            Record record = new Record();
        //            record.LoginLogoutDate = DateTime.Now;
        //            record.Users = user;
        //            db.Records.Add(record);
        //            db.SaveChanges();

        //        }
        //        else
        //        {
        //            responseModel.IsSuccess = false;
        //            responseModel.Messsage = "İşlem Başarısız";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        responseModel.IsSuccess = false;
        //        responseModel.Messsage = "Hata : " + ex.Message;

        //    }

        //    return responseModel;


        //}
        /// <summary>
        /// Save New User
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public ResponseModel SaveUser(User userModel)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                User user = GetUserDetailsById(userModel.Id);
                if (user != null)
                {
                   
                    user.Property = userModel.Property;
                    user.Plate = userModel.Plate;
                    db.Update<User>(user);
                    responseModel.Messsage = "Kullanici Basari ile güncellendi";
                }
                else
                {
                    db.Add<User>(userModel);

                    responseModel.Messsage = "Yeni Kullanici Basari ile eklendi";

                }
                db.SaveChanges();
                responseModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.IsSuccess = false;
                responseModel.Messsage = "Error" + ex.Message;
            }

            return responseModel;
        }
    }
}
