using FacadePattern.Models;
using FacadePattern.Repositories;
using FacadePattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    // Abstract Facade
    public interface ITicketService
    {
        Ticket BuyTicket(string from, string to, DateTime when, byte numberOfPlaces);
        void CancelTicket(Ticket ticket);
        void MoveTicket(Ticket ticket, DateTime when);
    }

    // Concrete Facade
    public class PkpInteregioTicketService : ITicketService
    {
        public Ticket BuyTicket(string from, string to, DateTime when, byte numberOfPlaces)
        {
            throw new NotImplementedException();
        }

        public void CancelTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void MoveTicket(Ticket ticket, DateTime when)
        {
            throw new NotImplementedException();
        }
    }

    // Concrete Facade
    public class PkpIntercityTicketService : ITicketService
    {
        private readonly RailwayConnectionRepository railwayConnectionRepository;
        private readonly TicketCalculator ticketCalculator;
        private readonly ReservationService reservationService;
        private readonly PaymentService paymentService;
        private readonly EmailService emailService;

        public PkpIntercityTicketService(RailwayConnectionRepository railwayConnectionRepository, TicketCalculator ticketCalculator, ReservationService reservationService, PaymentService paymentService, EmailService emailService)
        {
            this.railwayConnectionRepository = railwayConnectionRepository;
            this.ticketCalculator = ticketCalculator;
            this.reservationService = reservationService;
            this.paymentService = paymentService;
            this.emailService = emailService;
        }

        public Ticket BuyTicket(string from, string to, DateTime when, byte numberOfPlaces)
        {         
            RailwayConnection railwayConnection = railwayConnectionRepository.Find(from, to, when);
            decimal price = ticketCalculator.Calculate(railwayConnection, numberOfPlaces);
            Reservation reservation = reservationService.MakeReservation(railwayConnection, numberOfPlaces);
            Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
            Payment payment = paymentService.CreateActivePayment(ticket);

            if (payment.IsPaid)
            {
                emailService.Send(ticket);
            }

            return ticket;

        }

        public void CancelTicket(Ticket ticket)
        {
            Payment payment = paymentService.CreateActivePayment(ticket);
            reservationService.CancelReservation(ticket.RailwayConnection, ticket.NumberOfPlaces);
            paymentService.RefundPayment(payment);
        }

        public void MoveTicket(Ticket ticket, DateTime when)
        {
            throw new NotImplementedException();
        }
    }
}
