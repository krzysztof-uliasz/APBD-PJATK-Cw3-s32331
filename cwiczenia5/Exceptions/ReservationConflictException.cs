namespace cwiczenia5.Exceptions;

public class ReservationConflictException(int roomId) : Exception($"Room with id {roomId} already has a reservation at that time.");