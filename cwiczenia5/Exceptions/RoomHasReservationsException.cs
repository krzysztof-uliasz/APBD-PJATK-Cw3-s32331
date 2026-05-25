namespace cwiczenia5.Exceptions;

public class RoomHasReservationsException(int id) : Exception($"Room with id {id} has future reservations and cannot be deleted.");