namespace cwiczenia5.Exceptions;

public class RoomNotFoundException(int id) : Exception($"Room with ID {id} not found");