from collections import namedtuple
class Controller():
    def __init__(self, problem):
        """
        :param problem: a Problem object that has to be solved
        """
        self._problem = problem

    def getProblem(self):
        return self._problem

    def setProblem(self, problem):
        self._problem = problem

    def orderStates(self, states):
        pass

    def bfs(self, greedy):
        queue = []
        queue.append( self._problem.getInitialState() )
        visited = {}
        father = {}

        while len(queue) != 0:
            crtState = queue[0]
            queue = queue[1:]

            nextStates = self._problem.expand(crtState)
            if greedy:
                nextStates.sort(key=lambda x: self._problem.heuristic(x), reverse=True)

            for nextState in nextStates:
                if self._problem.checkIfFinalState(nextState):
                    father[nextState] = crtState
                    return self.bfsForm(father, nextState)

                nextStateStrng = self.hashState( nextState.getBoard() )

                if not nextStateStrng in visited:
                    father[ nextState ] = crtState
                    queue.append( nextState )
                    visited[ nextStateStrng ] = True

    def bfsForm(self, father, lastStep):
        steps = []
        crtStep = lastStep
        while crtStep in father:
            steps.append(crtStep)
            crtStep = father[crtStep]

        return steps[::-1]

    def dfs(self):
        self._dfsNodeOrder = []
        self._dfsVisited = {}
        self._dfsStop = False
        self.computeDFS( self._problem.getInitialState() )
        return self._dfsNodeOrder

    def computeDFS(self, crtState):

        nextStates = self._problem.expand(crtState)
        #nextStates.sort(key= lambda x: self._problem.heuristic(x), reverse = True)

        for nextState in nextStates:
            if self._problem.checkIfFinalState( nextState ):
                self._dfsNodeOrder.append(nextState)
                self._dfsStop = True
                return nextState

            nextStateStrng = self.hashState( nextState.getBoard() )
            if not nextStateStrng in self._dfsVisited or self._dfsVisited[nextStateStrng] == False:
                self._dfsVisited[nextStateStrng] = True
                self._dfsNodeOrder.append(nextState)

                self.computeDFS(nextState)
                if self._dfsStop == True:
                    return

                self._dfsNodeOrder = self._dfsNodeOrder[:-1]


    def areStatesTheSame(self, state1, state2):
        if state1 == None or state2  == None:
            return False

        for i in range(state1.getBoardSize()):
            for j in range(state1.getBoardSize()):
                if state1.getBoard()[i][j] != state2.getBoard()[i][j]:
                    return False

        return True


    def hashState(self, state):
        nextStateStrng = ""
        for line in state:
            for elem in line:
                nextStateStrng = nextStateStrng + elem

        return nextStateStrng