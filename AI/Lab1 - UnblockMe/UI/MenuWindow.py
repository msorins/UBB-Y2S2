from PyQt5 import uic
from PyQt5.QtCore import pyqtSlot
from PyQt5.QtWidgets import QWidget, QDialog
from qtconsole.qt import QtGui, QtCore

from UI.UnBlockMeWindow import UnBlockMeWindow


class MenuWindow(QWidget):
    def __init__(self, controller):
        super().__init__()
        self.controller = controller
        self.initUI()

    def initUI(self):
        uic.loadUi('/Users/so/Desktop/Y2S2/AI/Lab1 - UnblockMe/UI/MenuWindowUI.ui', self)
        self.connectSignalsToSlots()
        self.show()


    def connectSignalsToSlots(self):
        # Start Game Button
        self.startGamePushButton.clicked.connect(self.startGamePushButtonClicked)

    @pyqtSlot()
    def startGamePushButtonClicked(self):
        # Get Game Size
        txt = self.gameSizeLineEdit.text()
        size = int(txt)

        # Start a new Game with the given Size
        window = QDialog()
        self.unBlockMeWindow = UnBlockMeWindow( window, self.controller )
        window.exec_()





