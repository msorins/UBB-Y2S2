class BoardState():

    def __init__(self, board):
        self._boardSize = len(board)
        self._board = board

    def getBoard(self):
        return self._board

    def getBoardSize(self):
        return self._boardSize

    def setBoard(self, board):
        self._board = board




