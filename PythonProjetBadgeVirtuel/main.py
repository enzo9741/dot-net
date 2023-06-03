import gui
import tcpSocket

def main():
    print("Debut du programme")
    gui.main()

def close():
    tcpSocket.close()
    print("Socket closed")
    print("Fin du programme")

if __name__ == "__main__":
    main()

