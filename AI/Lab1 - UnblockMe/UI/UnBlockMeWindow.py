import sys

import time
from PyQt5 import QtWidgets, uic
from PyQt5.QtCore import pyqtSlot

from PyQt5.QtWidgets import QApplication, QWidget, QTableWidget, QTableWidgetItem, QVBoxLayout, QMainWindow
from PyQt5.QtGui import QIcon, QColor
import random

from qtconsole.qt import QtGui

from Problem import Problem


class UnBlockMeWindow(QWidget):
    def __init__(self,  controller):
        super().__init__()
        uic.loadUi('/Users/so/Desktop/Y2S2/AI/Lab1 - UnblockMe/UI/UnBlockMeWindow.ui', self)
        self._controller = controller
        self.connectSignalsWithSlots()
        self.initColors()
        self.initTable()
        self.drawTable(controller.getProblem().getInitialState())
        self.show()

    def initColors(self):
        self._colors = []
        for i in range(200):
            self._colors.append( QColor(random.randint(0, 255), random.randint(0, 255), random.randint(0, 255)) )

    def connectSignalsWithSlots(self):
        self.dfsPushButton.clicked.connect( self.dfsPushButtonClicked )
        self.bfsPushButton.clicked.connect( self.bfsPushButtonClicked )
        self.gbfsPushButton.clicked.connect( self.gbfsPushButtonClicked )

        self.backPushButton.clicked.connect( self.backPushButtonClicked )
        self.forwardPushButton.clicked.connect( self.forwardPushButtonClicked )
        self.loadLevelPushButton.clicked.connect( self.loadLevelPushButtonClicked )

    def initTable(self):
        # Create table
        #self.gameBoardTableWidget = QTableWidget()
        self.gameBoardTableWidget.setRowCount(self._controller.getProblem().getBoardSize())
        self.gameBoardTableWidget.setColumnCount(self._controller.getProblem().getBoardSize())

        for i in range(self._controller.getProblem().getBoardSize()):
            self.gameBoardTableWidget.horizontalHeader().setSectionResizeMode(i, QtWidgets.QHeaderView.Stretch)
            self.gameBoardTableWidget.verticalHeader().setSectionResizeMode(i, QtWidgets.QHeaderView.Stretch)

        self.gameBoardTableWidget.move(0, 0)

    def drawTable(self, boardState):
        """
        :param boardState: BoardState object
        :return: -> paint the tableWidget accoridng to the blocks
        """
        state = boardState.getBoard()

        for i in range( boardState.getBoardSize() ):
            for j in range( boardState.getBoardSize() ):
                self.gameBoardTableWidget.setItem(i, j, QtGui.QTableWidgetItem())
                if state[i][j] == '.':
                    self.gameBoardTableWidget.item(i, j).setBackground(QColor(255, 255, 255))
                elif state[i][j] == 'p':
                    self.gameBoardTableWidget.item(i, j).setBackground(QColor(204, 0, 0))
                elif str(state[i][j]).isdigit():
                    self.gameBoardTableWidget.item(i, j).setBackground(self._colors[int(state[i][j])])
                else:
                    self.gameBoardTableWidget.item(i, j).setBackground(self._colors[ ord(state[i][j])])

    @pyqtSlot()
    def dfsPushButtonClicked(self):
        start_time = time.time()

        self._resultsSteps = self._controller.dfs()
        self._posResultsSteps = len(self._resultsSteps) - 1
        self.drawTable( self._resultsSteps[ self._posResultsSteps ] )

        elapsed_time = time.time() - start_time
        self.statusLabel.setText(str(round(elapsed_time,3)) + " ms")

    @pyqtSlot()
    def bfsPushButtonClicked(self):
        start_time = time.time()

        self._resultsSteps = self._controller.bfs(False)
        self._posResultsSteps = len(self._resultsSteps) - 1
        self.drawTable(self._resultsSteps[self._posResultsSteps])

        elapsed_time = time.time() - start_time
        self.statusLabel.setText(str(round(elapsed_time, 3)) + " ms")

    @pyqtSlot()
    def gbfsPushButtonClicked(self):
        start_time = time.time()

        self._resultsSteps = self._controller.bfs(True)
        self._posResultsSteps = len(self._resultsSteps) - 1
        self.drawTable(self._resultsSteps[self._posResultsSteps])

        elapsed_time = time.time() - start_time
        self.statusLabel.setText(str(round(elapsed_time, 3)) + " ms")

    @pyqtSlot()
    def backPushButtonClicked(self):
        if(self._posResultsSteps > 0):
            self._posResultsSteps -= 1

        self.drawTable(self._resultsSteps[self._posResultsSteps])

    @pyqtSlot()
    def forwardPushButtonClicked(self):
        if (self._posResultsSteps < len(self._resultsSteps) - 1):
            self._posResultsSteps += 1

        self.drawTable(self._resultsSteps[self._posResultsSteps])

    @pyqtSlot()
    def loadLevelPushButtonClicked(self):
        levelPathText = self.levelPathLineEdit.text()
        newProblem = Problem('/Users/so/Desktop/Y2S2/AI/Lab1 - UnblockMe/Levels/' + levelPathText)
        self._controller.setProblem( newProblem )
        self.drawTable( newProblem.getInitialState() )




