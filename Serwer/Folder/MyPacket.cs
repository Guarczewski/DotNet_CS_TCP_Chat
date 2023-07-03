using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]

public class MyPacket {

    private String _nickname;
    private String _message;
    private DateTime _messageTime;
    private int _messageRoom;

    public MyPacket(String nickname, String message, int messageRoom) {
        _nickname = nickname;
        _message = message;
        _messageTime = DateTime.Now;
        _messageRoom = messageRoom;
    }

    public String toString() {

        return "\n" + _messageTime.ToString() + " " + _nickname + " Said: " + _message; 
    }

}

