#Create a windows with a button

import tkinter as tk
from tkinter import ttk
import tcpSocket

win = tk.Tk()
win.title("Python GUI")

#Buttons events
def send_button():
    tcpSocket.send_bytes(b"11001100111")

def fill_button():
    tcpSocket.full_grid("1")

def clear_button():
    tcpSocket.full_grid("0")


#Buttons
send_btn = ttk.Button(win, text="Send", command=send_button)
send_btn.grid(column=1, row=2)

fill_btn = ttk.Button(win, text="Fill", command=fill_button)
fill_btn.grid(column=2, row=2)

clear_btn = ttk.Button(win, text="Clear", command=clear_button)
clear_btn.grid(column=3, row=2)


#Start GUI
def main():
    win.mainloop()

    