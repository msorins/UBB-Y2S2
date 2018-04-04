import copy
import sys
sys.setrecursionlimit(100000000)
from BoardState import BoardState


class Problem():

    def __init__(self, levelPath):
        self._levelPath = levelPath
        self._initialState = None
        self._finalState = None
        self._boardSize = None
        self._finalPosition = (None, None)

        self.readFromFile()

    def getInitialState(self):
        return self._initialState

    def checkIfFinalState(self, boardState):
        """
        :param boardState: BoardState object
        :return: True if the board is in a final state, false otherwise
        """
        state = boardState.getBoard()
        for i in range(boardState.getBoardSize()):
            if state[i][boardState.getBoardSize() - 1] == 'p':
                return True

        return False

    def expand(self, boardState):
        """
        :param boardState: BoardState object
        :return: a list with all the future states
        """

        state = boardState.getBoard()
        possibleFutureStates = []
        used = {}
        for i in range(boardState.getBoardSize()):
            for j in range(boardState.getBoardSize()):
                if state[i][j] != '.':
                    # It means that at the current position is a block
                    if state[i][j] in used:
                        continue

                    # Use it
                    used[ state[i][j]] = True

                    # Figure it out if the block is vertical or horizontal
                    if j < self._boardSize - 1 and state[i][j] == state[i][j + 1]:
                        # Block is horizontal
                        left = j
                        right = j

                        # Compute size of the block
                        auxj = j + 1
                        while auxj < self._boardSize and state[i][j] == state[i][auxj]:
                            right = auxj
                            auxj += 1

                        # Check to see if I can move the block one to the left or one to the right
                        if left > 0 and state[i][left - 1] == '.':
                            newState = copy.deepcopy(state)
                            newState[i][left - 1] = state[i][left]
                            newState[i][right] = '.'
                            possibleFutureStates.append( BoardState(newState) )

                        if right < boardState.getBoardSize() - 1 and state[i][right + 1] == '.':
                            newState = copy.deepcopy(state)
                            newState[i][right + 1] = state[i][right]
                            newState[i][left] = '.'
                            possibleFutureStates.append( BoardState(newState) )


                    else:
                        if i < boardState.getBoardSize() - 1 and state[i][j] == state[i + 1][j]:
                            # Block is vertical
                            top = i
                            bottom = i

                            # Compute size of the block
                            auxi = i + 1
                            while auxi < boardState.getBoardSize() and state[i][j] == state[auxi][j]:
                                bottom = auxi
                                auxi += 1

                            # Check to see if I can move the block one to the in the up or down direction
                            if top > 0 and state[top - 1][j] == '.':
                                newState = copy.deepcopy(state)
                                newState[top - 1][j] = newState[top][j]
                                newState[bottom][j] = '.'
                                possibleFutureStates.append( BoardState(newState) )

                            if bottom < boardState.getBoardSize()- 1 and state[bottom + 1][j] == '.':
                                newState = copy.deepcopy(state)
                                newState[bottom + 1][j] = newState[bottom][j]
                                newState[top][j] = '.'
                                possibleFutureStates.append( BoardState(newState) )

        return possibleFutureStates

    def heuristic(self, boardState):
        state = boardState.getBoard()
        for i in range( boardState.getBoardSize() ):
            for j in range( boardState.getBoardSize() ):
                if state[i][j] == 'p':
                    return j


    def readFromFile(self):
        with open(self._levelPath) as f:
            lines = f.readlines()

            i = 0
            for line in lines:
                line = line[:-1]
                if i == 0:
                    self._boardSize = int(line)
                    initialState = []

                    for _ in range(self._boardSize):
                        crtLine = []
                        for _ in range(self._boardSize):
                            crtLine.append(0)
                        initialState.append(crtLine)
                else:
                    for j in range(len(line)):
                        initialState[i - 1][j] = line[j]

                        if(line[j] == 'p'):
                            self._finalPosition = (i - 1, self._boardSize - 1)

                i += 1

            self._initialState = BoardState( initialState )

    def getBoardSize(self):
        return self._boardSize