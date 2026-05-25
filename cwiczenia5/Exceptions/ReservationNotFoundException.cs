namespace cwiczenia5.Exceptions;

public class ReservationNotFoundException(int id) : Exception($"Room with ID {id} not found");
