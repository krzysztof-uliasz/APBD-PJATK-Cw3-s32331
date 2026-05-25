namespace cwiczenia5.Exceptions;

public class RoomNotActiveException(int id) : Exception($"Room with id {id} is not active.");