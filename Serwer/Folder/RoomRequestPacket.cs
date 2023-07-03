using System;

public class RoomRequestPacket {
    private String _roomName;
    private String _roomPassword;

    public RoomRequestPacket(String roomName, String roomPassword) {
        _roomName = roomName;
        _roomPassword = roomPassword;
    }
    RoomRequestPacket() {
    }
}
