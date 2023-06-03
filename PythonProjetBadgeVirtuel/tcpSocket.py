import socket
import time

TCP_IP = '127.0.0.1'
TCP_PORT = 1234
BUFFER_SIZE = 1024

def full_grid(value="0"):
    tcp_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    tcp_socket.connect((TCP_IP, TCP_PORT))
    data = value * 44 * 11
    b = bytes(data, encoding='utf-8')
    tcp_socket.send(b)
    print("Clear sent:")
    tcp_socket.close()


def send_bytes(b):
    full_grid() #Clear
    tcp_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    tcp_socket.connect((TCP_IP, TCP_PORT))
    tcp_socket.send(b)
    print(f"Message sent: {b}")
    tcp_socket.close()
