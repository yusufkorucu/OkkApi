using OkkApi.Models;
using OkkApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkkApi.Services
{

    public interface IRecordServices
    {

        List<Record> GetAllRecords();
        List<Record> GetRecordsByUserId(int id);
        List<Record> GetRecordsBySpecialCode(string specialCode);
        Record LastRecordByTCKNO(long tckno);
        Record RecordDetailById(int id);
        ResponseModel DeleteRecord(int id);
        ResponseModel DeleteRecordByTCKNO(long tckno);
        ResponseModel SaveRecord(RecordSaveRequestModel requestModel);

    }

    public class RecordServices : IRecordServices
    {
        private OKKTechDbContext db;

        public RecordServices(OKKTechDbContext _db)
        {
            db = _db;
        }

        public ResponseModel DeleteRecord(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                Record record = RecordDetailById(id);
                if (record != null)
                {
                    db.Remove<Record>(record);
                    db.SaveChanges();
                    responseModel.IsSuccess = true;
                    responseModel.Messsage = "Başarı ile Silindi";
                }
                else
                {
                    responseModel.IsSuccess = true;
                    responseModel.Messsage = "Kayıt Silinemedi";

                }

            }
            catch (Exception ex)
            {

                responseModel.IsSuccess = false;
                responseModel.Messsage = "Error : " + ex.Message;
            }
            return responseModel;
        }

        public ResponseModel DeleteRecordByTCKNO(long tckno)
        {
            List<Record> records;
            ResponseModel responseModel = new ResponseModel();

            try
            {
                records = GetRecordsByTCKNO(tckno);
                if (records != null)
                {
                    foreach (var item in records)
                    {
                        db.Remove<Record>(item);
                    }
                    responseModel.IsSuccess = true;
                    responseModel.Messsage = "Plakaya tanımli tüm girisler silindi";
                }


            }
            catch (Exception ex)
            {
                responseModel.IsSuccess = true;
                responseModel.Messsage = "Error" + ex.Message;

            }

            return responseModel;
        }

        public List<Record> GetAllRecords()
        {
            List<Record> records;
            try
            {
                records = db.Set<Record>().ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return records;
        }

        public List<Record> GetRecordsByTCKNO(long TCKNO)
        {
            List<Record> records = null;
            User user;
            try
            {

                user = db.Users.Where(x => x.TCKNO == TCKNO).FirstOrDefault();
                if (user != null)
                {
                    records = db.Records.Where(x => x.Users.Id == user.Id).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return records;

        }

        public List<Record> GetRecordsBySpecialCode(string specialCode)
        {
            List<Record> records = new List<Record>();
            User user = db.Find<User>(specialCode);
            records = db.Records.Where(x => x.Users.SpecialCode == specialCode).ToList();
            return records;
        }

        public List<Record> GetRecordsByUserId(int id)
        {
            List<Record> records = new List<Record>();
            User user = db.Find<User>(id);
            records = db.Records.Where(x => x.Users.Id == id).ToList();
            return records;
        }

        public Record LastRecordByTCKNO(long TCKNO)
        {
            Record record = new Record();

            record = db.Records.Where(x => x.Users.TCKNO == TCKNO).LastOrDefault();



            return record;
        }

        /// <summary>
        /// getrecord detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Record RecordDetailById(int id)
        {
            Record record;
            try
            {
                record = db.Find<Record>(id);
            }
            catch (Exception)
            {

                throw;
            }
            return record;
        }


        public ResponseModel SaveRecord(RecordSaveRequestModel requestModel)
        {
            ResponseModel responseModel = new ResponseModel();

            User user = db.Users.Where(x => x.TCKNO == requestModel.TCKNO).FirstOrDefault();
            if (user != null)
            {
                Record record = new Record();
                record.LoginLogoutDate = DateTime.Now;
                record.DurationTime = requestModel.DurationTime;
                record.Users = user;
                record.DataPulse = requestModel.DataPulse;
                record.HStatus = Enums.Enums.HastaStat.DurumBilgisiYok;
                db.Records.Add(record);
                db.SaveChanges();

                #region Create Api Request
                // ai api ye istek at dönüşe göre 
                // db yi güncelle

                #endregion

                responseModel.IsSuccess = true;
                responseModel.Messsage = "Kayit Basari ile eklendi";
            }
            else
            {
                responseModel.IsSuccess = false;
                responseModel.Messsage = "TCKNO kaydina ulasilamadi ";
            }


            responseModel.IsSuccess = false;
            responseModel.Messsage = "Basarisiz Kayit Ekleme";

            return responseModel;
        }




        #region Kullanılmayan Metodlar

        //public ResponseModel DeleteRecordByPlate(string plate)
        //{
        //    List<Record> records;
        //    ResponseModel responseModel = new ResponseModel();

        //    try
        //    {
        //        records = GetRecordsByTCKNO(plate);
        //        if (records != null)
        //        {
        //            foreach (var item in records)
        //            {
        //                db.Remove<Record>(item);
        //            }
        //            responseModel.IsSuccess = true;
        //            responseModel.Messsage = "Plakaya tanımli tüm girisler silindi";
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        responseModel.IsSuccess = true;
        //        responseModel.Messsage = "Error" + ex.Message;

        //    }

        //    return responseModel;

        //}
        //public Record LastRecordByPlate(string plate)
        //{
        //    Record record = new Record();
        //    if (!string.IsNullOrEmpty(plate))
        //    {
        //        record = db.Records.Where(x => x.Users.Plate == plate).LastOrDefault();

        //    }

        //    return record;

        //}


        //public ResponseModel SaveRecord(string plate)
        //{
        //    ResponseModel responseModel = new ResponseModel();
        //    if (!string.IsNullOrEmpty(plate))
        //    {
        //        User user = db.Users.Where(x => x.Plate == plate).FirstOrDefault();
        //        if (user != null)
        //        {
        //            Record record = new Record();
        //            record.LoginLogoutDate = DateTime.Now;
        //            record.Users = user;
        //            db.Records.Add(record);
        //            db.SaveChanges();
        //            responseModel.IsSuccess = true;
        //            responseModel.Messsage = "Giris Cikis Kaydi Basari ile eklendi";
        //        }
        //        else
        //        {
        //            responseModel.IsSuccess = false;
        //            responseModel.Messsage = "Basarisiz giris cikis kaydi ekleme plaka kaydina ulasilamadi ";
        //        }

        //    }
        //    else
        //    {
        //        responseModel.IsSuccess = false;
        //        responseModel.Messsage = "Basarisiz giris cikis kaydi ekleme ";
        //    }
        //    return responseModel;
        //}
        #endregion
    }
}
