import sys

from PyQt5.QtWidgets import QApplication

from Controller.Controller import Controller
from Problem import Problem
from UI.MenuWindow import MenuWindow
from UI.UnBlockMeWindow import UnBlockMeWindow

if __name__ == '__main__':
    app = QApplication(sys.argv)
    problem = Problem('/Users/so/Desktop/Y2S2/AI/Lab1 - UnblockMe/Levels/05.txt')
    controller = Controller(problem = problem)
    menuWindow = UnBlockMeWindow(controller)
    sys.exit(app.exec_())