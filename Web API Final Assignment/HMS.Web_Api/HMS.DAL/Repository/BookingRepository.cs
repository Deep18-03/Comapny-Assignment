using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Database.dbHMSEntities _dbContext;

        public BookingRepository()
        {
            _dbContext = new Database.dbHMSEntities();
        }
        public string CreateBooking(Booking model)
        {
            try
            {
                if (model != null)
                {
                    Database.Booking entity = new Database.Booking();

                    entity.Roomid = model.Roomid;
                    entity.BookingDate = model.BookingDate;
                    entity.StatusOfBooking = model.StatusOfBooking;
                 

                    _dbContext.Bookings.Add(entity);
                    _dbContext.SaveChanges();

                    return "Successfully Added";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBooking(int id)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(id);
                if (entity != null)
                {

                    _dbContext.Bookings.Remove(entity);
                    _dbContext.SaveChanges();

                    return "Deleted!";
                }
                return "No Data found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public string UpdateBooking(Booking model)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(model.id); 
                if (entity != null)
                {
                                  
                    entity.BookingDate = model.BookingDate;
                    entity.StatusOfBooking = model.StatusOfBooking;


                    _dbContext.SaveChanges();

                    return "Updated";
                }
                return "No Data found";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
