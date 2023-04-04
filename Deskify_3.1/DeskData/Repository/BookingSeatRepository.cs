using DeskData.Data;
using DeskEntity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskData.Repository
{
    public class BookingSeatRepository:IBookingSeatRepository
    {
        DeskDbContext _db;
        public BookingSeatRepository(DeskDbContext db)
        {
            _db = db;
        }
        #region AddBookingSeat
        public void AddSeatBooking(BookingSeat bookseat)
        {
            _db.bookingSeats.Add(bookseat);
            _db.SaveChanges();
        }
        #endregion AddBookingSeat

        #region DeleteBookingSeat
        public void DeleteSeatBooking(int bookseatId)
        {
            var seat = _db.bookingSeats.Find(bookseatId);
            _db.bookingSeats.Remove(seat);
            _db.SaveChanges();

        }
        #endregion DeleteBookingSeat

        #region  UpdateBookingSeat
        public void UpdateSeatBooking(BookingSeat bookseat)
        {
            _db.Entry(bookseat).State = EntityState.Modified;
            _db.SaveChanges();

        }
        #endregion UpdateBookingSeat


        #region GetSeatBookingById 
        public BookingSeat GetSeatBookingById(int bookseatId)
        {
            return _db.bookingSeats.Find(bookseatId);
        }
        #endregion GetSeatBookingById

        #region GetAllBookingSeats
        public IEnumerable<BookingSeat> GetAllBookingSeats()
        {
            return _db.bookingSeats;
        }
        #endregion GetAllBookingSeats

        public IEnumerable<BookingSeat> GetBookingSeats(int employeeId, DateTime fromDate, DateTime toDate, string searchTitle)
        {
            var bookingSeat = from bs in _db.bookingSeats
                              where bs.EmployeeID == employeeId &&
                                    bs.FromDate >= fromDate &&
                                    bs.ToDate <= toDate
                              orderby bs.FromDate descending
                              select bs;

            if (!String.IsNullOrEmpty(searchTitle))
            {
                bookingSeat = (IOrderedQueryable<BookingSeat>)bookingSeat.Where(bs => bs.bookingrequesttype.Contains(searchTitle));
            }

            return bookingSeat.ToList();
        }
    }
}
